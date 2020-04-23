

using MahJong.Factory;
using Microsoft.Xna.Framework;
using System;

namespace MahJong.GameObject.Mario.ActionState
{
    internal class IdleState : ActionState
    {
        public IdleState(Mario marioSprite)
            :base(marioSprite)
        {

        }
        //protected Boolean NormalDescent;
        public override void Enter(IActionState previousActionState)
        {
            CurrentActionState = this;
            mario.CurrentActionState = this;
            this.previousActionState = previousActionState;
            MarioDirection facing = mario.FacingDirection;
            //mario.currSprite = MarioSpriteFactory.BuildMario(CurrentActionState, mario.CurrentPowerUpState, facing);
            mario.FacingDirection = facing;
            mario.Acceleration = new Vector2(0f, Const.GRAVITY);
            mario.Velocity = new Vector2(0f, mario.Velocity.Y);
        }
        public override void Exit()
        {
           
        }
        public override void Crouch()
        {
            this.Exit();
            mario.ActionStates[MarioAction.Crouch].Enter(this);
        }

        public override void Fall()
        {
            this.Exit();
            mario.ActionStates[MarioAction.Fall].Enter(this);
        }

        

        public override void Jump()
        {
            mario.ActionStates[MarioAction.Jump].Enter(this);
        }

        public override void FaceLeft()
        {
            if (mario.FacingDirection == MarioDirection.Left)
                Move();
            else
                mario.FacingDirection =MarioDirection.Left;
            
        }
        
        public override void FaceRight()
        {
            if (mario.FacingDirection == MarioDirection.Right)
                Move();
            else
                mario.FacingDirection = MarioDirection.Right;
        }


        public override void Move()
        {
            mario.ActionStates[MarioAction.Move].Enter(this);
        }

        public override void Update(float deltatime)
        {
            //do nothing
            mario.Velocity *= 0.95f;
            if (!mario.Grounded)
                Fall();
        }

    }
}
