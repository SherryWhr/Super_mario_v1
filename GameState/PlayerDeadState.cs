using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.Sound;

namespace MahJong.GameState
{
    internal class PlayerDeadState : BaseGameState
    {
        private int delay = 100;
        private int count = 0;
        public PlayerDeadState(MarioGame game)
        : base(game)
        {
            game.Control.RemapControllers();

        }
        public override void Update(GameTime gameTime)
        {
            if (count < delay)
            {
                game.Control.Update(gameTime);
                game.GameModel.Update();
                game.Scene.Update(gameTime);
            }
            else
            {  if(GameProperties.Instance.lives > 0)
                    game.CurrgameState = new BlackScreenState(game, this);
                else
                {
                    game.CurrgameState = new GameOverState(game);
                    SoundManager.Instance.PlayGameoverSound();
                }
                    
            }
            count++;
        }
    }
}
