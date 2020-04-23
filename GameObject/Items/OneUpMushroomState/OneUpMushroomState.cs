using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Items.OneUpMushroomState
{
    internal interface IOneUpMushroomState
    {
        void Enter(IOneUpMushroomState previousSuperMushroomState);
        void Exit();
        void Hidden();
        void Emerge();
        void Moving();
        void Update(GameTime gameTime);
    }

    internal abstract class OneUpMushroomState : IOneUpMushroomState
    {
        protected OneUpMushroom oneUpMushroom;

        public OneUpMushroomState(OneUpMushroom oneUpMushroom)
        {
            this.oneUpMushroom = oneUpMushroom;
        }

        public abstract void Enter(IOneUpMushroomState previousOneUpMushroomState);

        public abstract void Exit();

        public virtual void Hidden()
        {
            // Do Nothing in default
        }

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
