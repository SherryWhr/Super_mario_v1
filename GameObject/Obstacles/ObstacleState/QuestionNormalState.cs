using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.GameObject.Mario;

namespace MahJong.GameObject.Obstacles
{
    internal class QuestionNormalState : QuestionBlockState
    {

        public QuestionNormalState(QuestionBlock questionBlock) :
            base(questionBlock)
        {

        }
        public override void Bump(Mario.Mario mario)
        {
           questionBlock.CurrentQuestionBlockState = questionBlock.QuestionBlockStates[QuestionState.Bump];
           if (!questionBlock.IsUsed)
                questionBlock.ReleaseNextItem();
        }

        public override void ToUsed()
        {
            questionBlock.CurrentQuestionBlockState = questionBlock.QuestionBlockStates[QuestionState.Used];
        }


        public override void Update()
        {

        }
    }
}