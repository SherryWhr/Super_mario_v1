using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.GameObject.Sprites;
namespace MahJong.GameObject.Obstacles
{

    internal abstract class QuestionBlockState : IBlockState
    {

        protected QuestionBlock questionBlock;
        public QuestionBlockState(QuestionBlock questionBlock)
        {
            this.questionBlock = questionBlock;
        }

        public virtual void Show()
        {
            //do noting
        }

        public virtual void Hidden()
        {
            //do noting
        }

        public virtual void Bump(Mario.Mario mario)
        {
            //do noting
        }
        public virtual void ToUsed()
        {
            //do noting
        }

        public abstract void Update();
    }
}

