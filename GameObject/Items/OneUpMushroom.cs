using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.Factory;
using MahJong.GameObject.Sprites;
using MahJong.GameObject.Obstacles;

using MahJong.Enums;
using MahJong.GameObject.Items.OneUpMushroomState;
using System.Collections.Generic;
using MahJong.Sound;

namespace MahJong.GameObject.Items
{
    
    internal class OneUpMushroom : BaseItem
    {
        public Dictionary<OneUpMushroomStates, IOneUpMushroomState> States { get; }
        public IOneUpMushroomState CurrentState { get; set; }
        private readonly Vector2 initialLocation;
        private bool isCollect = false;

        //private bool isVisible = true;
        //private int elapsedTime;
        //private bool isMove = true;
        //private bool isUp = false;
        //private Vector2 iniPosition;
        //private int upCount = 0;
        //private int yChange = 1;

        public OneUpMushroom(MarioGame game, Vector2 location)
            : base(game, location)
        //    :base(location, game.Content.Load<Texture2D>("GreenMushroom"), new Point(1, 1))
        {
            States = new Dictionary<OneUpMushroomStates, IOneUpMushroomState>
            {
                { OneUpMushroomStates.Emerge, new EmergeState(this) },
                { OneUpMushroomStates.Moving, new MovingState(this) }
           };

            //itemSpriteFactory = ItemSpriteFactory.Instance;
            currSprite = ItemSpriteFactory.BuiildItem("OneUpMushroom");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            CurrentState = States[OneUpMushroomStates.Emerge];
            initialLocation = Location;
            Velocity = new Vector2(0.0f, -50f);
            Grounded = false;
            collisionBoxColor = CollisionBoxColor.Green;
        }
        

        public override void Move()
        {

        }

        public override void Remove()
        {
            Map.RemoveObj(this);
        }

        public override void Update(GameTime gameTime)
        {
            //int MinX = 0;
            //int MaxX = 800;

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
            if (!isCollect)
            {
                currSprite.Draw(spriteBatch, Location);
            }
        }
        

        public void Moving()
        {
            CurrentState.Moving();
        }

        public void CollideOnMario(IGameObject b)
        {
            if (b is Mario.Mario && CurrentState is MovingState)
            {
                Remove();
                SoundManager.Instance.PlayOneUpSound();
                GameProperties.Instance.score += Const.ONEUP_SCORE;
                GameProperties.Instance.lives++;
            }
        }

        public override void CollideOnTop(IGameObject b)
        {
            CollideOnMario(b);
        }

        public override void CollideOnBottom(IGameObject b)
        {
            CollideOnMario(b);
            Location.Y = b.Boundary.Top;
            Velocity = new Vector2(Velocity.X, 0);
        }

        public override void CollideOnLeft(IGameObject b)
        {
            CollideOnMario(b);
            if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void CollideOnRight(IGameObject b)
        {
            CollideOnMario(b);
            if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }
    }
}
