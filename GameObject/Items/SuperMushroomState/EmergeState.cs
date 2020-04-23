using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

using MahJong.Enums;

namespace MahJong.GameObject.Items.SuperMushroomState
{
    internal class EmergeState : SuperMushroomState
    {
        public EmergeState(SuperMushroom superMushroom)
            : base(superMushroom)
        {

        }

        public override void Enter(ISuperMushroomState previousSuperMushroomState)
        {

        }

        public override void Exit()
        {
            superMushroom.Velocity = new Vector2(0.0f, 0.0f);
        }

        public override void Moving()
        {
            Exit();
            superMushroom.States[SuperMushroomStates.Moving].Enter(this);
        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
