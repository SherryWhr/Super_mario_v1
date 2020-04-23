using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MahJong.GameObject.Obstacles
{
    internal class BrickRightLowPiece : Sprite
    {
        private bool isUsed = false;
        private int downCount = 0;
        private int upCount = 0;
        private int yChange = 3;
        private int xChange = 2;
        private int maxUpCount = 10;
        private int maxDownCount = 300;
        private int yDownChange = 9;
        private Vector2 ExplodingPosition;
        public BrickRightLowPiece(MarioGame game, Vector2 location)
            : base(location, game.Content.Load<Texture2D>("blocks/RightPiece"), new Point(1, 1))
        {

            this.ExplodingPosition = location;

        }
        public override void Update(GameTime gameTime)
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
                this.isUsed = true;
            }
            Location = ExplodingPosition;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            BoundingBox = new Rectangle((int)Location.X, (int)Location.Y, texture.Width / sheetSize.X, texture.Height / sheetSize.Y);
            SourceRectangle = new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y * frameSize.Y, frameSize.X, frameSize.Y);
            spriteBatch.Draw(texture, Location, SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

    }
}
