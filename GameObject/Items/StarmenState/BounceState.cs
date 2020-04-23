using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.StarmenState
{
    internal class BounceState: StarmenState
    {
        public BounceState(Starman starman)
            : base(starman)
        {

        }
        public override void Enter(IStarmenState preState)
        {
            //currState = this;
            starman.CurrState = this;
            starman.Velocity = new Vector2(starman.Velocity.X, Const.BOUNCE_Y_VELOCITY);
        }

        public override void Fall()
        {
            Exit();
            starman.States[StarmanState.Fall].Enter(this);
        }

        public override void Update(float deltatime)
        {
            starman.Velocity = new Vector2(starman.Velocity.X, starman.Velocity.Y + Const.ITEM_GRAVITY * deltatime);
            if (starman.Velocity.Y >= 0)
                Fall();
        }
    }
}
