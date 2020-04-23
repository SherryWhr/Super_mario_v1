 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.GameObject.Sprites;
using MahJong.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject
{
    internal abstract class BaseCollideObject : IGameObject, IDisposable
    {
        public Vector2 Velocity { get; set; }
        public Map Map { get; set; }
        public Boolean Grounded { get; set; }

        public Vector2 Location;
        protected int offset = 0;
        protected Texture2D pixel;
        public ISprite currSprite;
        public Point Size;
        public Vector2 Acceleration;
        public MarioGame Game;

        public Rectangle Boundary
        {
            get
            {
                return new Rectangle((int)Location.X - offset, (int)Location.Y - Size.Y, Size.X + 2 * offset, Size.Y);
            }
        }

        protected enum CollisionBoxColor
        {
            Green,
            Red,
            Yellow,
            Blue
        }
        protected CollisionBoxColor collisionBoxColor = CollisionBoxColor.Blue;

        protected BaseCollideObject(MarioGame game, Vector2 Location)
        {
            this.Location = Location;
            pixel = new Texture2D(game.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            pixel.SetData(new[] { Color.White });
            Map = game.Map;
            Grounded = false;
            Game = game;
        }

        protected void DrawBorder(SpriteBatch spriteBatch, Rectangle rectangleToDraw, Color borderColor, 
            int thicknessOfBorder = 2)
        {
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, 
                rectangleToDraw.Width, thicknessOfBorder), borderColor);

            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, rectangleToDraw.Y, 
                thicknessOfBorder, rectangleToDraw.Height), borderColor);

            spriteBatch.Draw(pixel, new Rectangle((rectangleToDraw.X + rectangleToDraw.Width - thicknessOfBorder), 
                rectangleToDraw.Y, thicknessOfBorder, rectangleToDraw.Height), borderColor);
            spriteBatch.Draw(pixel, new Rectangle(rectangleToDraw.X, 
                rectangleToDraw.Y + rectangleToDraw.Height - thicknessOfBorder, rectangleToDraw.Width,
                thicknessOfBorder), borderColor);
        }

        public virtual void CollideOnBottom(IGameObject b)
        {
        }

        public virtual void CollideOnTop(IGameObject b)
        {
        }

        public virtual void CollideOnLeft(IGameObject b)
        {
        }

        public virtual void CollideOnRight(IGameObject b)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public void DrawBorderRectangles(SpriteBatch spriteBatch)
        {
            Color color = Color.Red;
            if (collisionBoxColor == CollisionBoxColor.Blue)
            {
                color = Color.Blue;
            } else if (collisionBoxColor == CollisionBoxColor.Green)
            {
                color = Color.Green;
            }
            else if (collisionBoxColor == CollisionBoxColor.Yellow)
            {
                color = Color.Yellow;
            }

            DrawBorder(spriteBatch, Boundary, color);
        }

        public virtual void Update(GameTime gametime)
        {
            
        }

        public void Dispose()
        {
            pixel.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
