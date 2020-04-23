using System.Diagnostics;

using Microsoft.Xna.Framework;

using MahJong.GameObject.Obstacles;

namespace MahJong.GameObject.Mario.ActionState
{

    internal class CrouchState : ActionState
    {
        private bool inTransition = false;
        private Vector2 preTransitionLocation;
        private Pipe pipe;
        //private GraphicsDeviceManager graphics = MarioGame.Mariogame.Graphics;
        public CrouchState(Mario mario) :
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

        }
        public override void Idle()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }

        public override void Jump()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }
        public override void FaceLeft()
        {
            mario.FacingDirection = MarioDirection.Left;
        }
        public override void FaceRight()
        {
            mario.FacingDirection = MarioDirection.Right;
        }
        public override void CrouchDiscontinued()
        {
            Exit();
            mario.ActionStates[MarioAction.Idle].Enter(this);
        }

        public override void Update(float deltatime)
        {
            if (inTransition)
            {
                if (mario.Location.Y - preTransitionLocation.Y > 5)
                {
                    if (pipe.IsSecret)
                    {
                        MarioGame.Mariogame.Control.EnterExitHiddenArea();
                        mario.Location = new Vector2(pipe.Target.X * Const.GRID_HEIGHT, pipe.Target.Y * Const.GRID_HEIGHT);
                        Exit();
                        mario.ActionStates[MarioAction.Fall].Enter(this);
                        inTransition = false;
                    }
                    else
                    {
                        mario.Location = new Vector2(pipe.Target.X * Const.GRID_HEIGHT, pipe.Target.Y * Const.GRID_HEIGHT);
                        inTransition = false;
                    }
                }
            }
            else
            {
                mario.Velocity = new Vector2(0f, mario.Velocity.Y + Const.GRAVITY * deltatime);
                if (!mario.Grounded)
                    Fall();
            }
        }

        public override void CollideOnBottom(IGameObject obj)
        {
            mario.Velocity = new Vector2(0, 0);
            if (obj is Pipe && (obj as Pipe).IsWarp)
            {
                Debug.WriteLine("Warp Pipe triggered");
                //mario.Grounded = false;
                mario.Velocity = new Vector2(0.0f, 50.0f);
                //mario.Location = new Vector2(mario.Location.X, mario.Location.Y + 2.0f);
                inTransition = true;
                preTransitionLocation = new Vector2(mario.Location.X, mario.Location.Y);
                pipe = (obj as Pipe);
            }
            else
            {
                mario.Location.Y = obj.Boundary.Top;
            }
        }

        public override void CollideOnTop(IGameObject obj)
        {

        }
    }
}
