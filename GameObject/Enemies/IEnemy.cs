using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;

using MahJong.GameObject.Enemies.EnemyActionState;
using MahJong.GameObject.Obstacles;
using MahJong.GameObject.Items;

namespace MahJong.GameObject.Enemies
{
    internal interface IEnemy
    {
        void MoveLeft();
        void MoveRight();
        void GetDamaged();
        bool IsDefeated();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);

    }

    internal abstract class Enemy : BaseCollideObject, IEnemy
    {


        public EnemyDirection FacingDirection = EnemyDirection.Left;
        public Dictionary<EnemyAction, IEnemyActionState> EnemyActionStates { get; }
        public IEnemyActionState CurrentActionState { get; set; }
       
        //protected int offset = 3;
        protected IEnemyActionState preactionState;
        public MarioGame game;
        public bool notMove;


        public Enemy(MarioGame game, Vector2 location) :
            base(game, location)
        {
            this.game = game;
            
            Velocity = Location.X - Scene.camera.position.X >=
                    game.GraphicsDevice.Viewport.Width ? new Vector2(0, 0) : new Vector2(1, 0);
            notMove = Location.X - Scene.camera.position.X >= game.GraphicsDevice.Viewport.Width;

            EnemyActionStates = new Dictionary<EnemyAction, IEnemyActionState>
            {
                { EnemyAction.Defeated, new DefeatedState(this) },
                { EnemyAction.MoveLeft, new MovingLeftState(this) },
                { EnemyAction.MoveRight, new MovingRightState(this) },
                { EnemyAction.MoveUp, new MovingUpState(this)},
                { EnemyAction.MoveDown, new MovingDownState(this)},
                { EnemyAction.StayStatic, new StayStaticState(this)}
            };

            CurrentActionState = EnemyActionStates[EnemyAction.MoveLeft];
            collisionBoxColor = CollisionBoxColor.Red;
            //this.MoveLeft();
            
        }

        public bool IsDefeated()
        {
            //Debug.WriteLine(CurrentActionState is DefeatedState);
            return CurrentActionState is DefeatedState;
        }
       
        private void CollideFireBall(IGameObject b)
        {
            if (b is FireBall)
                GetDamaged();
        }

        private void CollideStarMario(IGameObject b)
        {
            if (b is Mario.Mario)
            {
                Mario.Mario mario = b as Mario.Mario;
                if (mario.CurrentPowerUpState is Mario.PowerUpState.StarState)
                {
                    this.GetDamaged();
                }
            }
        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is IBlock && !IsDefeated())
            {
                if (b.Velocity.Y != 0)
                    GetDamaged();
              
                Location = new Vector2(Location.X, b.Boundary.Top);
                Velocity = new Vector2(Velocity.X, 0);
       
            }
            CollideFireBall(b);
            CollideStarMario(b);
           // Debug.WriteLine("Enemy is Collided On Bottom: ");


        }

        public override void CollideOnTop(IGameObject b)
        {
            if (!IsDefeated() && b is Mario.Mario)
                this.GetDamaged();

            CollideFireBall(b);
            CollideStarMario(b);
            //Debug.WriteLine("Enemy is Collided On Top:");
        }

        public override void CollideOnLeft(IGameObject b)
        {
            if (b is IBlock || b is Pipe)
            {
                this.MoveRight();
               
            }
            CollideFireBall(b);
            CollideStarMario(b);
            //Debug.WriteLine("Enemy is Collided On Left:");
        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is IBlock || b is Pipe)
            {
                this.MoveLeft();

            }
            CollideFireBall(b);
            CollideStarMario(b);
            //Debug.WriteLine("Enemy is Collided On Right:");
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public void MoveLeft()
        {
            CurrentActionState.MoveLeft();

        }

        public void MoveRight()
        {     
            CurrentActionState.MoveRight();

        }
   
        public void GetDamaged()
        {
            preactionState = CurrentActionState;
            EnemyActionStates[EnemyAction.Defeated].Enter();
            this.Velocity = new Vector2(0, 0);
        }

      
        public override void Update(GameTime gameTime)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            CurrentActionState.Update(deltaTime);
        }
    }
}
