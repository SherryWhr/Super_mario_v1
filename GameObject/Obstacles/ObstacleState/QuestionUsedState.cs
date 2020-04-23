using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Obstacles
{
    internal class QuestionUsedState : QuestionBlockState
    {

        public QuestionUsedState(QuestionBlock questionBlock) :
            base(questionBlock)
        {
        }

        public override void Update()
        {
            questionBlock.IsHidden = false;
        }
    }
}