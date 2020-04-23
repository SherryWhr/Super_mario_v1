using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject.Mario.MarioSprites
{
    internal class WalkingMarioSprite : BaseSprite
    {
        public WalkingMarioSprite(Texture2D texture, Point sheetSize) : base(texture, sheetSize)
        {
            sourceRectangle = new Rectangle(0, 0, frameSize.X, frameSize.Y);
            currentFrame = new Point(4, 1);
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                //currPowerUpState.Update();
                currentFrame.X -= 1;
                if (currentFrame.X == 0)
                {
                    currentFrame.X = 4;
                }
            }
        }
    }
}
