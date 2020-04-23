using MahJong.GameObject.Sprites;
using MahJong.Factory;
using MahJong.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.GameObject.Obstacles;

namespace MahJong.GameObject.Items
{
    internal class Flag : BaseItem
    {
        private static int height1 = 17;
        private static int height2 = 57;
        private static int height3 = 81;
        private static int height4 = 127;
        private static int height5 = 153;

        private static int point1 = 100;
        private static int point2 = 400;
        private static int point3 = 800;
        private static int point4 = 2000;
        private static int point5 = 4000;


        //private bool isMove = true;
        //private Vector2 movePosition;
        //private Vector2 iniPosition;
        //private int upCount = 0;
        //private int yChange = 1;
        // public IItemState CurrState;

        public Flag(MarioGame game, Vector2 location)
            : base(game, location)
        {
            this.Location = location;
            //movePosition = location;
            //iniPosition = location;
            //itemSpriteFactory = ItemSpriteFactory.Instance;
            currSprite = ItemSpriteFactory.BuiildItem("flags");
            offset = -10;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            collisionBoxColor = CollisionBoxColor.Green;
        }

        public void Score(Mario.Mario b)
        {
            if(b.Location.Y <= 400 - height4)
            {
                GameProperties.Instance.score += point5;
            }
            else if (b.Location.Y <= 400 - height3)
            {
                GameProperties.Instance.score += point4;
            }
            else if (b.Location.Y <= 400 - height2)
            {
                GameProperties.Instance.score += point3;
            }
            else if (b.Location.Y <= 400 - height1)
            {
                GameProperties.Instance.score += point2;
            }
            else if (b.Location.Y <= 400)
            {
                GameProperties.Instance.score += point1;
            }
            else if(b.Location.Y == height5)
            {
                GameProperties.Instance.lives += 1;
                SoundManager.Instance.PlayOneUpSound();
            }
            if(GameProperties.Instance.score > 0)
            {
                GameProperties.Instance.score = (int)(GameProperties.Instance.score * --GameProperties.Instance.time * 2);

            }
                
        }

        public override void Update(GameTime gameTime)
        {
            currSprite.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            currSprite.Draw(spriteBatch, Location);


        }
        public override void CollideOnLeft(IGameObject b)
        {
            if (b is Mario.Mario)
            {
                currSprite.Animated();
                SoundManager.Instance.PlayFlagPoleSound();
                Score(b as Mario.Mario );
            }
            

        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is Mario.Mario)
                currSprite.Animated();
                SoundManager.Instance.PlayFlagPoleSound();
                Score(b as Mario.Mario);

        }

        public override void CollideOnTop(IGameObject b)
        {
            if (b is Mario.Mario)
                currSprite.Animated();
                SoundManager.Instance.PlayFlagPoleSound();
                Score(b as Mario.Mario);

        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is Mario.Mario)
                currSprite.Animated();
                SoundManager.Instance.PlayFlagPoleSound();
                Score(b as Mario.Mario);
            if (b is IBlock)
            {
                //if (this.Boundary.Bottom == b.Boundary.Top)
                    //isMove = false;

            }
        }
        public override void Move()
        {

        }
    }
}
