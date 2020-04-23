using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Mario.ActionState
{
    internal interface IActionState
    {
        void Enter(IActionState previousActionState);
        void Exit();
        void Idle();
        void Crouch();
        void Move();
        void Jump();
        void Bounce();

        void Flag();
        void Fall();
        void Update(float deltatime);
        void FaceLeft();
        void FaceRight();
        void FaceLeftDiscontinued();
        void FaceRightDiscontinued();
        void CrouchDiscontinued();
        void CollideOnBottom(IGameObject obj);
        void CollideOnTop(IGameObject obj);
        void CollideOnLeft(IGameObject obj);
        void CollideOnRight(IGameObject obj);
    }


    internal abstract class ActionState : IActionState
    {
        protected Mario mario;
        protected IActionState previousActionState;
        protected IActionState CurrentActionState { set { mario.CurrentActionState = value; } }
        //public IActionState PreviousActionState { get { return previousActionState; } }
        public ActionState(Mario mario)
        {
            this.mario = mario;
        }

        public virtual void Crouch()
        {
            // do nothing on default
        }

        public virtual void Fall()
        {
            // do nothing on default
        }
        public virtual void Flag()
        {
            // do nothing on default
        }
        public virtual void Idle()
        {
            // do nothing on default
        }

        public virtual void Jump()
        {
            // do nothing on default
        }

        public virtual void Move()
        {
            // do nothing on default
        }

        public virtual void Bounce()
        {

        }

        public virtual void FaceLeft()
        {

        }
        public virtual void FaceRight()
        {
            // do nothing on default
        }
         public virtual void FaceLeftDiscontinued()
        {
            // do nothing on default
        }
        public virtual  void FaceRightDiscontinued()
        {
            // do nothing on default
        }
        public virtual void CrouchDiscontinued()
        {
            // do nothing on default
        }

        public abstract void Update(float deltatime);

        public abstract void Enter(IActionState newPreviousActionState);

        public abstract void Exit();

        public void CollideOnLeft(IGameObject obj)
        {
            if (mario.Velocity.X < 0)
            {
                mario.Location.X = obj.Boundary.Right;
                mario.Velocity = new Vector2(0, mario.Velocity.Y);
                
            }
        }

        public void CollideOnRight(IGameObject obj)
        {
            if (mario.Velocity.X > 0)
            {
                mario.Location.X = obj.Boundary.Left - mario.Boundary.Width;
                mario.Velocity = new Vector2(0, mario.Velocity.Y);
                
            }
        }

        public virtual void CollideOnBottom(IGameObject obj)
        {
            mario.Location.Y = obj.Boundary.Top;
            mario.Velocity = new Vector2(mario.Velocity.X, 0);            
            Exit();
        }

        public virtual void CollideOnTop(IGameObject obj)
        {
            mario.Location.Y = obj.Boundary.Bottom + mario.Boundary.Height;
            mario.Velocity = new Vector2(mario.Velocity.X, 0);
            Fall();
        }        
    }
}
