using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.Factory;
using MahJong.GameObject.Sprites;
using MahJong.GameObject.Obstacles;
using MahJong.GameObject.Items;
using MahJong.GameObject.Enemies.EnemyActionState;


namespace MahJong.GameObject.Enemies
{
    class ZombiePrincess : Enemy
    {
        //private GoombaSpriteFactory goombaSpriteFactory;
        // In sprint 2, suppose game level is always normal
        // private EnemyLevel enemyLevel = EnemyLevel.Normal;

        private Pipe pipe;
        public ZombiePrincess(MarioGame game, Vector2 location)
            : base(game, location)
        {          
            currSprite = ZombiePrincessSpriteFactory.BuildZombiePrincess();
            offset = 0;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            Velocity = new Vector2(0, 0);
            notMove = true;
            CurrentActionState = EnemyActionStates[EnemyAction.MoveUp];
            preactionState = CurrentActionState;
        }

        public void SetOffset(int offset)
        {
            this.offset = offset;
        }

        public void SetPipe(Pipe pipe)
        {
            this.pipe = pipe;
        }

        public bool IsViewable()
        {
            Debug.Write(pipe.IsViewable());
            return pipe.IsViewable();
        }

        public bool IsStatic()
        {
            if (CurrentActionState == EnemyActionStates[EnemyAction.MoveUp])
            {
                return this.Location.Y <= (pipe.Location.Y - pipe.Size.Y);
            }
            
            return this.Location.Y - this.Size.Y > (pipe.Location.Y - pipe.Size.Y / 2);
            

        }

        public bool IsInThePipe()
        {
            return this.Location.Y - this.Size.Y > (pipe.Location.Y - pipe.Size.Y);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (CurrentActionState is DefeatedState)
            {
                currSprite = GoombaSpriteFactory.BuildGoomba(EnemyLevel.Hidden, EnemyAction.Defeated);
            }

            currSprite.Update(gameTime);
            Map.Update(this);
        }

        private void DetectCollision(IGameObject b)
        {
            if (b is Mario.Mario)
            {
                Mario.Mario mario = b as Mario.Mario;
                if (mario.CurrentPowerUpState is Mario.PowerUpState.StarState)
                {
                    this.GetDamaged();
                }
            } else if (b is FireBall)
            {
                this.GetDamaged();
            }
        }

        public override void CollideOnBottom(IGameObject b)
        {
            DetectCollision(b);
        }

        public override void CollideOnTop(IGameObject b)
        {
            DetectCollision(b);
        }

        public override void CollideOnLeft(IGameObject b)
        {
            DetectCollision(b);
        }

        public override void CollideOnRight(IGameObject b)
        {
            DetectCollision(b);
        }
       
        public void MoveUp()
        {
            CurrentActionState.MoveUp();
        }

        public void MoveDown()
        {
            CurrentActionState.MoveDown();
        }

    }
}
