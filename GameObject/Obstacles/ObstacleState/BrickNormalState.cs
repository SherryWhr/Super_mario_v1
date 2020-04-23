using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.GameObject.Mario.PowerUpState;

namespace MahJong.GameObject.Obstacles
{
    internal class BrickNormalState : BrickBlockState
    {

        public BrickNormalState(BrickBlock brickBlock) :
            base(brickBlock)
        {
        }

        public override void Hidden()
        {
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Hidden];
        }



        public override void Bump(Mario.Mario mario)
        {
            if (mario.CurrentPowerUpState is NormalState)
            {
                brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Bump];
            }
            else if (!(mario.CurrentPowerUpState is DeadState))
            {
                brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Explode];
            }
        }
        public override void ToUsed()
        {
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Used];
        }

        public override void Update()
        {
            brickBlock.IsHidden = false;
            if (brickBlock.IsUsed)
                ToUsed();
        }
    }
}