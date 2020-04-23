using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.PowerUpState
{
    internal class SuperState : PowerUpState
    {
        public SuperState(Mario mario) :
            base(mario)
        {
        }

        public override void DamagedState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
        }

        public override void FireState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Fire];
        }

        public override void StarState()
        {
            mario.CurrentPowerUpState = new StarState(mario, this);
        }
        public override void NormalState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
        }

        public override void Update()
        {
            
        }
    }
}
