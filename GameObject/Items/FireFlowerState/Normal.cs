
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MahJong.GameObject.Item;
namespace MahJong.GameObject.Items.FireFlowerState
{
    class Normal : ItemState<FireFlower>
    {
        public Normal(FireFlower owner) : base(owner)
        {

        }

        public override void Update()
        {
            // do nothing
        }
    }
}
