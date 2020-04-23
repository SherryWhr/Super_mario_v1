using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject.Sprites;
using MahJong.GameObject.Obstacles;
using MahJong.GameObject.Obstacles.ObstacleState;
using MahJong.Enums;

namespace MahJong.Factory
{
    internal class QuestionBlockSpriteFactory : SpriteFactory
    {
        private QuestionBlockSpriteFactory() { }
        //private static QuestionBlockSpriteFactory _instance;

        //public static QuestionBlockSpriteFactory Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new QuestionBlockSpriteFactory();
        //        return _instance;
        //    }
        //}
        public static int BrickType(IBlockState currentState)
        {
            int type = 0;
            if (currentState is QuestionNormalState)
                type = (int)QuestionState.Normal;
            else
            if (currentState is QuestionHiddenState)
                type = (int)QuestionState.Hidden;
            else
            if (currentState is QuestionUsedState)
                type = (int)QuestionState.Used;
            else
            if (currentState is QuestionBumpState)
                type = (int)BrickState.Bump;

            return type;

        }

        public static ISprite BuildQuestionBlock(IBlockState questionBlockState)
        {
            QuestionState currState = (QuestionState) BrickType(questionBlockState);
            String resourceString = "blocks/";
            int frameNumber = currState == QuestionState.Normal ? 3 : 1;

            if (currState == QuestionState.Normal)
            {
                resourceString += "QuestionBlock";
            }
            else
            if (currState == QuestionState.Used)
            {
                resourceString += "UsedBlock";
            }
            else
            if (currState == QuestionState.Hidden)
            {
                resourceString += "HiddenBlock";
            }
            return new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber, 1),
                currState == QuestionState.Normal,
                frameNumber, 0.5f,500);
        }
    }
}