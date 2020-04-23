using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.GameObject.Mario.ActionState;
using Microsoft.Xna.Framework;
using MahJong.Sound;

namespace MahJong.GameState
{
    internal class PlayGameState : BaseGameState
    {
        public PlayGameState(MarioGame game, IGameState preState)
            : base(game)
        {
            if(!(preState is PauseGameState))
                GameProperties.Instance.time = 400;
        }

        public override void TimesUp()
        {
            game.CurrgameState = new TimeUpState(game);
        }

        public override void PlayerDead()
        {
            game.CurrgameState = new PlayerDeadState(game);
        }
        public override void PlayerWin()
        {
            game.CurrgameState = new WinState(game);
            SoundManager.Instance.PlayStageClearSound();
            
        }
        //public void ChangeToUnderground()
        //{

        //}

        public override void Update(GameTime gameTime)
        {
            GameProperties.Instance.time -= gameTime.ElapsedGameTime.TotalSeconds;
            if (GameProperties.Instance.time <= 0)
            {
                this.TimesUp();
            }
            else if(GameProperties.Instance.time == 2)
            {
                SoundManager.Instance.PlayWarningSound();
            }
            game.GameModel.Update();
            game.Scene.Update(gameTime);
        }
    }
}
