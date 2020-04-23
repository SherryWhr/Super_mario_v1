using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.ActionState
{
    class BouncingState : ActionState
    {
        public BouncingState(Mario mario)
            : base(mario)
        {
        }

        public override void Enter(IActionState previousActionState)
        {
            CurrentActionState = this;
            mario.CurrentActionState = this;
            this.previousActionState = previousActionState;
            MarioDirection facing = mario.FacingDirection;
            mario.FacingDirection = facing;
            mario.Velocity = new Vector2(mario.Velocity.X, Const.BOUNCE_Y_VELOCITY);
        }

        public override void Exit()
        {
        }

        public override void FaceLeft()
        {
            if (mario.FacingDirection == MarioDirection.Right)
            {
                mario.FacingDirection = MarioDirection.Left;
                //mario.Velocity = new Vector2(0f, mario.Velocity.Y);
                mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            }
            else
            {
                mario.Acceleration = new Vector2(-Const.H_ACCEL, mario.Acceleration.Y);
            }
        }
        public override void FaceRight()
        {
            if (mario.FacingDirection == MarioDirection.Left)
            {
                mario.FacingDirection = MarioDirection.Right;
                // mario.Velocity = new Vector2(0f, mario.Velocity.Y);
                mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            }
            else
            {
                mario.Acceleration = new Vector2(Const.H_ACCEL, mario.Acceleration.Y);
            }
            //mario.Acceleration = new Vector2(Const.H_ACCEL, mario.Acceleration.Y);
        }
        public override void Fall()
        {
            previousActionState = mario.ActionStates[MarioAction.Idle];
            mario.ActionStates[MarioAction.Fall].Enter(previousActionState);
        }
        public override void FaceLeftDiscontinued()
        {
            mario.Acceleration = new Vector2(0.0F, mario.Acceleration.Y);
            // mario.Velocity = new Vector2(0.0F, mario.Velocity.Y);
            if (previousActionState is MoveState)
                previousActionState = mario.ActionStates[MarioAction.Idle];
        }
        public override void FaceRightDiscontinued()
        {
            mario.Acceleration = new Vector2(0.0F, mario.Acceleration.Y);
            //mario.Velocity = new Vector2(0.0F, mario.Velocity.Y);
            if (previousActionState is MoveState)
                previousActionState = mario.ActionStates[MarioAction.Idle];
        }

        public override void Update(float deltatime)
        {
            float vy = mario.Velocity.Y;

            vy = vy + Const.GRAVITY * deltatime;

            float vx = mario.Velocity.X;
            vx = vx + mario.Acceleration.X * deltatime;

            if (vx > Const.VELOCITY_MAX_LR)
                vx = Const.VELOCITY_MAX_LR;
            else if (vx < -Const.VELOCITY_MAX_LR)
                vx = -Const.VELOCITY_MAX_LR;

            if (mario.Velocity.Y > 0)
                Fall();

            mario.Velocity = new Vector2(vx, vy);
        }

        public override void CollideOnBottom(IGameObject obj)
        {

        }
    }
}
