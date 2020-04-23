
using MahJong.Factory;
using Microsoft.Xna.Framework;
using System;

namespace MahJong.GameObject.Mario.ActionState
{
    internal class MoveState : ActionState
    {
        //private GraphicsDeviceManager graphics = MarioGame.Mariogame.Graphics;
        public MoveState(Mario mario) :
            base(mario)
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
        }

        public override void Fall()
        {
            this.Exit();
            mario.ActionStates[MarioAction.Fall].Enter(this);
        }

        public override void Crouch()
        {
            this.Exit();
            mario.ActionStates[MarioAction.Crouch].Enter(this);
        }

        public override void Jump()
        {
            this.Exit();
            
            mario.ActionStates[MarioAction.Jump].Enter(this);
        }

        public override void Idle()
        { 
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }

        public override void FaceLeft()
        {
            if (mario.FacingDirection == MarioDirection.Left)
                mario.Acceleration = new Vector2(-Const.H_ACCEL, mario.Acceleration.Y);
            else
            {
                mario.FacingDirection = MarioDirection.Left;
                Idle();
            }
            

        }
        public override void Flag()
        {
            Exit();
            mario.ActionStates[MarioAction.Flag].Enter(this);
        }

        public override void FaceRight()
        {
            if (mario.FacingDirection == MarioDirection.Right)
                mario.Acceleration = new Vector2(Const.H_ACCEL, mario.Acceleration.Y);
            else
            {
                mario.FacingDirection = MarioDirection.Right;
                Idle();
            }
            
        }
        public override void FaceLeftDiscontinued()
        {
            Idle();
        }
        public override void FaceRightDiscontinued()
        {
            Idle();
        }

        public override void Update(float deltatime)
        {
            //int MinX = 0;
            //int MaxX = graphics.GraphicsDevice.Viewport.Width - mario.Size.X;

            float vx = mario.Velocity.X;

            vx = vx + mario.Acceleration.X * deltatime;

            if (vx > Const.VELOCITY_MAX_LR)
                vx = Const.VELOCITY_MAX_LR;
            else if (vx < -Const.VELOCITY_MAX_LR)
                vx = -Const.VELOCITY_MAX_LR;

            mario.Velocity = new Vector2(vx, mario.Velocity.Y);

            if (!mario.Grounded)
               Fall();
        }

        public override void CollideOnBottom(IGameObject obj)
        {
            mario.Location.Y = obj.Boundary.Top;
            mario.Velocity = new Vector2(mario.Velocity.X, 0);
        }
    }
}
