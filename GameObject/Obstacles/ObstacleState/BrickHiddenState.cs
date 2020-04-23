using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles
{
    internal class BrickHiddenState : BrickBlockState
    {

        public BrickHiddenState(BrickBlock brickBlock) :
            base(brickBlock)
        {
        }

        public override void Show()
        {
            
        }

        public override void Bump(Mario.Mario mario)
        {
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Normal];
        }

        public override void Update()
        {

        }
    }
}