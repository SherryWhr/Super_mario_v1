using MahJong.GameObject.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahJong.GameObject.Item;

namespace MahJong.GameObject.Items.FireFlowerState
  
{
    class Unveil: ItemState<FireFlower>
    {
        public Unveil(FireFlower owner) : base(owner)
        {

        }

        public override void Update()
        {
            // do nothing
        }
    }
}
