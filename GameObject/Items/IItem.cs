using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Items
{
    internal interface IItem: IGameObject
    {
        void Remove();
        void Move();
    }

    internal abstract class BaseItem : BaseCollideObject, IItem
    {
        //public MarioGame game;
        public BaseItem(MarioGame game, Vector2 Location)
            : base(game, Location)
        {
            //this.game = game;
        }

        public virtual void Remove()
        {

        }

        

        public virtual void Bounce()
        { 

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }
        public abstract void Move();

    }

}
