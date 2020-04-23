using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.StarmenState
{
    internal interface IStarmenState
    {
        void Unveil();
        void Fall();
        void Bounce();
        void Enter(IStarmenState preState);
        void Exit();
        void Update(float deltatime);
    }
    internal abstract class StarmenState: IStarmenState
    {
        protected Starman starman;
        //protected IStarmenState currState;
        public StarmenState(Starman starman)
        {
            this.starman = starman;
        }

        public virtual void Enter(IStarmenState preState)
        {
            //currState = this;
        }
        public virtual void Exit()
        {
            //previousActionState.Enter(this);
        }
        public virtual void Bounce()
        {
            
        }

        public virtual void Fall()
        {
            
        }

        public virtual void Unveil()
        {
            
        }

        public abstract void Update(float deltatime);

    }
}
