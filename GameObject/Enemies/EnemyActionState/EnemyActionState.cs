using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Enemies.EnemyActionState
{
    internal interface IEnemyActionState
    {
        void Enter();
        void MoveLeft();
        void MoveRight();
        void Defeated();
        void MoveUp();
        void MoveDown();
        void StayStatic();
        void Update(float deltaTime);
    }


    internal abstract class EnemyActionState : IEnemyActionState
    {
        protected Enemy enemy;

        public EnemyActionState(Enemy enemy)
        {
            this.enemy = enemy;
        }

        public abstract void Enter();

        public void Defeated()
        {
            enemy.CurrentActionState = enemy.EnemyActionStates[EnemyAction.Defeated];
        }
        public void MoveLeft()
        {
            enemy.FacingDirection = EnemyDirection.Left;
            enemy.EnemyActionStates[EnemyAction.MoveLeft].Enter();
        }

        public void MoveRight()
        {
            enemy.FacingDirection = EnemyDirection.Right;
            enemy.EnemyActionStates[EnemyAction.MoveRight].Enter();
        }

        public void MoveUp()
        {
            enemy.EnemyActionStates[EnemyAction.MoveUp].Enter();
        }

        public void MoveDown()
        {
            enemy.EnemyActionStates[EnemyAction.MoveDown].Enter();
        }

        public void StayStatic()
        {
            enemy.EnemyActionStates[EnemyAction.StayStatic].Enter();
        }

        public virtual void Update(float deltaTime)
        {
            // do nothing on default
        }
    }
}
