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
    internal class ItemSpriteFactory : SpriteFactory
    {
        private ItemSpriteFactory() { }

        public static ISprite BuiildItem(String item)
        {
            switch (item)
            {
                case "Star":
                    return new Sprite(game.Content.Load<Texture2D>("Star"), new Point(4, 1), true, 4, 0.6f, 300);

                case "Coin":
                    return new Sprite(game.Content.Load<Texture2D>("Coin"), new Point(3, 1), true, 3, 0.6f, 300);

                case "Flower":
                    return new Sprite(game.Content.Load<Texture2D>("Flower"), new Point(4, 1), true, 4, 0.6f, 300);

                case "OneUpMushroom":
                    return new Sprite(game.Content.Load<Texture2D>("GreenMushroom"), new Point(1, 1), false, 1, 0.9f, 500);

                case "SuperMushroom":
                    return new Sprite(game.Content.Load<Texture2D>("RedMushroom"), new Point(1, 1), false, 1, 0.9f, 500);
                case "JumpCoin":
                    return new Sprite(game.Content.Load<Texture2D>("CoinDisappearing"), new Point(4, 1), true, 4, 0.9f, 50);
                case "pipe":
                    return new Sprite(game.Content.Load<Texture2D>("pipeLarge"), new Point(1, 1), false, 1, 0, 300);
                case "fireball":
                    return new Sprite(game.Content.Load<Texture2D>("Fireball"), new Point(4, 1), true, 4, 0.5f, 50);
                case "upleft":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/RightPiece"), new Point(1, 1), false, 1,0.5f, 300);
                case "upright":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/LeftPiece"), new Point(1, 1), false, 1, 0.5f, 300);
                case "lowleft":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/LeftPiece"), new Point(1, 1), false, 1, 0.5f, 300);
                case "lowright":
                    return new Sprite(game.Content.Load<Texture2D>("blocks/RightPiece"), new Point(1, 1), false, 1, 0.5f, 300);
                case "flags":
                    return new Sprite(game.Content.Load<Texture2D>("flags"), new Point(5, 1), false, 5, 0.9f, 300);
                default:
                    return null;

            }
        }
    }


}
