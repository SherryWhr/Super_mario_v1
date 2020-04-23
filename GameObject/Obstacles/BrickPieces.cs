using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Factory;
using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MahJong.GameObject.Obstacles
{
    internal abstract class BrickPieces: IGameObject
    {
        protected ISprite currSprite;
        protected int xChange;
        protected int yChange;
        protected Vector2 location;
        protected Vector2 ExplodingPosition;
        protected int downCount;
        protected int upCount;
        protected int maxUpCount;
        protected int maxDownCount;
        protected bool isUsed;

        public Rectangle Boundary { get; }

        public Vector2 Velocity { get; set; }
        public bool Grounded { get; set; }
        //public bool OnTop { get; set; }
        //public bool OnLeft { get; set; }
        //public bool OnRight { get; set; }

        public BrickPieces(String pieceType, Vector2 Location)
        {
            ExplodingPosition = Location;
            location = Location;
            currSprite = ItemSpriteFactory.BuiildItem(pieceType);
            isUsed = false;

        }
        public abstract void Update(GameTime gametime);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if(!isUsed)
            currSprite.Draw(spriteBatch,location);
        }

        public void DrawBorderRectangles(SpriteBatch spriteBatch)
        {
            //
        }

        public void CollideOnTop(IGameObject other)
        {
            //
        }

        public void CollideOnBottom(IGameObject other)
        {
           //
        }

        public void CollideOnLeft(IGameObject other)
        {
            //
        }

        public void CollideOnRight(IGameObject other)
        {
           //
        }
    }
    internal class PieceUpleft : BrickPieces
    {
        public PieceUpleft(String pieceType, Vector2 Location)
            :base(pieceType, Location)
        {

            downCount = 0;
            upCount = 0;
            maxUpCount = 10;
            maxDownCount = 300;
            yChange = 9;
            xChange = 2;
        }

        public override void Update(GameTime gametime)
        {
            if ((upCount < maxUpCount) && (downCount < maxDownCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                ExplodingPosition.X -= xChange;
                ExplodingPosition.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxDownCount) && (upCount >= maxUpCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                ExplodingPosition.X -= xChange;
                ExplodingPosition.Y += yChange;
                downCount++;
            }
            else
            {
               isUsed = true;
            }
            location = ExplodingPosition;
        }
    }
    internal class PieceUpRight : BrickPieces
    {
        public PieceUpRight(String pieceType, Vector2 Location)
            : base(pieceType, Location)
        {

            downCount = 0;
            upCount = 0;
            maxUpCount = 10;
            maxDownCount = 300;
            yChange = 9;
            xChange = 2;
        }

        public override void Update(GameTime gametime)
        {
            if ((upCount < maxUpCount) && (downCount < maxDownCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxDownCount) && (upCount >= maxUpCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y += yChange;
                downCount++;
            }
            else
            {
                isUsed = true;
            }
            location = ExplodingPosition;
        }
    }

    internal class PieceLowleft : BrickPieces
    {
        private int yDownChange = 9;
        public PieceLowleft(String pieceType, Vector2 Location)
            : base(pieceType, Location)
        {

            downCount = 0;
            upCount = 0;
            maxUpCount = 10;
            maxDownCount = 300;
            yChange = 4;
            xChange = 2;
        }

        public override void Update(GameTime gametime)
        {
            if ((upCount < maxUpCount) && (downCount < maxDownCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                ExplodingPosition.X -= xChange;
                ExplodingPosition.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxDownCount) && (upCount >= maxUpCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                ExplodingPosition.X -= xChange;
                ExplodingPosition.Y += yDownChange;
                downCount++;
            }
            else
            {
                isUsed = true;
            }
            location = ExplodingPosition;

        }
    }

    internal class PieceLowRight : BrickPieces
    {
        private int yDownChange = 9;
        public PieceLowRight(String pieceType, Vector2 Location)
            : base(pieceType, Location)
        {

            downCount = 0;
            upCount = 0;
            maxUpCount = 10;
            maxDownCount = 300;
            yChange = 4;
            yDownChange = 9;
            xChange = 2;
        }

        public override void Update(GameTime gametime)
        {
            if ((upCount < maxUpCount) && (downCount < maxDownCount)) //upCount counter used to manage the number of times sprite is moved up
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y -= yChange;
                upCount++;
            }
            else if ((downCount < maxDownCount) && (upCount >= maxUpCount))  //downCount counter used to manage the number of times sprite is moved down
            {
                ExplodingPosition.X += xChange;
                ExplodingPosition.Y += yDownChange;
                downCount++;
            }
            else
            {
                isUsed = true;
            }
            location = ExplodingPosition;

        }
    }

}
