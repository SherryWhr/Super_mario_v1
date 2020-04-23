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

namespace MahJong.Factory
{
    internal class BrickSpriteFactory : SpriteFactory
    {
        private BrickSpriteFactory () { }

        public static int BrickType(IBlockState currentState)
        {
            int type = 0;
            if (currentState is BrickNormalState)
                type = (int) BrickState.Normal;
            else
            if (currentState is BrickHiddenState)
                type = (int) BrickState.Hidden;
            else
            if (currentState is BrickExplodeState)
                type = (int) BrickState.Explode;
            else
            if (currentState is BrickBumpState)
                type = (int) BrickState.Bump;
            else
            if (currentState is BrickUsedState)
                type = (int) BrickState.Used;
            return type;

        }

        public static ISprite BuildBrick( IBlockState currentState)
        {
            String resourceString = "blocks/";
            BrickState state = (BrickState)BrickType(currentState);
            if (state == BrickState.Normal)
            {
                resourceString += "BrickBlock";
            }
            else if (state == BrickState.Used)
            {
                resourceString += "UsedBlock";
            }
            else if (state == BrickState.Hidden)
            {
                resourceString += "HiddenBlock";
            }

            return new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(1, 1),
                false,
                1, 0.5f, 500);
        }
    }
}
