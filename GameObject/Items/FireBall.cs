using MahJong.Enums;
using MahJong.Factory;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Items.FireBallState;
using MahJong.GameObject.Obstacles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items
{
    internal class FireBall : BaseItem
    {
        public Dictionary<FireBallStates, IFireBallState> States { get; }
        public IFireBallState CurrState { get; set; }

        public FireBall(MarioGame game, Vector2 Location)
            : base(game, Location)
        {
            States = new Dictionary<FireBallStates, IFireBallState>
            {
                { FireBallStates.Bounce, new BounceState(this) },
                { FireBallStates.Fall, new FallState(this) }
            };
            CurrState = States[FireBallStates.Fall];
            float direction = MarioGame.Mariogame.GameModel.Mario.Location.X - Location.X;
            direction = -direction / Math.Abs(direction);
            Velocity = new Vector2(Const.FIREBALL_VELOCITY_H * direction, 0);
            Size = new Point(Const.FIREBALL_SIZE, Const.FIREBALL_SIZE);
            currSprite = ItemSpriteFactory.BuiildItem("fireball");
            Grounded = false;
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Bounce()
        {
            CurrState.Bounce();
        }

        public override void Remove()
        {
            Map.RemoveObj(this);
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Location += Velocity * deltaTime;

            CurrState.Update(deltaTime);
            currSprite.Update(gameTime);
            Map.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is IBlock)
            {
                Location.Y = b.Boundary.Top;
                CurrState.Bounce();
                Debug.WriteLine("Fire Collide");
            }
        }

        public override void CollideOnTop(IGameObject b)
        {
            if (b is IBlock)
            {
                Location.Y = b.Boundary.Bottom + Boundary.Height;
                Velocity = new Vector2(Velocity.X, 0);
                CurrState.Fall();
            }
        }

        public override void CollideOnLeft(IGameObject b)
        {
            if (b is IBlock || b is IEnemy)
                Remove();
        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is IBlock || b is IEnemy)
                Remove();
        }
    }
}
