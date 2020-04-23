using MahJong.GameObject.Sprites;
using MahJong.Factory;
using MahJong.Sound;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.GameObject.Obstacles;

namespace MahJong.GameObject.Items
{
    internal class FireFlower : BaseItem
    {
        
        //private ItemSpriteFactory itemSpriteFactory;
        //private bool isCollect;
        private bool isMove = true;
        private Vector2 movePosition;
        private Vector2 iniPosition;
        private int upCount = 0;
        private int yChange = 1;
        // public IItemState CurrState;
        public FireFlower(MarioGame game, Vector2 location)
            :base(game, location)
        {
            this.Location = location;
            movePosition = location;
            iniPosition = location;
            //itemSpriteFactory = ItemSpriteFactory.Instance;
            currSprite = ItemSpriteFactory.BuiildItem("Flower");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            collisionBoxColor = CollisionBoxColor.Green;
        }

        public void Collect()
        {

            //isCollect = true;
            GameProperties.Instance.score += Const.FIREFLOWER_SCORE;
            Remove();
            SoundManager.Instance.PlayPowerUpSound();
            
        }

        public override void Remove()
        {
            Map.RemoveObj(this);
        }
        public override void Update(GameTime gameTime)
        {
            if (isMove)
            {
                movePosition.Y -= yChange;
                upCount++;
                if (movePosition.Y < iniPosition.Y - 22f)
                    isMove = false;

                this.Location = movePosition;
            }

            Map.Update(this);
            currSprite.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

                currSprite.Draw(spriteBatch, Location);
            

        }
        public override void CollideOnLeft(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();

        }

        public override void CollideOnRight(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();

        }

        public override void CollideOnTop(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();

        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is Mario.Mario)
                Collect();
            if (b is IBlock)
            {
                if (this.Boundary.Bottom == b.Boundary.Top)
                    isMove = false;

            }
        }
        public override void Move()
        {
           
        }
    }
}
