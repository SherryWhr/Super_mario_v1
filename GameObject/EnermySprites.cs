using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.Sprites
{
    internal class Goomba : Sprite
    {
        private enum Movement { LeftStand, RightStand, LeftMoving, RightMoving }
        private enum States { Normal, Super, Fire, PowerUp }
        private Movement movement;
        private States state;

        public Goomba(Texture2D texture, Point frameSize, Point sheetSize, Vector2 position)
        {
            this.texture = game.Content.Load<Texture2D>("Goomba");
            this.frameSize = frameSize;
            this.sheetSize = sheetSize;
            this.position = position;
            this.movement = Movement.LeftStand;
            this.state = States.Normal;
        }

        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }
        }
        
    }

    internal class GreenKoopaTroopa : Sprite
    {
        private enum Movement { LeftStand, RightStand, LeftMoving, RightMoving }
        private enum States { Normal, Super, Fire, PowerUp }
        private Movement movement;
        private States state;

        public GreenKoopaTroopa(Texture2D texture, Point frameSize, Point sheetSize, Vector2 position)
        {
            this.texture = game.Content.Load<Texture2D>("Troopa");
            this.frameSize = frameSize;
            this.sheetSize = sheetSize;
            this.position = position;
            this.movement = Movement.LeftStand;
            this.state = States.Normal;
        }
        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }
        }
    }

    internal class RedKoopaTroopa : Sprite
    {
        private enum Movement { LeftStand, RightStand, LeftMoving, RightMoving }
        private enum States { Normal, Super, Fire, PowerUp }
        private Movement movement;
        private States state;

        public RedKoopaTroopa(MarioGame game, Vector2 position, Point sheetSize, Point frameSize)
        {
            this.texture = game.Content.Load<Texture2D>("Troopa");
            this.frameSize = frameSize;
            this.sheetSize = sheetSize;
            this.position = position;
            this.movement = Movement.LeftStand;
            this.state = States.Normal;
        }
        public override void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                ++currentFrame.X;
                if (currentFrame.X >= sheetSize.X)
                {
                    currentFrame.X = 0;
                }
            }
        }
    }
}
