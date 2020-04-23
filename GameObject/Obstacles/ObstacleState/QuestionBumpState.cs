using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Obstacles.ObstacleState
{
    class QuestionBumpState : QuestionBlockState
    {
        private Vector2 iniPosition;
        private int upCount = 0;
        private int downCount = 0;
        private int maxCount = 4;
        private int yChange = 3;
        public QuestionBumpState(QuestionBlock questionBlock) :
            base(questionBlock)
        {
            iniPosition = questionBlock.Location;

        }

        public override void Show()
        {
            questionBlock.CurrentQuestionBlockState = questionBlock.QuestionBlockStates[QuestionState.Normal];
        }

        public override void ToUsed()
        {
            questionBlock.CurrentQuestionBlockState = questionBlock.QuestionBlockStates[QuestionState.Used];
        }

        public override void Update()
        {
            if ((upCount < maxCount) && (downCount < maxCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                questionBlock.Location.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxCount) && (upCount >= maxCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                questionBlock.Location.Y += yChange;
                downCount++;
            }
            else
            {
                questionBlock.Location.Y = iniPosition.Y;
                upCount = 0;
                downCount = 0;
                if (questionBlock.IsUsed)
                {
                    ToUsed();
                }
                else
                {
                    Show();
                }
            }

        }
    }
}
