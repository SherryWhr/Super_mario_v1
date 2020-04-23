using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Microsoft.Xna.Framework;


namespace MahJong.GameObject.Enemies.EnemyActionState
{
    internal class StayStaticState : EnemyActionState
    {
        private int clock;
        public StayStaticState(Enemy enemy) :
            base(enemy)
        {
            clock = 0;
        }

        public override void Enter()
        {
            enemy.CurrentActionState = this;
            ((ZombiePrincess)enemy).SetOffset(-3);
        }

        public override void Update(float deltaTime)
        {
            enemy.Velocity = new Vector2(0, 0);
            //Debug.WriteLine(clock);       
            if (clock > 100) enemy.CurrentActionState = enemy.EnemyActionStates[EnemyAction.MoveDown];
            clock++;            
            enemy.Location = new Vector2(enemy.Location.X - enemy.Velocity.X, enemy.Location.Y + enemy.Velocity.Y * deltaTime);
        }
    }
    internal class MovingUpState : EnemyActionState
    {
        
        public MovingUpState(Enemy enemy) :
            base(enemy)
        {
            
        }

        public override void Enter()
        {           
            enemy.CurrentActionState = this;
            ((ZombiePrincess)enemy).SetOffset(0);
        }

        public override void Update(float deltaTime)
        {
            if (enemy.notMove)
            {
                enemy.Velocity = new Vector2(0, 0);
                enemy.notMove = !((ZombiePrincess)enemy).IsViewable();
               
            } else {
                enemy.Velocity = new Vector2(0, -30);
                if(((ZombiePrincess)enemy).IsStatic())
                {
                    enemy.CurrentActionState = enemy.EnemyActionStates[EnemyAction.StayStatic];
                }
                if (((ZombiePrincess)enemy).IsInThePipe()) enemy.notMove = !((ZombiePrincess)enemy).IsViewable();
            }
            enemy.Location = new Vector2(enemy.Location.X - enemy.Velocity.X, enemy.Location.Y + enemy.Velocity.Y * deltaTime);
        }
    }

    internal class MovingDownState : EnemyActionState
    {
        private int clock;
        public MovingDownState(Enemy enemy) :
            base(enemy)
        {
            clock = 0;
        }

        public override void Enter()
        {
            enemy.CurrentActionState = this;
            ((ZombiePrincess)enemy).SetOffset(0);
        }

        public override void Update(float deltaTime)
        {
            //if (enemy.notMove)
            //{
            //    enemy.Velocity = new Vector2(0, 0);
            //    //enemy.notMove = enemy.Location.X - Scene.camera.position.X >= enemy.game.GraphicsDevice.Viewport.Width;

            //}
            //else
            //{
            //    enemy.Velocity = new Vector2(0, 10);
            //}

       

            enemy.Velocity = new Vector2(0, 10);                      
            if (((ZombiePrincess)enemy).IsStatic())
            {
                // Stop moving up for a couple of time
                clock++;
                Debug.WriteLine(clock);
                enemy.Velocity = new Vector2(0, 0);
                if (clock > 100)
                {
                    enemy.CurrentActionState = enemy.EnemyActionStates[EnemyAction.MoveUp];
                    enemy.notMove = true;
                }             
            } else
            {
                clock = 0;
            }
            enemy.Location = new Vector2(enemy.Location.X - enemy.Velocity.X, enemy.Location.Y + enemy.Velocity.Y * deltaTime);
        }
    }
}
