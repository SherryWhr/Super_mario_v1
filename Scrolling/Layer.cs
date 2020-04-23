using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.Scrolling
{
   internal class Layer
    {
        public Layer(Camera camera)
        {
            _camera = camera;
            Parallax = Vector2.One;
            Sprites = new List<Sprite>();
        }

        public Vector2 Parallax { get; set; }
        public List<Sprite> Sprites { get; private set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.GetViewMatrix(Parallax));
            foreach (Sprite sprite in Sprites)
                sprite.Draw(spriteBatch, new Vector2(0, 500));
            spriteBatch.End();
        }

        private readonly Camera _camera;
    }
}
