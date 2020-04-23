﻿


using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;

using MahJong.GameObject.Mario.PowerUpState;

namespace MahJong.GameObject.Mario.ActionState
{
    internal class JumpState : ActionState
    {
        //private GraphicsDeviceManager graphics = MarioGame.Mariogame.Graphics;

        public JumpState(Mario marioSprite) :
            base(marioSprite)
        {
        }
        public override void Enter(IActionState previousActionState)
        {
            CurrentActionState = this;
            mario.CurrentActionState = this;
            this.previousActionState = previousActionState;
            MarioDirection facing = mario.FacingDirection;
            mario.FacingDirection = facing;
            mario.Velocity = new Vector2(mario.Velocity.X, Const.JUMP_VELOCITY);

            if (mario.CurrentPowerUpState is NormalState)
            {
                MarioGame.Mariogame.SoundManager.PlayStandardJumpSound();
            }
            else
            {
                MarioGame.Mariogame.SoundManager.PlaySuperJumpSound();
            }
        }
        public override void Exit()
        {
        }
        public override void Flag()
        {
            Exit();
            mario.ActionStates[MarioAction.Flag].Enter(this);
        }

        public override void Idle()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }
        public override void Crouch()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }

        public override void Bounce()
        {
            mario.ActionStates[MarioAction.Bouncing].Enter(this);
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
            Exit();
            mario.ActionStates[MarioAction.Fall].Enter(previousActionState);
        }
        public override void FaceLeftDiscontinued()
        {
            mario.Acceleration = new Vector2(0.0F, mario.Acceleration.Y);
           // mario.Velocity = new Vector2(0.0F, mario.Velocity.Y);
            if ( previousActionState is MoveState )
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

            int MinY = 0;
            //if (mario.Velocity <= 0)

            if (mario.Location.Y >= MinY)
            {
                //if (mario.FacingDirection == MarioDirection.Right)
                //mario.Location = new Vector2(mario.Location.X + mario.Velocity.X, mario.Location.Y - mario.Velocity.Y);
                //else
                //mario.Location = new Vector2(mario.Location.X - mario.Velocity.X, mario.Location.Y - mario.Velocity.Y);
            }
            float vy = mario.Velocity.Y;

            vy = vy + Const.GRAVITY * deltatime / 2;

            float vx = mario.Velocity.X;
            vx = vx + mario.Acceleration.X * deltatime;

            if (vx > Const.VELOCITY_MAX_LR)
                vx = Const.VELOCITY_MAX_LR;
            else if (vx < -Const.VELOCITY_MAX_LR)
                vx = -Const.VELOCITY_MAX_LR;

            if (mario.Velocity.Y > 0)
                Fall();
            //Debug.WriteLine("mario.Velocity.X");
            //Debug.WriteLine("vy");
            //Console.WriteLine(vx);
            mario.Velocity = new Vector2(vx, vy);
        }

        public override void CollideOnBottom(IGameObject obj)
        {

        }
    }
}