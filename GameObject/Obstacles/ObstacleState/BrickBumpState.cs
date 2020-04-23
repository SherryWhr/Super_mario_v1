using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles.ObstacleState
{

    class BrickBumpState : BrickBlockState
    {
        private Vector2 iniPosition ;
        private int upCount = 0;
        private int downCount = 0;
        private int maxCount = 4;
        private int yChange = 3;
        public BrickBumpState(BrickBlock brickBlock) 
            : base(brickBlock)
        {
            iniPosition = brickBlock.Location;
        }

        public override void Show()
        {
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Normal];
        }

        public override void Bump(Mario.Mario mario)
        {
            
        }

        public override void Hidden()
        {

        }

        public override void ToUsed()
        {
            brickBlock.Velocity = new Vector2(0, 0);
            brickBlock.CurrentBrickBlockState = brickBlock.BrickBlockStates[BrickState.Used];

        }

        public override void Update()
        {
            brickBlock.Velocity = new Vector2(0, 1);
            if ((upCount < maxCount) && (downCount < maxCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                brickBlock.Location.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxCount) && (upCount >= maxCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                brickBlock.Location.Y += yChange;
                downCount++;
            }
            else
            {
                brickBlock.Location.Y = iniPosition.Y;
                upCount = 0;
                downCount = 0;
                Show();
            }
            if (brickBlock.IsUsed)
                ToUsed();
        }
    }
}
