using System.Runtime.CompilerServices;
using MahJong.Factory;
using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.Sound;


namespace MahJong.GameObject.Items
{
    internal class NormalCoin :BaseItem
    {

        public NormalCoin(MarioGame game, Vector2 location)
            :base(game, location)
        {
            this.Location = location;
            //itemSpriteFactory = ItemSpriteFactory.Instance;
            currSprite = ItemSpriteFactory.BuiildItem("Coin");
            offset = 5;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
            Map.Add(this);
        }
        public void Collect()
        {
            GameProperties.Instance.score += Const.COIN_SCORE;
            GameProperties.Instance.AddCoin();
            SoundManager.Instance.PlayCoinSound();
            Remove();
           
        }
        public override void Update(GameTime gameTime)
        {

            currSprite.Update(gameTime);

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
        }
    }
}
