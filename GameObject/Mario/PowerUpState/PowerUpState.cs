using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.GameObject.Items;

namespace MahJong.GameObject.Mario.PowerUpState
{
    internal interface IPowerUpState
    {
        void DamagedState();
        void SuperState();
        void StarState();
        void FireState();
        void NormalState();
        void ThrowFireBall();
        void Update();
        void ChangeState(IGameObject obj);

    }



    internal abstract class PowerUpState : IPowerUpState
    {

        protected Mario mario;
        public PowerUpState(Mario mario)
        {
            this.mario = mario;
        }
        public virtual void DamagedState()
        {
            //do noting
        }
        public virtual void SuperState()
        {
            //do noting
        }
        public virtual void StarState()
        {
            //do noting
        }
        public virtual void FireState()
        {
            //do noting
        }
        public virtual void NormalState()
        {
           
        }
        public virtual void ThrowFireBall()
        {

        }

        public abstract void Update();

        public void ChangeState(IGameObject obj)
        {
            if (obj is SuperMushroom)
                SuperState();
            else if (obj is FireFlower)
                FireState();
            else if (obj is Starman)
            {
                StarState();
            }
        }
    }
}
