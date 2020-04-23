using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.Enums;
using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.OneUpMushroomState
{
    internal class EmergeState : OneUpMushroomState
    {
        public EmergeState(OneUpMushroom oneUpMushroom)
            : base(oneUpMushroom)
        {

        }

        public override void Enter(IOneUpMushroomState previousOneUpMushroomState)
        {

        }

        public override void Exit()
        {
            oneUpMushroom.Velocity = new Vector2(0.0f, 0.0f);
        }

        public override void Moving()
        {
            Exit();
            oneUpMushroom.States[OneUpMushroomStates.Moving].Enter(this);
        }
        public override void Update(GameTime gameTime)
        {

        }
    }
}
