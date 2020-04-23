using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahJong.GameObject.Enemies.EnemyActionState
{
    internal class DefeatedState : EnemyActionState
    {
        public DefeatedState(Enemy enemy)
            :base(enemy)
        {
        }

        public override void Enter()
        {
            if (enemy is ZombiePrincess) GameProperties.Instance.score += Const.ZOMBIE_SCORE;
            else GameProperties.Instance.score += Const.GOOMBA_SCORE;
            enemy.Map.DelayRemoveObj(enemy, 110);
            enemy.CurrentActionState = this;
        }

        public override void Update(float deltaTime)
        {
        }
    }
}
