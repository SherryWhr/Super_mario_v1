using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject;
using MahJong.GameObject.Mario;
using MahJong.GameObject.Sprites;
using MahJong.Collision;
using MahJong.Factory;
using MahJong.GameObject.Enemies;
using MahJong.Scrolling;
using MahJong.GameState;

namespace MahJong
{
    // View class in MVC design pattern
    internal class Scene : IDisposable
    {
        //private SpriteBatch spriteBatchBackground;
        private SpriteBatch spriteBatchObject;
        private SpriteBatch spriteLinearWrap;
        //private List<Layer> _layers;
        //private Camera camera;
        public static Camera camera;

        public MarioGame Game { get; set; }

        public bool VisualizeCollisionBox = false;

        private GameModel model;
        //private Background background;
        private LinearWrap background;

        //TEST
        //public HUD Hud;
        public Scene(MarioGame game, GameModel model)
        {
            this.Game = game;
            this.model = model;
        }

        public void Initialize()
        {
            SpriteFactory.Initialize(Game);
            Debug.WriteLine("Initializing background and Mario");

            //_layers = new List<Layer>();
            camera = new Camera(Game.GraphicsDevice.Viewport, Game.FieldSize);
            //_layers = new List<Layer> { new Layer(camera) { Parallax = new Vector2(0.5f, 0.5f) } };
            //_layers[0].Sprites.Add(new Sprite(Game.Content.Load<Texture2D>("background"), new Point(1, 1), false));

            Debug.WriteLine("Initializing linear wrap background");

            background = new LinearWrap(Game);
            background.Initialize();
            //sHud = new HUD(Game);
        }

        public void LoadContent()
        {
            //spriteBatchBackground = new SpriteBatch(Game.GraphicsDevice);
            spriteBatchObject = new SpriteBatch(Game.GraphicsDevice);
            spriteLinearWrap = new SpriteBatch(Game.GraphicsDevice);
            
            
        }

        public void Update(GameTime gameTime)
        {
            camera.LookAt(model.Mario.Location);
            
            foreach (IGameObject obj in model.GameObjects)
            {
                obj.Update(gameTime);
            }
        }

        //public void DrawBackground( )
        //{
        //    foreach (Layer layer in _layers)
        //        layer.Draw(spriteBatchBackground);
        //}

        public void DrawObject()
        {
            spriteBatchObject.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, camera.GetViewMatrix(new Vector2(1.0f, 1.0f)));
            foreach (IGameObject obj in model.GameObjects)
            {
                obj.Draw(spriteBatchObject);
                if (VisualizeCollisionBox)
                {
                    obj.DrawBorderRectangles(spriteBatchObject);
                }
            }
            spriteBatchObject.End();

        }

        public void DrawLinearWrap()
        {
            background.Draw(spriteLinearWrap, camera);
        }

        public void Draw(GameTime gameTime)
        {
            if (!(Game.CurrgameState is BlackScreenState)&&!(Game.CurrgameState is GameOverState) && !(Game.CurrgameState is WinState))
            {
                DrawLinearWrap();
                DrawObject();
            }
            else
            {
                //spriteBatchObject.Begin(SpriteSortMode.BackToFront);
                ////blackBackground.Draw(spriteBatchObject, new Vector2(0, 0));
                //spriteBatchObject.End();

            }
            //Hud.Draw(spriteBatchObject);

        }

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
                spriteBatchObject.Dispose();
                spriteLinearWrap.Dispose();
                background.Dispose();
            }
            // free native resources
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
