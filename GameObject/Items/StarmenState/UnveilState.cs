using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.StarmenState
{
    internal class UnveilState : StarmenState
    {
        public UnveilState(Starman starman)
            : base(starman)
        {
            starman.Velocity = new Vector2(0.0f, -Const.STAR_VELC_H);
            //iniPosition = starman.Location;
            //movePosition = starman.Location;
        }

        public override void Enter(IStarmenState preState)
        {
            //currState = this;
            starman.CurrState = this;
        }

        public override void Bounce()
        {
            float direction = MarioGame.Mariogame.GameModel.Mario.Location.X - starman.Location.X;
            direction = direction / Math.Abs(direction);
            starman.Velocity = new Vector2(Const.MUSHROOM_VELOCITY_H * direction, 0);
            starman.States[StarmanState.Bounce].Enter(this);
        }

        public override void Fall()
        {
            
        }

        public override void Update(float deltatime)
        {
            //if (movePosition.Y < iniPosition.Y - 22.0f)
            //if (movePosition.Y - iniPosition.Y < -22)
            //    Move();
            //else
            //{
                //movePosition.Y -= yChange;
                //upCount++;
            //}
            //starman.Location = movePosition;

        }
    }
}
