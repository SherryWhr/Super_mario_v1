using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.Factory;
using MahJong.GameObject.Sprites;
using MahJong.GameObject.Enemies.EnemyActionState;


namespace MahJong.GameObject.Enemies
{
    internal class Goomba : Enemy
    {
        //private GoombaSpriteFactory goombaSpriteFactory;
        // In sprint 2, suppose game level is always normal
        private EnemyLevel enemyLevel = EnemyLevel.Normal;

        public Goomba(MarioGame game, Vector2 location)
            :base(game, location)
        {            
            preactionState = CurrentActionState;
            
            // Refactor Test
            //goombaSpriteFactory = GoombaSpriteFactory.Instance;
            currSprite = GoombaSpriteFactory.BuildGoomba(enemyLevel, EnemyAction.MoveLeft);
            offset = -3;
            Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y);
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);           
           if (CurrentActionState is DefeatedState && preactionState != CurrentActionState)
           {
                currSprite = GoombaSpriteFactory.BuildGoomba(enemyLevel, EnemyAction.Defeated);
                preactionState = CurrentActionState;
           }
            currSprite.Update(gameTime);
            Map.Update(this);
        }


       
    }
}
