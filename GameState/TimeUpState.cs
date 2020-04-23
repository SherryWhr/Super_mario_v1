using MahJong.Sound;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameState
{
    internal class TimeUpState : BaseGameState
    {
        public TimeUpState(MarioGame game)
        : base(game)
        {
            GameProperties.Instance.lives -= 1;

        }
        public override void Update(GameTime gameTime)
        {
            if (GameProperties.Instance.lives > 0)
                game.CurrgameState = new BlackScreenState(game, this);
            else
            {
                game.CurrgameState = new GameOverState(game);
                SoundManager.Instance.PlayGameoverSound();
            }
        }
    }
}
