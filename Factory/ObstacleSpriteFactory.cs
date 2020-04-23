using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject;
using MahJong.GameObject.Sprites;



namespace MahJong.Factory
{
    internal class ObstacleSpriteFactory : SpriteFactory
    {
        private ObstacleSpriteFactory() { }

        public static ISprite BuildObstacle(String Obstacle)
        {
            switch (Obstacle)
            {
                case "Floor":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/FloorBlock"), new Point(1, 1), false, 1, 0.9f, 300);

                case "Pyramid":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/PyramidBlock"), new Point(1, 1), false, 1, 0.9f, 300);

                case "Used":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/UsedBlock"), new Point(1, 1), false, 1, 0.9f, 300);

                case "Hidden":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/HiddenBlock"), new Point(1, 1), false, 1, 0.9f, 300);

                default:
                    return null;

            }
        }
    }


}
