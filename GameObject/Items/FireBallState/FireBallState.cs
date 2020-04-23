using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.FireBallState
{
    internal interface IFireBallState
    {
        void Enter();
        void Fall();
        void Bounce();
        void Update(float deltaTime);
    }
    
    internal abstract class FireBallState : IFireBallState
    {
        protected FireBall fb;

        public FireBallState(FireBall fb)
        {
            this.fb = fb;
        }

        public abstract void Enter();

        public virtual void Bounce()
        {
        }

        public virtual void Fall()
        {
        }

        public abstract void Update(float deltaTime);
    }
}
