using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles
{
    internal class QuestionHiddenState : QuestionBlockState
    {

        public QuestionHiddenState(QuestionBlock questionBlock) :
            base(questionBlock)
        {
        }
        public override void Show()
        {
            
        }

        public override void Hidden()
        {
            //do noting
        }

        public override void Bump(Mario.Mario mario)
        {
            if (mario.Velocity.Y <= 0)
            {
                questionBlock.CurrentQuestionBlockState = questionBlock.QuestionBlockStates[QuestionState.Used];
                if (!questionBlock.IsUsed)
                    questionBlock.ReleaseNextItem();
            }
        }


        public override void Update()
        {

        }
    }
}