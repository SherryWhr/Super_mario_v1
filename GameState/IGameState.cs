using MahJong.GameObject.Mario;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameState
{
    internal interface IGameState
    {
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);
        void Pause();
        void PlayerDead();
        void PlayerWin();
        void GameOver();
        void Underground();
        void TimesUp();
    }

    internal abstract class BaseGameState : IGameState
    {
        protected MarioGame game;
        protected Mario Mario { get; }
        //public IGameState CurrState;

        public BaseGameState(MarioGame game)
        {
            this.game = game;
            Mario = game.GameModel.Mario;
            //CurrState = this;
            
        }

        public virtual void Draw(GameTime gameTime)
        {

            game.Scene.Draw(gameTime);
        }

        public virtual void GameOver()
        {
            
        }


        public virtual void Pause()
        {
            
        }

        public virtual void PlayerDead()
        {
           
        }

        public virtual void PlayerWin()
        {
            
        }

        public virtual void Underground()
        {
           
        }

        public virtual void TimesUp()
        {

        }

        public abstract void Update(GameTime gameTime);

    }

}
