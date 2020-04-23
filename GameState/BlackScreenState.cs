using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameState
{

    internal class BlackScreenState : BaseGameState, IDisposable
    {
        private int delay = 100;
        private int count = 0;
        //private IGameState pregameState;
        private ISprite Avartar;
        private SpriteBatch spriteBatch;
        private SpriteFont font;

        public BlackScreenState(MarioGame game, IGameState pregameState) :
            base(game)
        {
            //this.pregameState = pregameState;
            Avartar = new Sprite(game.Content.Load<Texture2D>("Mario/NormalIdleRightMario"), new Point(1, 1), false, 1, 0f, 500);
            spriteBatch = new SpriteBatch(game.GraphicsDevice);
            font = game.Content.Load<SpriteFont>("Arial");
            game.Control.RemapControllers();
        }

        public override void Update(GameTime gameTime)
        {
            game.Control.Update(gameTime);
            if (count > delay)
            {
                if (Mario.Location.X > Const.CK1)
                {
                    game.GameModel.startX = Const.CK1;
                }
                else if (Mario.Location.X > Const.CK2)
                {
                    game.GameModel.startX = Const.CK2;
                }

                game.ResetLevel();
                game.CurrgameState = new PlayGameState(game, this);

            }
            
            count++;

        }
        public override void Draw(GameTime gameTime)
        {
            //game.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            Avartar.Draw(spriteBatch, new Vector2(game.GraphicsDevice.Viewport.Width / 2, game.GraphicsDevice.Viewport.Height / 2));
            spriteBatch.End();
            game.Scene.Draw(gameTime);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose managed resources
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
