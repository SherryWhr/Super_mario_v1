using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace MahJong.Sound
{
    class SoundManager
    {
        private SoundEffectInstance marioJumpsStandard;
        private SoundEffectInstance marioJumpsSuper;
        private SoundEffectInstance marioStomp;
        private SoundEffectInstance marioDie;
        private SoundEffectInstance marioFalls;
        private SoundEffectInstance marioFire;

        private SoundEffectInstance coin;
        private SoundEffectInstance fireBall;
        private SoundEffectInstance powerUpAppears;
        private SoundEffectInstance powerUp;
        private SoundEffectInstance oneUp;
        private SoundEffectInstance brickBump;
        private SoundEffectInstance brickBreaks;
        private SoundEffectInstance pipeTravel;
        private SoundEffectInstance flagPole;
        private SoundEffectInstance starMario;

        private SoundEffectInstance timeWarning;
        private SoundEffectInstance gameOver;
        private SoundEffectInstance mainTheme;
        private SoundEffectInstance stageClear;
        private SoundEffectInstance underground;
        private SoundEffectInstance worldClear;

        private List<SoundEffectInstance> soundeffects;

        private bool isMuted = false;
        private static SoundManager _instance;

        private SoundManager()
        {
            soundeffects = new List<SoundEffectInstance>();
        }

        public static SoundManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SoundManager();
                return _instance;
            }
        }

        public void LoadSounds(MarioGame game)
        {
            marioJumpsStandard = game.Content.Load<SoundEffect>("Sound/Jump_Standard").CreateInstance();
            marioJumpsSuper = game.Content.Load<SoundEffect>("Sound/Jump_Super").CreateInstance(); 
            marioStomp = game.Content.Load<SoundEffect>("Sound/Stomp").CreateInstance(); 
            marioDie = game.Content.Load<SoundEffect>("Sound/die").CreateInstance(); 
            marioFalls = game.Content.Load<SoundEffect>("Sound/Falls").CreateInstance();
            marioFire = game.Content.Load<SoundEffect>("Sound/Fire").CreateInstance();

            coin = game.Content.Load<SoundEffect>("Sound/coin").CreateInstance();
            fireBall = game.Content.Load<SoundEffect>("Sound/Fireball").CreateInstance();
            powerUpAppears = game.Content.Load<SoundEffect>("Sound/Powerup_Appear").CreateInstance();
            powerUp = game.Content.Load<SoundEffect>("Sound/Powerup").CreateInstance();
            oneUp = game.Content.Load<SoundEffect>("Sound/1_Up").CreateInstance();
            brickBump = game.Content.Load<SoundEffect>("Sound/bump").CreateInstance();
            brickBreaks = game.Content.Load<SoundEffect>("Sound/breakblock").CreateInstance();
            pipeTravel =  game.Content.Load<SoundEffect>("Sound/Pipe").CreateInstance();
            flagPole = game.Content.Load<SoundEffect>("Sound/flagpole").CreateInstance();
            starMario = game.Content.Load<SoundEffect>("Sound/Starmario").CreateInstance();

            timeWarning = game.Content.Load<SoundEffect>("Sound/Time_Warning").CreateInstance();
            gameOver = game.Content.Load<SoundEffect>("Sound/gameover").CreateInstance();
            mainTheme = game.Content.Load<SoundEffect>("Sound/maintheme").CreateInstance();
            stageClear = game.Content.Load<SoundEffect>("Sound/Stage_Clear").CreateInstance();
            underground = game.Content.Load<SoundEffect>("Sound/Underground").CreateInstance();
            worldClear = game.Content.Load<SoundEffect>("Sound/World_Clear").CreateInstance();

            soundeffects.Add(marioJumpsStandard);
            soundeffects.Add(marioJumpsSuper);
            soundeffects.Add(marioStomp);
            soundeffects.Add(marioDie);
            soundeffects.Add(marioFalls);
            soundeffects.Add(marioFire);

            soundeffects.Add(coin);
            soundeffects.Add(fireBall);
            soundeffects.Add(powerUpAppears);
            soundeffects.Add(powerUp);
            soundeffects.Add(oneUp);
            soundeffects.Add(brickBump);
            soundeffects.Add(brickBreaks);
            soundeffects.Add(pipeTravel);
            soundeffects.Add(flagPole);
            soundeffects.Add(starMario);

            soundeffects.Add(timeWarning);
            soundeffects.Add(gameOver);
            soundeffects.Add(mainTheme);
            soundeffects.Add(stageClear);
            soundeffects.Add(underground);
            soundeffects.Add(worldClear);
        }

        public void PlayStandardJumpSound()
        {
            if (!isMuted)
            {
                marioJumpsStandard.Play();
            }
        }

        public void PlaySuperJumpSound()
        {
            if (!isMuted)
            {
                marioJumpsSuper.Play();
            }
        }

        public void PlayStompSound()
        {
            if (!isMuted)
            {
                marioStomp.Play();
            }
        }

        public void PlayDieSound()
        {
            if (!isMuted)
            {
                MediaPlayer.Stop();
                marioDie.Play();
            }
        }

        public void PlayFallSound()
        {
            if (!isMuted)
            {
                marioFalls.Play();
            }
        }
   
        //public void PlayFireSound()
        //{
        //    if (!isMuted)
        //    {
        //        marioFire.Play();
        //    }
        //}

        //public void PlayFireballSound()
        //{
        //    if (!isMuted)
        //    {
        //        fireBall.Play();
        //    }
        //}

        public void PlayCoinSound()
        {
            if (!isMuted)
            {
                coin.Play();
            }
        }

        public void PlayOneUpSound()
        {
            if (!isMuted)
            {
                oneUp.Play();

            }
        }

        public void PlayPowerUpAppearSound()
        {
            if (!isMuted)
            {
                powerUpAppears.Play();
            }
        }
        public void PlayPowerUpSound()
        {
            if (!isMuted)
            {
                powerUp.Play();
            }
        }

        public void PlayBumpSound()
        {
            if (!isMuted)
            {
                brickBump.Play();
            }
        }

        public void PlayBreakSound()
        {
            if (!isMuted)
            {
                brickBreaks.Play();
            }
        }

        public void PlayPipeSound()
        {
            if (!isMuted)
            {
                pipeTravel.Play();
            }
        }

        public void PlayFlagPoleSound()
        {
            if (!isMuted)
            {
                flagPole.Play();
            }
        }

        public void PlayStarSound()
        {
            if (!isMuted)
            {
                MediaPlayer.Stop();
                starMario.Play();
                MediaPlayer.IsRepeating = true;
            }
        }

        public void StopStarSound()
        {
            if (!isMuted)
            {
                starMario.Stop();
            }
        }

        public void PlayMainThemeSound()
        {
            if (!isMuted)
            {
                MediaPlayer.Stop();
                mainTheme.Play();
                MediaPlayer.IsRepeating = true;
            }
        }

        public void PlayWarningSound()
        {
            if (!isMuted)
            {
                timeWarning.Play();
            }
        }

        public void PlayStageClearSound()
        {
            if (!isMuted)
            {
                stageClear.Play();
            }
        }

        public void PlayGameoverSound()
        {
            if (!isMuted)
            {
                gameOver.Play();
                MediaPlayer.Stop();
            }
        }

        //public void PlayWorldClearSound()
        //{
        //    if (!isMuted)
        //    {
        //        worldClear.Play();
        //    }
        //}

        //public void PlayUndergroundSound()
        //{
        //    if (!isMuted)
        //    {
        //        MediaPlayer.Stop();
        //        underground.Play();
        //        MediaPlayer.IsRepeating = true;
        //    }
        //}

        public void StopAllSound()
        {
            if (!isMuted)
            {
                mainTheme.Stop();
                MediaPlayer.Stop();
            }
        }
        
        public void MuteAndUnmute()
        {
            foreach (SoundEffectInstance s in soundeffects)
            {
                if (s.Volume == 0.0f)
                {
                    s.Volume = 1.0f;
                }
                else
                {
                    s.Volume = 0.0f;
                }
            }
        }
    }
}
