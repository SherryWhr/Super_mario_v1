using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Enums;
using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.FireBallState
{
    internal class BounceState : FireBallState
    {

        public BounceState(FireBall fb) :
            base(fb)
        {
        }

        public override void Enter()
        {
            fb.CurrState = this;
            fb.Velocity = new Vector2(fb.Velocity.X, Const.FIREBALL_VELOCITY_V);
        }

        public override void Fall()
        {
            fb.States[FireBallStates.Fall].Enter();
        }

        public override void Update(float deltaTime)
        {
            fb.Velocity = new Vector2(fb.Velocity.X, fb.Velocity.Y + Const.ITEM_GRAVITY * deltaTime);
            if (fb.Velocity.Y >= 0)
                Fall();
        }
    }
}
