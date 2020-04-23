using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Factory;
using MahJong.Sound;
using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Mario.PowerUpState
{
    internal class StarState : PowerUpState
    {
        private MarioGame game = MarioGame.Mariogame;
        private IPowerUpState previousPowerUpState;
        private int timeLimit = 1000;
        private int count = 0;
        public StarState(Mario mario, IPowerUpState previousPowerUpState) :
            base(mario)
        {
            this.previousPowerUpState = previousPowerUpState;
        }
        public override void NormalState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
            SoundManager.Instance.PlayMainThemeSound();
        }
        public void Exit()
        {
            if (previousPowerUpState is NormalState)
                mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
            else if(previousPowerUpState is SuperState)
                mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Super];
            else if(previousPowerUpState is FireState)
                mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Fire];
            

        }

        public override void DamagedState()
        {
           // mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Star];
        }
        public override void ThrowFireBall()
        {
            if (previousPowerUpState is FireState) {
                float startX = mario.FacingDirection == MarioDirection.Left ? mario.Boundary.Left : mario.Boundary.Right;

                IGameObject fireball = EntitiesFactory.GetEntities("FireBall", game, new Vector2(startX, mario.Location.Y - 30f));

                game.GameModel.AddGameObject(fireball);
                mario.Map.Add(fireball);
            }
         
        }

        public override void Update()
        {
            if (count > timeLimit)
                Exit();

            count++;
        }
    }
}
