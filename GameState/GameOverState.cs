using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameState
{
    internal class GameOverState: BaseGameState, IDisposable
    {
        private SpriteBatch spriteBatch;
        private SpriteFont font;
        public GameOverState(MarioGame game)
        : base(game)
        {
            game.Control.RemapControllers();
            font = game.Content.Load<SpriteFont>("Arial");
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
        }
        public override void Update(GameTime gameTime)
        {
            //game.Control.Update(gameTime);
            game.GameModel.Update( );
            game.Scene.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            //game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "GameOver", new Vector2(250, 300), Color.White);
            spriteBatch.DrawString(font, "Press R to Restart, Press Q to Exit", new Vector2(250, 330), Color.White);
            spriteBatch.End();
            game.Scene.Draw(gameTime);
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
