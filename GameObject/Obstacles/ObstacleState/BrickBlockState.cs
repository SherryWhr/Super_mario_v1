using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles
{
    internal interface IBlockState
    {
        void Show();

        void Bump(Mario.Mario mario);

        void Hidden();

        void ToUsed();

        void Update();
    }

    internal abstract class BrickBlockState : IBlockState
    {

        protected BrickBlock brickBlock;
        public BrickBlockState(BrickBlock brickBlock)
        {
            this.brickBlock = brickBlock;
        }

        public virtual void Show()
        {
            //do noting
        }

        public virtual void Hidden()
        {
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Hidden];
        }

        public virtual void Bump(Mario.Mario mario)
        {
            //do noting
        }
        public virtual void ToUsed()
        {
           
        }
        public abstract void Update();

    }


}
