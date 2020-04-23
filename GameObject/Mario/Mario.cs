using System;
using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject.Mario.ActionState;
using MahJong.GameObject.Mario.PowerUpState;
using MahJong.GameObject.Obstacles;
using MahJong.Factory;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Items;
using MahJong.Enums;
using MahJong.Tools;

namespace MahJong.GameObject.Mario 
{
    internal class Mario: BaseCollideObject
    {
        public Dictionary<MarioPowerUp, IPowerUpState> PowerUpStates { get; }
        public Dictionary<MarioAction, IActionState> ActionStates { get; }
        public IPowerUpState CurrentPowerUpState { get; set; }
        public IActionState CurrentActionState { get; set; }
        public IPowerUpState StateBeforeStar;
        public MarioDirection FacingDirection = MarioDirection.Right;
        //public int direction;
        //public bool isMoving;
        private IActionState preactionState;
        private IPowerUpState prepowerUpState;
        private MarioDirection preFacingDirection;
        //private MarioSpriteFactory marioSpriteFactory;

        public Mario(MarioGame game, Vector2 location)
            :base(game, location)
        {
            CurrentActionState = new IdleState(this);
            CurrentPowerUpState = new NormalState(this);
            Velocity = new Vector2(0, 0);
            Acceleration = new Vector2(0, 400);

            PowerUpStates = new Dictionary<MarioPowerUp, IPowerUpState>
            {
                { MarioPowerUp.Dead, new DeadState(this) },
                { MarioPowerUp.Normal, new NormalState(this) },
                { MarioPowerUp.Super, new SuperState(this) },
                { MarioPowerUp.Fire, new FireState(this) }

            };
            ActionStates = new Dictionary<MarioAction, IActionState>
            {
                { MarioAction.Idle, new IdleState(this) },
                { MarioAction.Move, new MoveState(this) },
                { MarioAction.Jump, new JumpState(this) },
                { MarioAction.Crouch, new CrouchState(this) },
                { MarioAction.Fall, new FallingState(this)},
                { MarioAction.Bouncing, new BouncingState(this) },
                { MarioAction.Flag, new FlagState(this) }
            };
            this.Location = location;
            preactionState = CurrentActionState;
            prepowerUpState = CurrentPowerUpState;
            preFacingDirection = FacingDirection;
            currSprite = MarioSpriteFactory.BuildMario(CurrentActionState, CurrentPowerUpState, MarioDirection.Right, this);
            Size = MarioSpriteFactory.Instance.GetSize(CurrentActionState, CurrentPowerUpState, this);
            collisionBoxColor = CollisionBoxColor.Yellow;
        }

        public void GetDamaged()
        {
            CurrentPowerUpState.DamagedState();
        }

        public void Crouch()
        {
            CurrentActionState.Crouch();
        }

        public void Fall()
        {
            CurrentActionState.Fall();
        }

        public void Idle()
        {
            CurrentActionState.Idle();
        }
        public void Flag()
        {
            CurrentActionState.Flag();
        }
        public void Jump()
        {
            CurrentActionState.Jump();
        }

        //public void Move()
        //{
        //    //FacingDirection = MarioDirection.Left;
        //    CurrentActionState.Move();
        //}

        public void FaceLeft()
        {
            CurrentActionState.FaceLeft();
        }
        public void FaceRight()
        {
            CurrentActionState.FaceRight();
        }
        public void FaceLeftDiscontinued()
        {
            CurrentActionState.FaceLeftDiscontinued();
        }
        public void FaceRightDiscontinued()
        {
            CurrentActionState.FaceRightDiscontinued();
        }
        //public void CrouchDiscontinued()
        //{
        //    CurrentActionState.CrouchDiscontinued();
        //}
        public void ThrowFireBall()
        {
            CurrentPowerUpState.ThrowFireBall();
        }
        public void NormalState()
        {
            CurrentPowerUpState.NormalState();
        }
        public void SuperState()
        {
            CurrentPowerUpState.SuperState();
        }

        public void Bounce()
        {           
            CurrentActionState.Bounce();
        }

        public void FairState()
        {
            CurrentPowerUpState.FireState();
        }

        public void StarState()
        {
            StateBeforeStar = CurrentPowerUpState;
            currSprite.Color = Color.Green;
            CurrentPowerUpState.StarState();
        }

