using MahJong.GameObject;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Items;
using MahJong.GameObject.Obstacles;
using Microsoft.Xna.Framework;

namespace MahJong.Factory
{
    // Singleton Entities Factory
    class EntitiesFactory
    {     
        private EntitiesFactory()
        {

        }

        public static IGameObject GetEntities(string type, MarioGame game, Vector2 location, bool isHidden, int coinNum, string itemType)
        {
            switch (type)
            {
                case "BrickBlock":
                    return new BrickBlock(game, location, isHidden, coinNum);
                case "QuestionBlock":
                    return new QuestionBlock(game, location, isHidden, coinNum, itemType);
                default:
                    return null;
            }

        }
        public static IGameObject GetEntities(string type, MarioGame game, Vector2 location)
        {
            switch (type)
            {
                case "Goomba":
                    return new Goomba(game, location);
                case "KoopaTroopa":
                    return new KoopaTroopa(game, location);
                case "UsedBlock":
                    return new UsedBlock(game, location);
                case "FloorBlock":
                    return new FloorBlock(game, location);
                case "PyramidBlock":
                    return new PyramidBlock(game, location);
                //case "Pipe":
                //    return new Pipe(game, location);
                case "SuperMushroom":
                    return new SuperMushroom(game, location);
                case "OneUpMushroom":
                    return new OneUpMushroom(game, location);
                case "FireFlower":
                    return new FireFlower(game, location);
                case "Starman":
                    return new Starman(game, location);
                case "NormalCoin":
                    return new NormalCoin(game, location);
                case "JumpCoin":
                    return new JumpCoin(game, location);
                case "FireBall":
                    return new FireBall(game, location);
                case "Flag":
                    return new Flag(game, location);
                default:
                    return null;
            }
        }

    }
}
