using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.Enums;
using MahJong.GameObject;
using MahJong.GameObject.Mario;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Items;
using MahJong.GameObject.Obstacles;

namespace MahJong.Tools
{
    internal static class DebugUtilities
    {
        public static GameObjects? GetGameObjectType(IGameObject obj)
        {
            GameObjects? ret;
            if (obj is Mario)
                ret = GameObjects.Mario;
            else if (obj is Goomba)
                ret = GameObjects.Goomba;
            else if (obj is KoopaTroopa)
                ret = GameObjects.KoopaTroopa;
            else if (obj is FireBall)
                ret = GameObjects.FireBall;
            else if (obj is FireFlower)
                ret = GameObjects.FireFlower;
            else if (obj is NormalCoin)
                ret = GameObjects.NormalCoin;
            else if (obj is OneUpMushroom)
                ret = GameObjects.OneUpMushroom;
            else if (obj is Starman)
                ret = GameObjects.Starman;
            else if (obj is SuperMushroom)
                ret = GameObjects.SuperMushroom;
            else if (obj is BrickBlock)
                ret = GameObjects.BrickBlock;
            else if (obj is FloorBlock)
                ret = GameObjects.FloorBlock;
            else if (obj is Pipe)
                ret = GameObjects.Pipe;
            else if (obj is PyramidBlock)
                ret = GameObjects.PyramidBlock;
            else if (obj is QuestionBlock)
                ret = GameObjects.QuestionBlock;
            else if (obj is UsedBlock)
                ret = GameObjects.UsedBlock;
            else
                ret = null;

            return ret;
        }
    }
}
