using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MahJong.GameObject.Sprites
{
    internal interface ISprite
    {

        Point frameSize { get; } //size of the Object
        Color Color { get; set; }
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 position);
        void Animated();
    }
}
