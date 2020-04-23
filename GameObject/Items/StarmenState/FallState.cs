using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.StarmenState
{
    internal class FallState : StarmenState
    {
        public FallState(Starman starman)
            : base(starman)
        {
           
        }

        public override void Enter(IStarmenState preState)
        {
            //currState = this;
            starman.CurrState = this;
        }

        public override void Bounce()
        {
            //Exit();
            starman.States[StarmanState.Bounce].Enter(this);           
        }

        public override void Update(float deltatime)
        {
            //Console.WriteLine(vy);   
            starman.Velocity = new Vector2(starman.Velocity.X, starman.Velocity.Y + Const.ITEM_GRAVITY * deltatime);
            if (starman.Grounded)
                Bounce();
        }
    }
}
