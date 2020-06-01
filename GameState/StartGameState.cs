using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameState
{
    class StartGameState: BaseGameState, IDisposable
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        private ISprite Logo;
        public StartGameState(MarioGame game)
        : base(game)
        {

            game.Control.RemapControllers();
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            //font = game.Content.Load<SpriteFont>("Arial");
            Logo = new Sprite(game.Content.Load<Texture2D>("Logo"), new Point(1, 1), false);

        }
        public override void Update(GameTime gameTime)
        {
            //game.Control.Update(gameTime);
            //game.GameModel.Update();
            //game.Scene.Update(gameTime);

        }
        public override void StartNormalLevel()
        {
            game.CurrgameState = new PlayGameState(game, this);
        }
        public override void Draw(GameTime gameTime)
        {

            //game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            Logo.Draw(spriteBatch, new Vector2(200, 200));
            //spriteBatch.DrawString(font, "Normal Level, Press(F1)", new Vector2(250, 300), Color.White);
            //spriteBatch.DrawString(font, "Random Level, Press(F2)", new Vector2(250, 330), Color.White);
            //spriteBatch.DrawString(font, "Play Last time saved level, Press(3)", new Vector2(250, 360), Color.White);
            //spriteBatch.DrawString(font, "Press Q to Exit", new Vector2(250, 390), Color.White);
            spriteBatch.End();
            //game.Scene.Draw(gameTime);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                spriteBatch.Dispose();
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
