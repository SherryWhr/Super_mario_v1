using System.Collections.Generic;
using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.Factory;
using MahJong.Enums;
using MahJong.GameObject.Items.SuperMushroomState;
using MahJong.GameObject.Obstacles;
using MahJong.Sound;

namespace MahJong.GameObject.Items
{
    internal class SuperMushroom : BaseItem
    {
        public Dictionary<SuperMushroomStates, ISuperMushroomState> States { get; }
        public ISuperMushroomState CurrentState { get; set; }
        private readonly Vector2 initialLocation;

        public SuperMushroom(MarioGame game, Vector2 location)
            : base(game, location)
        {
            States = new Dictionary<SuperMushroomStates, ISuperMushroomState>
            {
                { SuperMushroomStates.Emerge, new EmergeState(this) },
                { SuperMushroomStates.Moving, new MovingState(this) }
           };

            currSprite = ItemSpriteFactory.BuiildItem("SuperMushroom");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            collisionBoxColor = CollisionBoxColor.Green;
            CurrentState = States[SuperMushroomStates.Emerge];

            initialLocation = Location;

            Velocity = new Vector2(0.0f, Const.ITEM_GRAVITY);
            Grounded = false;
        }

        public override void Update(GameTime gameTime)
        {
            float deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Location += Velocity * deltatime;

            if (initialLocation.Y - Location.Y > 22)
            {
                Moving();
            }
            CurrentState.Update(gameTime);
            currSprite.Update(gameTime);
            Map.Update(this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public override void Move()
        {

        }

        public override void Remove()
        {
            Map.RemoveObj(this);
        }

        public void Moving()
        {
            CurrentState.Moving();
        }

        public void CollideMario(IGameObject b)
        {
            if(b is Mario.Mario && CurrentState is MovingState)
            {
                GameProperties.Instance.score += Const.SUPERMUSHROOM_SCORE;
                Remove();
                SoundManager.Instance.PlayPowerUpSound();
            }
        }

        public override void CollideOnTop(IGameObject b)
        {
            CollideMario(b);
        }

        public override void CollideOnBottom(IGameObject b)
        {
            CollideMario(b);
            Location.Y = b.Boundary.Top;
            Velocity = new Vector2(Velocity.X, 0);
        }

        public override void CollideOnLeft(IGameObject b)
        {
            if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
            CollideMario(b);
        }

        public override void CollideOnRight(IGameObject b)
        {
            if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
            CollideMario(b);
        }
    }
}
