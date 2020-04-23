using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.physics
{
    internal class Physics
    {

        public Vector2 Velocity;

        public Vector2 Acceleration;

        public Vector2 Location;

        public Physics(Vector2 velocity, Vector2 acceleration, Vector2 location)
        {
            Velocity = velocity;
            Acceleration = acceleration;
            Location = location;

        }

        public void ApplyAccel(Vector2 delta)
        {
            Acceleration += delta;
        }

        public void ApplyGravity(float gravity = Const.GRAVITY)
        {
            ApplyAccel(new Vector2(0, gravity));
        }
        public void OnSimulation(GameTime time)
        {
            double deltatime = time.ElapsedGameTime.TotalSeconds / 1000;
            Velocity += Acceleration * (float)deltatime;
            if (Velocity.X > Const.VELOCITY_MAX_LR)
            {
                Velocity.X = Const.VELOCITY_MAX_LR;
            }
            else if (Velocity.X < -Const.VELOCITY_MAX_LR)
            {
                Velocity.X = -Const.VELOCITY_MAX_LR;
            }

            if (Velocity.Y > Const.VELOCITY_MAX_UD)
            {
                Velocity.Y = Const.VELOCITY_MAX_UD;
            }
            else if (Velocity.Y < -Const.VELOCITY_MAX_UD)
            {
                Velocity.Y = -Const.VELOCITY_MAX_UD;
            }
        }

    }
}
