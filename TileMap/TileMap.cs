using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject.Sprites;
using MahJong.GameObject.Obstacles;

using MahJong.Enums;


namespace MahJong.TileMap
{
    public class StartData
    {
        public int xLocation;
        public int yLocation;
        public int yMax;
        public int xMax;
    }
    public class BlockData
    {
        public BlockType State;
        public ItemType itemType;
        public int xLocation;
        public int yLocation;
    }
    public class ItemData
    {
        public ItemType itemType;
        public int xLocation;
        public int yLocation;
    }

    public class EnemyData
    {
        public EnemyType enemyType;
        public int xLocation;
        public int yLocation;
    }
}
