using MahJong.Factory;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Items.StarmenState;
using MahJong.GameObject.Obstacles;
using MahJong.GameObject.Sprites;
using MahJong.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MahJong.GameObject.Items
{
    internal class Starman : BaseItem
    {
        public Dictionary<StarmanState, IStarmenState> States;
        public IStarmenState CurrState;
        private readonly Vector2 initialLocation;


        public Starman(MarioGame game, Vector2 location )
            :base(game, location)
        {

            States = new Dictionary<StarmanState, IStarmenState>
            {
                { StarmanState.Unveil, new UnveilState(this)},
                { StarmanState.Bounce, new BounceState(this)},
                { StarmanState.Fall, new FallState(this)}
            };
            CurrState = States[StarmanState.Unveil];
            currSprite = ItemSpriteFactory.BuiildItem("Star");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            collisionBoxColor = CollisionBoxColor.Green;

            //Velocity = new Vector2(0.0f, 0.0f);

            initialLocation = Location;
        }


        public void Collect()
        {
            GameProperties.Instance.score += Const.SUPERSTAR_SCORE;
            Remove();
            SoundManager.Instance.MuteAndUnmute();
            SoundManager.Instance.PlayPowerUpSound();
            SoundManager.Instance.PlayStarSound();

        }

        public override void Bounce()
        {
            CurrState.Bounce();
        }

        public override void Move()
        {
        }

        public virtual void Unveil()
        {
            CurrState.Unveil();
        }
        public override void Update(GameTime gameTime)

        {
            float deltatime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Map.Update(this);
            Location += Velocity * deltatime;
            currSprite.Update(gameTime);
            CurrState.Update(deltatime);
            Console.WriteLine(CurrState);

            if (CurrState is UnveilState && initialLocation.Y - Location.Y > 25)
            {               
                Bounce();               
            }
        }

        public override void Remove()
        {
            Map.RemoveObj(this);
            SoundManager.Instance.StopStarSound();
            SoundManager.Instance.MuteAndUnmute();
        }

        public override void CollideOnLeft(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();
            if (b is IBlock)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();
            if (b is IBlock)
            {
                Velocity = new Vector2(-Velocity.X, Velocity.Y);
            }
        }

        public override void CollideOnTop(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();
            else if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Location.Y = b.Boundary.Bottom + Boundary.Height;
                Velocity = new Vector2(Velocity.X, 0);
                CurrState.Fall();
            }
        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();
            else if ((b is IBlock && !(b as IBlock).IsHidden))
            {
                Location.Y = b.Boundary.Top;
                CurrState.Bounce();
            }
        }

        
    }
}
