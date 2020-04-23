using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.ActionState
{
    internal class FlagState: ActionState
    {
        public FlagState(Mario mario)
        : base(mario)
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
            mario.Acceleration = new Vector2(0, Const.FLAG_ACCEL);
            mario.Velocity = new Vector2(0, mario.Velocity.Y/10);
        }
        public override void Exit()
        {
            //previousActionState.Enter(this);
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

        }

        public override void FaceRight()
        {

        }

        public override void Bounce()
        {
            
        }

        public override void FaceLeftDiscontinued()
        {

        }
        public override void FaceRightDiscontinued()
        {

        }

        public override void Update(float deltatime)
        {
            //mario.Location = new Vector2(mario.Location.X, mario.Location.Y + mario.Velocity.Y);
            //Console.WriteLine(mario.Velocity.Y);
            float vy = mario.Velocity.Y;
            //Console.WriteLine(mario.Acceleration.Y);
            vy = vy + mario.Acceleration.Y * deltatime;
            //Console.WriteLine(vy);
            float vx = 0;
  
            if (vy < -Const.VELOCITY_MAX_UD)
                vy = -Const.VELOCITY_MAX_UD;
            mario.Velocity = new Vector2(vx, vy);
        }
        public override void CollideOnBottom(IGameObject obj)
        {
            mario.Location.Y = obj.Boundary.Top;
            mario.Velocity = new Vector2(mario.Velocity.X, 0);
            MarioGame.Mariogame.CurrgameState.PlayerWin();
            Exit();
        }
    }
}
