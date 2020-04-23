using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Json;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject
{
    internal interface IGameObject : ICollidable
    {
        Rectangle Boundary { get; }
        Vector2 Velocity { get; set; }
        Boolean Grounded { get; set; }


        void Update(GameTime gametime);
        void Draw( SpriteBatch spriteBatch);
        void DrawBorderRectangles(SpriteBatch spriteBatch);
    }
}
