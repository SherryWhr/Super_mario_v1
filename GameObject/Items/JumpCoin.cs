using MahJong.GameObject.Sprites;
using MahJong.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.GameObject.Items;

namespace MahJong.GameObject.Items
{
    internal class JumpCoin : BaseItem
    {

        //private ItemSpriteFactory itemSpriteFactory;

        private bool isCollect = false;
        //private bool isVisible = true;

        private int upCount = 0;
        private int yChange = 2;
        private int maxCount = 35;
        private Vector2 movePosition;
        // public IItemState CurrState;
        public JumpCoin(MarioGame game, Vector2 location)
            :base(game, location)
        {
            Location = location;
            movePosition = location;
            //itemSpriteFactory = ItemSpriteFactory.Instance;
            currSprite = ItemSpriteFactory.BuiildItem("JumpCoin");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            collisionBoxColor = CollisionBoxColor.Green;
            Map.DelayRemoveObj(this, 110);
            GameProperties.Instance.score += Const.COIN_SCORE;
            GameProperties.Instance.AddCoin();
        }


        public override void Update(GameTime gameTime)
        {
            currSprite.Update(gameTime);
            if (upCount < maxCount)
            {
                movePosition.Y -= yChange;
                upCount++;
            }
            else
            {
                isCollect = true;
            }
            this.Location = movePosition;

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (!isCollect)
            {
                currSprite.Draw(spriteBatch, Location);
            }

        }

        public override void Move()
        {
           
        }
    }
}
