using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.SuperMushroomState
{
    class MovingState : SuperMushroomState
    {
        public MovingState(SuperMushroom superMushroom)
            : base(superMushroom)
        {

        }
        public override void Enter(ISuperMushroomState previousSuperMushroomState)
        {
            superMushroom.CurrentState = this;
            float direction = MarioGame.Mariogame.GameModel.Mario.Location.X - superMushroom.Location.X;
            direction = direction / Math.Abs(direction);
            superMushroom.Velocity = new Vector2(direction * 100.0f, 0.0f);
        }

        public override void Exit()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (!superMushroom.Grounded)
                superMushroom.Velocity = new Vector2(superMushroom.Velocity.X, Const.ITEM_GRAVITY);
        }
    }
}
