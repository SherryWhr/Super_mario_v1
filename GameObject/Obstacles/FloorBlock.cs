using System.Runtime.CompilerServices;

using MahJong.Factory;
using MahJong.GameObject.Obstacles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace MahJong.GameObject.Obstacles
{
    internal class FloorBlock : BaseCollideObject, IBlock
    {
        public bool IsHidden { get; set; }


        //private ObstacleSpriteFactory obstacleSpriteFactory;
        //private bool isCollect = false;



        public FloorBlock(MarioGame game, Vector2 location)
            : base(game, location)
        {
            this.Location = location;
            //obstacleSpriteFactory = ObstacleSpriteFactory.Instance;
            currSprite = ObstacleSpriteFactory.BuildObstacle("Floor");
            Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            IsHidden = false;
        }

        public override void Update(GameTime gameTime)
        {
            currSprite.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public void Remove()
        {
           
        }
    }
}
