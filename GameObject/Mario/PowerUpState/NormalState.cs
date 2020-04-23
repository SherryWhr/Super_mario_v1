using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Sound;

namespace MahJong.GameObject.Mario.PowerUpState
{
    internal class NormalState : PowerUpState
    {
        public NormalState(Mario mario )
            :base(mario)
        {
        }

        public override void DamagedState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Dead];
            SoundManager.Instance.PlayDieSound();
            SoundManager.Instance.StopAllSound();
            MarioGame.Mariogame.SoundManager.PlayDieSound();
            //do not change below
            GameProperties.Instance.lives -= 1;
            MarioGame.Mariogame.PlayerDead();
            
        }

        public override void SuperState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Super];
        }
        public override void FireState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Super];
        }

        public override void StarState()
        {
            mario.CurrentPowerUpState = new StarState(mario, this);
        }

        public override void Update()
        {
          
        }
    }
}
