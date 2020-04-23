using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace MahJong.GameObject
{
    internal interface ICollidable
    {
        void CollideOnTop(IGameObject other);
        void CollideOnBottom(IGameObject other);
        void CollideOnLeft(IGameObject other);
        void CollideOnRight(IGameObject other);
    }
}
