using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.GameObject.Enemies.EnemyActionState
{
    internal class MovingLeftState : EnemyActionState
    {
        public MovingLeftState(Enemy enemy) : 
            base(enemy)
        {
            enemy.FacingDirection = EnemyDirection.Left;
        }

        public override void Enter()
        {
            enemy.FacingDirection = EnemyDirection.Left;
            enemy.CurrentActionState = this;
        }

        public override void Update(float deltaTime)
        {
            if (!enemy.Grounded && enemy.Velocity.X != 0)
            {
                enemy.Velocity = new Vector2(enemy.Velocity.X, enemy.Velocity.Y + Const.GRAVITY * deltaTime);
                if (enemy.Velocity.Y > Const.VELOCITY_MAX_UD) enemy.Velocity = new Vector2(enemy.Velocity.X, Const.VELOCITY_MAX_UD);
            }            
            else if (enemy.notMove)
            {
                enemy.Velocity = enemy.Location.X - Scene.camera.position.X >=
                    enemy.game.GraphicsDevice.Viewport.Width ? new Vector2(0, 0) : new Vector2(1, 0);
                enemy.notMove = enemy.Location.X - Scene.camera.position.X >= enemy.game.GraphicsDevice.Viewport.Width;
            }
            enemy.Location = new Vector2(enemy.Location.X - enemy.Velocity.X, enemy.Location.Y + enemy.Velocity.Y * deltaTime);
        }
    }
}
