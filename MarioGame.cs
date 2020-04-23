using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.TileMap;
using MahJong.GameState;
using System.Collections.Generic;

using MahJong.Enums;
using MahJong.Sound;

[assembly:CLSCompliant(true)]
namespace MahJong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    internal class MarioGame : Game
    {
        public Control Control { get; }
        public Scene Scene { get; }
        public GameModel GameModel { get; }
        public GraphicsDeviceManager Graphics { get; }
        public SoundManager SoundManager { get; }
        public Point FieldSize { get; set; }
        public Map Map { get { return GameModel.Map; } }
        public IGameState CurrgameState;
        static private MarioGame _game;
        public static MarioGame Mariogame
        {
            get
            {
                return _game;
            }
        }
        public MarioGame()
        {
            _game = this;
            Graphics = new GraphicsDeviceManager(this);
            SoundManager = SoundManager.Instance;
            Content.RootDirectory = "Content";

            GameModel = new GameModel(this);
            Scene = new Scene(this, GameModel);
            Control = new Control(this, GameModel, Scene);

            CurrgameState = new PlayGameState(this, CurrgameState);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            GameModel.Initialize();
            Control.Initialize();
            Scene.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            GameModel.LoadContent();
            Control.LoadContent();
            Scene.LoadContent();
            SoundManager.LoadSounds(this);
            SoundManager.PlayMainThemeSound();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            Content.Unload();
        }        

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Control.Update(gameTime);
            //GameModel.Update();
            //Scene.Update(gameTime);
        
            CurrgameState.Update(gameTime);
            System.Console.WriteLine(CurrgameState);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (CurrgameState is BlackScreenState || CurrgameState is GameOverState || CurrgameState is WinState)
            {
                GraphicsDevice.Clear(Color.Black);
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            CurrgameState.Draw(gameTime);

            base.Draw(gameTime);
        }

        public void ResetLevel()
        {
            SoundManager.StopAllSound();
            CurrgameState = new PlayGameState(this, CurrgameState);
            GameModel.ResetLevel();
            Control.RemapControllers();
            Control.InSecret = false;
            SoundManager.PlayMainThemeSound();
            Scene.camera.Limits = new Rectangle(
                0, 0,
                Math.Max(GraphicsDevice.Viewport.Width, FieldSize.X * Const.GRID_WIDTH), 
                Math.Max(GraphicsDevice.Viewport.Height, FieldSize.Y * Const.GRID_HEIGHT)
                );
        }
        public void ResetGame()
        {
            GameModel.startX = GameModel.restartX;
            ResetLevel();
            GameProperties.Instance.Reset();
        }

        public void MuteGame()
        {
            SoundManager.MuteAndUnmute();
        }

        public void Pause()
        {
            CurrgameState = new PauseGameState(this);
        }

        public void PlayerDead()
        {
            CurrgameState.PlayerDead();
        }

        public void UnPause()
        {
            CurrgameState = new PlayGameState(this, CurrgameState);
        }
    }
}
