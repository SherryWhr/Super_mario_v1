﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject.Mario.MarioSprites
{
    internal class IdleMarioSprite : BaseSprite
    {
        public IdleMarioSprite(Texture2D texture, Point sheetSize) : base(texture, sheetSize)
        {
            sourceRectangle = new Rectangle(0, 0, frameSize.X, frameSize.Y);
            currentFrame = new Point(0, 1);
        }

        public override void Update(GameTime gameTime)
        {
            // Do Nothing
        }
    }
}
