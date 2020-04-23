using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles.ObstacleState
{
    class BrickExplodeState : BrickBlockState
    {
        public BrickExplodeState(BrickBlock brickBlock) :
          base(brickBlock)
        {
           
        }

        public override void Show()
        {

        }

        public override void Bump(Mario.Mario mario)
        {

        }

        public override void Hidden()
        {

        }

        public override void Update()
        {
            brickBlock.Remove();
        }
    }
}
