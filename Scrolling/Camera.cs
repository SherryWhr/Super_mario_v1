using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.Scrolling
{
    internal class Camera
    {
        private readonly Viewport viewport;
        public Rectangle Limits { get; set; }
        private Vector2 origin;
        public Vector2 position;
        private float zoom;
        private float rotation;

        //public Vector2 MarioPos = new Vector2(0,0);

        public Camera(Viewport viewport, Point fieldSize)
        {
            this.viewport = viewport;
            //limits = new Rectangle(new Point(0, 0), fieldSize);
            Limits = new Rectangle(
                0, 0,
                Math.Max(viewport.Width, fieldSize.X * Const.GRID_WIDTH), 
                Math.Max(viewport.Height, fieldSize.Y * Const.GRID_HEIGHT
                ));
            origin = new Vector2(this.viewport.Width / 1.0f, this.viewport.Height / 1.0f);
            zoom = 1.0f;
            rotation = 0.0f;
        }

        public Matrix GetViewMatrix(Vector2 parallax)
        {
            return Matrix.CreateTranslation(new Vector3(-position * parallax, 0.0f)) *
                   Matrix.CreateTranslation(new Vector3(-origin, 0.0f)) *
                   Matrix.CreateRotationZ(rotation) *
                   Matrix.CreateScale(zoom, zoom, 1.0f) *
                   Matrix.CreateTranslation(new Vector3(origin, 0.0f));
        }

        public void LookAt(Vector2 newPosition)
        {
            newPosition = newPosition - new Vector2(viewport.Width / 2.0f, viewport.Height / 2.0f);

            //Debug.WriteLine($"Camera log - Position: {this.position.X}, {this.position.Y}");
            //Debug.WriteLine($"Limits: {limits.X}, {limits.Y} {limits.Width}, {limits.Height}");
            //Debug.WriteLine($"Viewport size: {viewport.Width}, {viewport.Height}");

            this.position.X = MathHelper.Clamp(newPosition.X, Limits.X, Limits.X + Limits.Width - viewport.Width);
            this.position.Y = MathHelper.Clamp(newPosition.Y, Limits.Y, Limits.Y + Limits.Height - viewport.Height);

            //Debug.WriteLine($"Camera log - Limited Position: {this.position.X}, {this.position.Y}");
        }
    }
}

