using MahJong.GameObject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MahJong.TileMap
{
    class ObjToRemove
    {
        public IGameObject obj;
        public int timeCount;

        public ObjToRemove(IGameObject obj, int timeCount)
        {
            this.obj = obj;
            this.timeCount = timeCount;
        }

    }

    internal class Map
    {
        public List<List<HashSet<IGameObject>>> TileMap;                    // the TileMap, [x, y]
        public Dictionary<IGameObject, List<Point>> Position;      // Contains all of the objects and their occupied tiles
        public HashSet<IGameObject> MovingObject;                  // Contains all of the moving objects
        public HashSet<ObjToRemove> ToRemove;
        public GameModel Gm;
        public int FieldSizeX;
        public int FieldSizeY;
        public int SizeY;

        public Map(int FieldSizeX, int SizeY,int FieldSizeY, GameModel gm)
        {
            TileMap = new List<List<HashSet<IGameObject>>>();

            for (int i = 0; i < FieldSizeX; ++i)
            {
                TileMap.Add(new List<HashSet<IGameObject>>());               
                for (int j = 0; j < FieldSizeY; ++j)
                    TileMap[i].Add(new HashSet<IGameObject>());
            }

            Position = new Dictionary<IGameObject, List<Point>> ();
            MovingObject = new HashSet<IGameObject> ();
            ToRemove = new HashSet<ObjToRemove> ();
            this.FieldSizeX = FieldSizeX;
            this.FieldSizeY = FieldSizeY;
            this.SizeY = SizeY;
            Gm = gm;
        }

        public void Add(IGameObject obj)
        {
            Rectangle r = obj.Boundary;
            int minX = r.Left / Const.GRID_WIDTH;
            int maxX = (int)Math.Ceiling((double)r.Right / Const.GRID_WIDTH);
            int minY = r.Top / Const.GRID_HEIGHT;
            int maxY = (int)Math.Ceiling((double)r.Bottom / Const.GRID_HEIGHT);
            List<Point> l = new List<Point> ();

            if (minX < 0 || maxX >= FieldSizeX || minY < 0 || maxY >= FieldSizeY)
                return;

            for (int i = minX; i <= maxX; ++i)
                for (int j = minY; j <= maxY; ++j)
                {
                    l.Add(new Point(i, j));
                    TileMap[i][j].Add(obj);
                }

            if (obj.Velocity.X != 0 || obj.Velocity.Y != 0)
                MovingObject.Add(obj);

            Position.Add(obj, l);
        }
       
        public void Remove(IGameObject obj)
        {
            if (Position.ContainsKey(obj))
            {
                foreach (Point p in Position[obj])
                    TileMap[p.X][p.Y].Remove(obj);

                Position.Remove(obj);
            }

            if (MovingObject.Contains(obj))
                MovingObject.Remove(obj);
        }

        public void RemoveObj(IGameObject obj)
        {
            Remove(obj);
            Gm.RemoveGameObject(obj);
        }

        public void DelayRemoveObj(IGameObject obj, int time)
        {
            ToRemove.Add(new ObjToRemove(obj, time));
        }

        public void Update(IGameObject obj)
        {
            Remove(obj);
            Add(obj);
        }

        public void Update()
        {
            HashSet<ObjToRemove> removed = new HashSet<ObjToRemove>();

            foreach (ObjToRemove o in ToRemove)
                if (--o.timeCount <= 0)
                    removed.Add(o);

            foreach (ObjToRemove o in removed)
            {
                ToRemove.Remove(o);
                RemoveObj(o.obj);
            }               
        }
    }
}
