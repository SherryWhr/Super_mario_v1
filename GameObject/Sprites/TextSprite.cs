using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject.Sprites
{
    class TextSprite : ISprite
    {
        public Point frameSize { get; }
        public Color Color { get; set; }
        private float layerDepth;
        private readonly SpriteFont font;
        private readonly float fontSize;
        private readonly string text;

        public TextSprite(string text, SpriteFont font, float layerDepth = 0f, float fontSize = 18f) 
        {
            this.text = text;
            this.font = font;
            this.fontSize = fontSize;
            Color = Color.White;
            this.layerDepth = layerDepth;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.DrawString(
                font,
                text,
                position,
                Color,
                0f, //rotation
                new Vector2(), //origin
                fontSize / 18f, //scale
                SpriteEffects.None,
                layerDepth);
        }

        public void Update(GameTime gameTime)
        {
           
        }

        public void Animated()
        {
        }
    }
}

