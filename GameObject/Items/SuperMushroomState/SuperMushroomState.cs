using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.SuperMushroomState
{
    internal interface ISuperMushroomState
    {
        void Enter(ISuperMushroomState previousSuperMushroomState);
        void Exit();
        void Emerge();
        void Moving();
        void Update(GameTime gameTime);
    }

    internal abstract class SuperMushroomState : ISuperMushroomState
    {
        protected SuperMushroom superMushroom;
        //public ISuperMushroomState PreviousMushroomState { get; set; }
        //public ISuperMushroomState CurrentMushroomState { get; set; }

        public SuperMushroomState(SuperMushroom superMushroom)
        {
            this.superMushroom = superMushroom;
        }

        public abstract void Enter(ISuperMushroomState previousSuperMushroomState);

        public abstract void Exit();

        public virtual void Emerge()
        {
            // Do Nothing in default
        }

        public virtual void Moving()
        {
            // Do Nothing in default
        }

        public abstract void Update(GameTime gameTime);
    }
}
