using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MahJong.Controllers;
using MahJong.GameState;

namespace MahJong
{
    // Controller class in the MVC design pattern
    internal class Control
    {
        //public MarioGame Game { get; set; }

        public Collection<IController> Controllers { get; }

        private MarioGame game;
        private GameModel model;
        private Scene scene;
        public bool InSecret { get; set; }

        public Control(MarioGame game, GameModel model, Scene scene)
        {
            this.game = game;
            this.model = model;
            this.scene = scene;
            InSecret = false;
            Controllers = new Collection<IController>();
        }

        public void Initialize()
        {
            Controllers.Add(new GamepadController(game));
            Controllers.Add(new KeyboardController(game));
        }

        public void LoadContent()
        {
            foreach (IController c in Controllers)
            {
                if (c is KeyboardController)
                {
                    Debug.WriteLine("1");

                    c.AddCommand((int)Keys.Q, new ExitCommand(game));
                    c.AddCommand((int)Keys.R, new ResetLevelCommand(game));

                    // Keys for moving left, moving right, jump, and crouch 
                    c.AddCommand((int)Keys.A, new MoveMarioLeftCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.A, new MoveMarioLeftReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.Left, new MoveMarioLeftCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.Left, new MoveMarioLeftReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.D, new MoveMarioRightCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.D, new MoveMarioRightReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.Right, new MoveMarioRightCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.Right, new MoveMarioRightReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.W, new MarioJumpCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.W, new MarioJumpReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.Up, new MarioJumpCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.Up, new MarioJumpReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.S, new MarioCrouchCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.S, new MarioCrouchReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Keys.Down, new MarioCrouchCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Keys.Down, new MarioCrouchReleaseCommand(model.Mario), KeyBehavior.release);

                    // Keys for change mario's 'Power-up' state and throw fireball
                    c.AddCommand((int)Keys.Y, new NormalMarioCommand(model.Mario));
                    c.AddCommand((int)Keys.U, new SuperMarioCommand(model.Mario));
                    c.AddCommand((int)Keys.T, new StarMarioCommand(model.Mario));
                    c.AddCommand((int)Keys.I, new FireMarioCommand(model.Mario));
                    c.AddCommand((int)Keys.O, new DamageMarioCommand(model.Mario));
                    c.AddCommand((int)Keys.X, new ThrowFireballCommand(model.Mario));
                    c.AddCommand((int)Keys.F1, new StartNormalLevelCommand(game));
                    //c.AddCommand((int)Keys.F2, new StartRandonLevelCommand(game));
                    c.AddCommand((int)Keys.F4, new BacktoStartPageCommand(game));


                    // Keys for visualize collision box
                    c.AddCommand((int)Keys.C, new VisualizeCollisionBoxCommand(scene));
                    c.AddCommand((int)Keys.M, new MuteCommand(game));
                    //// Keys for change brick's state
                    //controller.AddCommand((int)Keys.X, new QuestionToUsedBlockCommand(this));
                    //controller.AddCommand((int)Keys.OemQuestion, new HitQuestionBlockCommand(this));
                    //controller.AddCommand((int)Keys.H, new HiddenToVisibleblockCommand(this));
                    //controller.AddCommand((int)Keys.B, new HitBrickBlockCommand(this));
                }
                else if (c is GamepadController)
                {
                    Debug.WriteLine("2");
                    c.AddCommand((int)Buttons.Start, new ExitCommand(game));
                    c.AddCommand((int)Buttons.DPadLeft, new MoveMarioLeftCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Buttons.DPadLeft, new MoveMarioLeftReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Buttons.DPadRight, new MoveMarioRightCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Buttons.DPadRight, new MoveMarioRightReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Buttons.DPadDown, new MarioCrouchCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Buttons.DPadDown, new MarioCrouchReleaseCommand(model.Mario), KeyBehavior.release);
                    c.AddCommand((int)Buttons.A, new MarioJumpCommand(model.Mario), KeyBehavior.hold);
                    c.AddCommand((int)Buttons.A, new MarioJumpReleaseCommand(model.Mario), KeyBehavior.release);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Controller controller in Controllers)
                controller.UpdateInput();
        }

        public void RemapControllers()
        {
            foreach (IController c in Controllers)
            {
                c.ClearCommands();
            }
            LoadContent();
        }

        public void EnterExitHiddenArea()
        {
            if (!InSecret)
            {
                Scene.camera.Limits = model.SecretArea;
                InSecret = true;
            }
            else
            {
                Scene.camera.Limits = new Rectangle(
                    0, 0,
                    Math.Max(game.GraphicsDevice.Viewport.Width, game.FieldSize.X * Const.GRID_WIDTH),
                    Math.Max(game.GraphicsDevice.Viewport.Height, game.FieldSize.Y * Const.GRID_HEIGHT));
                InSecret = false;
            }
        }
    }
}
