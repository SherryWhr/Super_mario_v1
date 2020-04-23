using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.ActionState
{
    internal class FallingState: ActionState
    {
        public FallingState(Mario mario) 
            :base(mario)
        {
        }
        public override void Enter(IActionState previousActionState)
        {
            CurrentActionState = this;
            mario.CurrentActionState = this;
            this.previousActionState = previousActionState;
            MarioDirection facing = mario.FacingDirection;
            // mario.currSprite = MarioSpriteFactory.BuildMario(CurrentActionState, mario.CurrentPowerUpState, facing);
            mario.FacingDirection = facing;

        }
        public override void Exit()
        {
            previousActionState.Enter(this);
            //physics
        }
        public override void Idle()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }
        public override void Crouch()
        {
            //Idle();   // Interrupt the Fall
        }

        public override void FaceLeft()
        {
            if (mario.FacingDirection == MarioDirection.Right)
            {
                mario.FacingDirection = MarioDirection.Left;
                mario.Velocity = new Vector2(0f, mario.Velocity.Y);
                mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            }
            else
            {
                // acceleration on +X
                mario.Acceleration = new Vector2(-Const.H_ACCEL, mario.Acceleration.Y);
            }
        }

        public override void FaceRight()
        {
            if (mario.FacingDirection == MarioDirection.Left)
            {
                mario.FacingDirection = MarioDirection.Right;
                mario.Velocity = new Vector2(0f, mario.Velocity.Y);
                mario.Acceleration = new Vector2(0, mario.Acceleration.Y);
            }
            else
            {
                mario.Acceleration = new Vector2(Const.H_ACCEL, mario.Acceleration.Y);
            }
        }
        public override void Flag()
        {
            Exit();
            mario.ActionStates[MarioAction.Flag].Enter(this);
        }

        public override void Bounce()
        {
            mario.ActionStates[MarioAction.Bouncing].Enter(this);
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
           // mario.Velocity = new Vector2(0.0F, mario.Velocity.Y);
            if (previousActionState is MoveState)
                previousActionState = mario.ActionStates[MarioAction.Idle];
        }

        public override void Update(float deltatime)
        {
            //mario.Location = new Vector2(mario.Location.X, mario.Location.Y + mario.Velocity.Y);
            //Console.WriteLine(mario.Velocity.Y);
            float vy = mario.Velocity.Y;
            //Console.WriteLine(mario.Acceleration.Y);
            vy = vy + mario.Acceleration.Y * deltatime;
            //Console.WriteLine(vy);
            float vx = mario.Velocity.X;
            vx = vx + mario.Acceleration.X * deltatime;
            if (vy < -Const.VELOCITY_MAX_UD)
                vy = -Const.VELOCITY_MAX_UD;

            if (vx > Const.VELOCITY_MAX_LR)
                vx = Const.VELOCITY_MAX_LR;
            else if (vx < -Const.VELOCITY_MAX_LR)
                vx = -Const.VELOCITY_MAX_LR;

            mario.Velocity = new Vector2(vx, vy);
        }
    }
}
