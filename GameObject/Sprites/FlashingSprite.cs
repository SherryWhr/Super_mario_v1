using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Sprites
{
    internal class FlashingSprite: Sprite
    {
        private Texture2D texture;
        private Point sheetSize;
        private Point currentFrame;
        private Rectangle sourceRectangle;

        private bool isAnimated;
        private int frameNumber;
        private float timeSinceLastFrame;
        private float milliSecondsPerFrame;

        private Color color;
        private readonly Random random;
        public FlashingSprite(Texture2D texture, Point sheetSize, bool isAnimated, int frameNumber = 1, float milliSecondsPerFrame = 500)
            : base(texture, sheetSize, isAnimated, frameNumber, milliSecondsPerFrame)
        {
            random = new Random();
        }
        private void ChangeColor(Color newColor)
        {
            color = newColor;
        }
        public override void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            ChangeColor(new Color(random.Next(255), random.Next(255), random.Next(255)));
            sourceRectangle.X = currentFrame.X * frameSize.X;
            sourceRectangle.Y = currentFrame.Y * frameSize.Y;
            spriteBatch.Draw(texture, position, sourceRectangle, color, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);


        }

    }
}
