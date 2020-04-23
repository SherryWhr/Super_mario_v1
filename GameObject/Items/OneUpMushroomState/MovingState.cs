using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items.OneUpMushroomState
{
    class MovingState : OneUpMushroomState
    {
        public MovingState(OneUpMushroom oneUpMushroom)
            : base(oneUpMushroom)
        {

        }
        public override void Enter(IOneUpMushroomState previousOneUpMushroomState)
        {
            oneUpMushroom.CurrentState = this;
            float direction = MarioGame.Mariogame.GameModel.Mario.Location.X - oneUpMushroom.Location.X;
            direction = -direction / Math.Abs(direction);
            oneUpMushroom.Velocity = new Vector2(direction * Const.MUSHROOM_VELOCITY_H, 0.0f);
        }

        public override void Exit()
        {

        }
        public override void Update(GameTime gameTime)
        {
            if (!oneUpMushroom.Grounded)
                oneUpMushroom.Velocity = new Vector2(oneUpMushroom.Velocity.X, Const.ITEM_GRAVITY);

        }
    }
}
