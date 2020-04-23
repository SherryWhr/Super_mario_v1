using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Sprites;


namespace MahJong.Factory
{
    internal class GoombaSpriteFactory : SpriteFactory
    {
        private GoombaSpriteFactory() { }

        public static ISprite BuildGoomba(
            EnemyLevel goombaLevel, EnemyAction goombaAction)
        {
            String resourceString = "Enemy/";
            int frameNumber = (goombaAction != EnemyAction.Defeated) ? 2 : 1;
            
                resourceString += 
                (goombaLevel).ToString() 
                + ((goombaAction != EnemyAction.Defeated) ? EnemyAction.Move.ToString() : EnemyAction.Defeated.ToString())
                + "Goomba";

                

            return new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber,1),
                goombaAction == EnemyAction.MoveLeft || goombaAction == EnemyAction.MoveRight,
                frameNumber);
        }
    }

    class KoopaTroopaSpriteFactory : SpriteFactory
    {

        private KoopaTroopaSpriteFactory() { }
        //private static KoopaTroopaSpriteFactory _instance;

        //public static KoopaTroopaSpriteFactory Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //            _instance = new KoopaTroopaSpriteFactory();
        //        return _instance;
        //    }
        //}
        public static ISprite BuildKoopaTroopa(
                   EnemyLevel koopaTroopaLevel, KoopaTroopaColor koopaTroopaColor, EnemyAction koopaTroopaAction)
        {
            String resourceString = "Enemy/";
            int frameNumber = koopaTroopaAction != EnemyAction.Defeated ? 2 : 1;

            resourceString +=
                (koopaTroopaLevel).ToString()
                + (koopaTroopaColor).ToString()
                + (koopaTroopaAction).ToString();
      
            resourceString += "KoopaTroopa";


            return new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber, 1),
                koopaTroopaAction == EnemyAction.MoveLeft || koopaTroopaAction == EnemyAction.MoveRight,
                frameNumber);
        }
    }

    class ZombiePrincessSpriteFactory : SpriteFactory
    {
        private ZombiePrincessSpriteFactory() { }

        public static ISprite BuildZombiePrincess()
        {
            String resourceString = "Enemy/ZombiePrincess";
            int frameNumber = 1;          

            return new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber, 1),
                true,
                frameNumber);
        }
    }



}