        public override void Update(GameTime gameTime)
        {
            float deltatime = (float) gameTime.ElapsedGameTime.TotalSeconds;
            int minX = 0;
            int maxX = Map.FieldSizeX * Const.GRID_WIDTH;
            int minY = (Map.SizeY + 2) * Const.GRID_HEIGHT;

            CurrentActionState.Update(deltatime);
            CurrentPowerUpState.Update();
            
            if (prepowerUpState != CurrentPowerUpState || preactionState != CurrentActionState || preFacingDirection != FacingDirection )
            {
                UpdateSprite();
                preactionState = CurrentActionState;
                prepowerUpState = CurrentPowerUpState;
                preFacingDirection = FacingDirection;
            }
            currSprite.Update(gameTime);
            Location += Velocity * deltatime;

            if (Location.X < minX)
            {
 
                Location = new Vector2(0, Location.Y);

            }
                
                
            else if (Location.X + Boundary.Width > maxX)
            {

                Location = new Vector2(maxX - Boundary.Width, Location.Y);

            }
                           

            if (Boundary.Bottom > minY && (Boundary.Top < minY))
            {
                GetDamaged();
                MarioGame.Mariogame.SoundManager.PlayFallSound();
            }

            Map.Update(this);
        }

        private void UpdateSprite()
        {

            currSprite = MarioSpriteFactory.BuildMario(CurrentActionState, CurrentPowerUpState, FacingDirection, this);
            Size = MarioSpriteFactory.Instance.GetSize(CurrentActionState, CurrentPowerUpState,this);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!(CurrentPowerUpState is StarState))
                currSprite.Color = Color.White;
            currSprite.Draw(spriteBatch, Location);

        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is IItem)
                CurrentPowerUpState.ChangeState(b);
            else if (b is IBlock)
            {
                IBlock tmp = b as IBlock;
                if (!tmp.IsHidden)
                {
                    CurrentActionState.CollideOnBottom(b);                   
                }
            }
            else
            {
                if (b is IEnemy)
                {
                    MarioGame.Mariogame.SoundManager.PlayStompSound();
                    Location.Y = b.Boundary.Top;
                    Velocity = new Vector2(Velocity.X, 0);
                    Bounce();
                }
                else
                {
                    CurrentActionState.CollideOnBottom(b);
                }
                    
            }
        }

        public override void CollideOnTop(IGameObject b)
        {
            if (b is IItem)
                CurrentPowerUpState.ChangeState(b);
            else if (b is IBlock)
            {
                IBlock tmp = b as IBlock;
                if (!tmp.IsHidden && Velocity.Y < 0)
                    CurrentActionState.CollideOnTop(b);
            }
            else
            {
                if (b is IEnemy && !((Enemy)b).IsDefeated())
                    GetDamaged();
                else if (b is IEnemy && ((Enemy)b).IsDefeated())
                    return;

                CurrentActionState.CollideOnTop(b);
            }
            //Debug.WriteLine($"Mario Collided On Top with {DebugUtilities.GetGameObjectType(b).ToString()}");
           // Console.WriteLine(CurrentActionState);
        }

        public override void CollideOnLeft(IGameObject b)
        {
            if (b is IItem)
            {
                if (b is Flag)
                {
                    Flag();
                    CurrentActionState.CollideOnLeft(b);
                }
                else
                    CurrentPowerUpState.ChangeState(b);
            }   
            else if (b is IBlock)
            {
                IBlock tmp = b as IBlock;
                if (!tmp.IsHidden)
                    CurrentActionState.CollideOnLeft(b);
            }
            else
            {
                if (b is IEnemy && !((Enemy)b).IsDefeated())
                    GetDamaged();
                else if (b is IEnemy && ((Enemy)b).IsDefeated())
                    return;

                CurrentActionState.CollideOnLeft(b);
            }
            //.WriteLine($"Mario Collided On Left with {DebugUtilities.GetGameObjectType(b).ToString()}");
           // Console.WriteLine(CurrentActionState);
        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is IItem)
            {
                if (b is Flag)
                {
                    Flag();
                    CurrentActionState.CollideOnRight(b);
                }
                else
                CurrentPowerUpState.ChangeState(b);
            }
            else if (b is IBlock)
            {
                IBlock tmp = b as IBlock;
                if (!tmp.IsHidden)
                    CurrentActionState.CollideOnRight(b);

            }
            else
            {
                if (b is IEnemy && !((Enemy)b).IsDefeated())
                    GetDamaged();
                else if (b is IEnemy && ((Enemy)b).IsDefeated())
                    return;

                CurrentActionState.CollideOnRight(b);
            }
            //Debug.WriteLine($"Mario Collided On Right with {DebugUtilities.GetGameObjectType(b).ToString()}");
            Console.WriteLine(CurrentActionState);
        }
    }
}
