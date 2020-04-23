using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong
{
    // Singleton Design
    class GameProperties
    {
        private static GameProperties _instance;
        public static GameProperties Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GameProperties();

                return _instance;
            }
        }
        public int score;
        public int coin;
        public double time;
        public int lives;

        private GameProperties()
        {
            Reset();
        }

        public void AddCoin()
        {
            if (++coin >= 100)
            {
                coin -= 100;
                lives++;
            }
        }

        public void Reset()
        {
            score = 0;
            coin = 0;
            time = 400;
            lives = 3;
        }

    }
}
