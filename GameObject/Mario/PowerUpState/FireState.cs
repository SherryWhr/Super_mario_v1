using MahJong.Factory;
using MahJong.GameObject.Items;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.PowerUpState
{
    internal class FireState : PowerUpState
    {
        private MarioGame game = MarioGame.Mariogame;
        public FireState(Mario mario) :
            base(mario)
        {
        }

        public override void DamagedState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
        }
        public override void StarState()
        {
            mario.CurrentPowerUpState = new StarState(mario, this);
        }
        public override void NormalState()
        {
            mario.CurrentPowerUpState = mario.PowerUpStates[MarioPowerUp.Normal];
        }
        public override void ThrowFireBall()
        {

            float startX = mario.FacingDirection == MarioDirection.Left ? mario.Boundary.Left : mario.Boundary.Right;

            IGameObject fireball = EntitiesFactory.GetEntities("FireBall", game, new Vector2(startX, mario.Location.Y - 30f));

            game.GameModel.AddGameObject(fireball);
            mario.Map.Add(fireball);                    
        }

        public override void Update()
        {

        }
    }
}
