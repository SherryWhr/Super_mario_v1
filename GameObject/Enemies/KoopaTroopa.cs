using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.Factory;
using MahJong.GameObject.Sprites;
using MahJong.GameObject.Enemies.EnemyActionState;


namespace MahJong.GameObject.Enemies
{
    internal class KoopaTroopa : Enemy
    {
        //private KoopaTroopaSpriteFactory koopaTroopaSpriteFactory;
        // In sprint 2, suppose game level is always normal
        private EnemyLevel enemyLevel = EnemyLevel.Normal;
        private KoopaTroopaColor color = KoopaTroopaColor.Green;

        public KoopaTroopa(MarioGame game, Vector2 location)
            :base(game, location)
        {            
            preactionState = CurrentActionState;
            offset = -2;
            // Refactor Test
            //koopaTroopaSpriteFactory = KoopaTroopaSpriteFactory.Instance;
            currSprite = KoopaTroopaSpriteFactory.BuildKoopaTroopa(enemyLevel, color, 
                EnemyAction.MoveLeft);
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
        }
       
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (CurrentActionState is DefeatedState && preactionState != CurrentActionState)
            {
                currSprite = KoopaTroopaSpriteFactory.BuildKoopaTroopa(enemyLevel, color, EnemyAction.Defeated);
                preactionState = CurrentActionState;
            }
            currSprite.Update(gameTime);
            Map.Update(this);
        }
       
    }
}
