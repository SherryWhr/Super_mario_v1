using System;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MahJong.GameObject;

namespace MahJong.Factory
{
    internal abstract class SpriteFactory
    {
        protected static MarioGame game;

        protected SpriteFactory() { }
        
        public static void Initialize(MarioGame newGame)
        {
            game = newGame;
        }
    }
}
