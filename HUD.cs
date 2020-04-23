using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Factory;
using Microsoft.Xna.Framework;
using MahJong.GameObject;
using MahJong.GameState;
using MahJong.GameObject.Mario.ActionState;

namespace MahJong
{
    internal class HUD
    {
        #region TextSprites
        public TextSprite MARIO, WORLD, TIME, COIN;
        private SpriteFont font;
        #endregion
        ISprite Coin;
        Texture2D Mario;

        public HUD(MarioGame game)
        {
            MARIO = FontFactory.GetFont("MARIO");
            TIME = FontFactory.GetFont("TIME");
            WORLD = FontFactory.GetFont("WORLD");
            COIN = FontFactory.GetFont("X");
            font = MarioGame.Mariogame.Content.Load<SpriteFont>("Arial");
            Coin = ItemSpriteFactory.BuiildItem("Coin");
            Mario = game.Content.Load<Texture2D>("Mario/NormalIdleRightMario");
        
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            Coin.Draw(spriteBatch, new Vector2(Const.CS_X, Const.CS_Y));
            spriteBatch.Draw(Mario, new Vector2(Const.M_X, Const.M_Y), Color.White);
            MARIO.Draw(spriteBatch, new Vector2(Const.MAR_X, Const.MAR_Y));
            WORLD.Draw(spriteBatch, new Vector2(Const.WORLD_X, Const.WORLD_Y));
            TIME.Draw(spriteBatch, new Vector2(Const.T_X, Const.T_Y));
            COIN.Draw(spriteBatch, new Vector2(Const.C_X, Const.C_Y));
            COIN.Draw(spriteBatch, new Vector2(Const.MX_X, Const.C_Y));
            spriteBatch.DrawString(font, GameProperties.Instance.score.ToString(), new Vector2(Const.MAR_X, Const.TEXT_Y), Color.White);
            spriteBatch.DrawString(font, GameProperties.Instance.lives.ToString(), new Vector2(Const.MS_X, Const.M_Y), Color.White);
            spriteBatch.DrawString(font, GameProperties.Instance.coin.ToString(), new Vector2(Const.CN_X, Const.C_Y), Color.White);
            spriteBatch.DrawString(font, ((int)GameProperties.Instance.time).ToString(), new Vector2(Const.T_X, Const.TEXT_Y), Color.White);
            spriteBatch.DrawString(font, "1--1", new Vector2(Const.WORLD_X, Const.TEXT_Y), Color.White);
            if (MarioGame.Mariogame.CurrgameState is BlackScreenState)
            {
                spriteBatch.DrawString(font, "X" + GameProperties.Instance.lives.ToString(), new Vector2(MarioGame.Mariogame.GraphicsDevice.Viewport.Width / 2 + 45, MarioGame.Mariogame.GraphicsDevice.Viewport.Height / 2 - 32), Color.White);
            }
            spriteBatch.End();

        }

    }
}
