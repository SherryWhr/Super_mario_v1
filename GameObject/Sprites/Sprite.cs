using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MahJong.GameObject.Sprites
{
    internal class Sprite : ISprite
    {
        public float LayerDepth;
        public Color Color { get; set; }
        private Texture2D texture;
        private Point sheetSize;
        public Point frameSize { get; }
        private Point currentFrame;
        private Rectangle sourceRectangle;

        private bool isAnimated;
        private int frameNumber;
        private float timeSinceLastFrame;
        private float milliSecondsPerFrame;


        public Sprite(Texture2D texture, Point sheetSize, bool isAnimated, int frameNumber = 1, float layerdepth = 0.5f, float milliSecondsPerFrame = 500)
        {
            this.texture = texture;
            this.sheetSize = sheetSize;
            this.frameSize = new Point(texture.Width / this.sheetSize.X, texture.Height / sheetSize.Y);
            this.currentFrame = new Point(0, 0);
            this.sourceRectangle = new Rectangle(0, 0, frameSize.X, frameSize.Y);
            Color = Color.White;
            this.isAnimated = isAnimated;
            this.frameNumber = frameNumber;
            this.timeSinceLastFrame = 0;
            this.milliSecondsPerFrame = milliSecondsPerFrame;
            LayerDepth = layerdepth;
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            sourceRectangle.X = currentFrame.X * frameSize.X;
            sourceRectangle.Y = currentFrame.Y * frameSize.Y;
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y - frameSize.Y), sourceRectangle, 
                Color, 0f, Vector2.Zero, 1f, SpriteEffects.None, LayerDepth);
        }

        public void Animated()
        {
            isAnimated = true;
        }

        public void Update(GameTime gameTime)
        {
            if (isAnimated)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > milliSecondsPerFrame)
                {
                    timeSinceLastFrame -= milliSecondsPerFrame;
                    currentFrame.X += 1;
                    if (currentFrame.X == frameNumber)
                    {
                        currentFrame.X = 0;
                    }
                }
            }
        }

    }
}
