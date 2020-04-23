
namespace MahJong.GameObject.Mario.PowerUpState
{
    internal class DeadState : PowerUpState
    {
        public DeadState(Mario mario) :
            base(mario)
        {

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
