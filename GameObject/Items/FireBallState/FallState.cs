using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Enums;
using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.FireBallState
{
    internal class FallState : FireBallState
    {
        public FallState(FireBall fb) :
            base(fb)
        {
        }

        public override void Enter()
        {
            fb.CurrState = this;
        }

        public override void Bounce()
        {
            fb.States[FireBallStates.Bounce].Enter();
        }

        public override void Update(float deltaTime)
        {
            fb.Velocity = new Vector2(fb.Velocity.X, fb.Velocity.Y + Const.ITEM_GRAVITY * deltaTime);
            if (fb.Grounded)
                Bounce();
        }
    }
}
