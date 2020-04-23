using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.Factory
{
    internal class FontFactory: SpriteFactory
    {
 

        private FontFactory(){ }
        public static TextSprite GetFont(String str)
        {
            SpriteFont font = game.Content.Load<SpriteFont>("Arial");
            //blackBackground = game.Content.Load<Texture2D>("black");
            return new TextSprite(str, font);

        }

        //public Texture2D GetBackground()
        //{
        //    return blackBackground;
        //}
    }
}

