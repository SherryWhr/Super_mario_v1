using System.Diagnostics;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using MahJong.LevelMap;
using MahJong.GameObject.Mario;
using MahJong.GameObject.Obstacles;
using MahJong.Factory;
using MahJong.TileMap;
using MahJong.GameObject;
using MahJong.Collision;
using MahJong.Sound;
using MahJong.GameObject.Items;
using MahJong.GameObject.Enemies;

namespace MahJong
{
    internal class GameModel
    {
        public MarioGame Game { get; set; }
        public Map Map { get; set; }
        public Mario Mario { get; set; }
        public IEnumerable<IGameObject> GameObjects { get { return this.gameObjects; } }
        public Rectangle SecretArea { get; set; }
        public float startX;
        public float restartX;
        private List<IGameObject> gameObjects;
        private CollisionDetect collisionDetect;
        private Level level;
        private SoundManager soundManager;

        public GameModel(MarioGame game)
        {
            this.Game = game;
            //this.controller = controller;

            gameObjects = new List<IGameObject>();
            soundManager = SoundManager.Instance;
        }

        public void Initialize()
        {
            level = LevelManager.LoadFromFile("level1.json");
            Game.FieldSize = new Point(level.FieldWidth, level.FieldHeight);
            Map = new Map(level.FieldWidth, level.FieldHeight, level.TotalHeight,this);
            SecretArea = new Rectangle(
                new Point(level.SecretUpperLeftX * 32, level.SecretUpperLeftY * 32),
                new Point((level.SecretLowerRightX - level.SecretUpperLeftX) * 32, (level.SecretLowerRightY - level.SecretUpperLeftY) * 32));
            startX = level.StartPointX * 32;
            restartX = level.StartPointX * 32;
        }

        public void LoadContent()
        {
            LoadLevel();
            soundManager.LoadSounds(Game);
            collisionDetect = new CollisionDetect(Game.Map);
        }

        public void Update()
        {
            collisionDetect.Update();
            Map.Update();
        }

        public void LoadLevel()
        {

            Mario = (new Mario(Game, new Vector2(startX, level.StartPointY * 32)));
            gameObjects.Add(Mario);
            Map.Add(Mario);

            foreach (SerializableEnemyObject obj in level.EnemyObjects)
            {
                IGameObject gameObj = EntitiesFactory.GetEntities(obj.EnemyType, Game,
                    new Vector2(obj.LocationX * 32, obj.LocationY * 32));
                gameObjects.Add(gameObj);
                Map.Add(gameObj);
            }

            foreach (SerializableStructuralObject obj in level.StructuralObjects)
            {
                IGameObject gameObj = EntitiesFactory.GetEntities(obj.BlockType, Game,
                    new Vector2(obj.LocationX * 32, obj.LocationY * 32));
                if (gameObj == null)
                    gameObj = EntitiesFactory.GetEntities(obj.BlockType, Game,
                    new Vector2(obj.LocationX * 32, obj.LocationY * 32), obj.Hidden, obj.CoinNumber, obj.PowerUpItem);
                gameObjects.Add(gameObj);
                Map.Add(gameObj);
            }

            foreach (SerializablePipes obj in level.Pipes)
            {
                IGameObject gameObj = new Pipe(
                    Game, new Vector2(obj.LocationX * 32, obj.LocationY * 32), obj.Active,
                    new Point(obj.TargetX, obj.TargetY), obj.HasEnemy, obj.InSecret);
                
                if (obj.HasEnemy)
                {
                    ZombiePrincess enemy = new ZombiePrincess(Game, new Vector2(obj.LocationX * 32 + 15, obj.LocationY * 32 - 24));
                    Pipe pipe = (Pipe)gameObj;
                    pipe.SetEnemy(enemy);
                    Map.Add(enemy);
                    gameObjects.Add(enemy);
                }

                gameObjects.Add(gameObj);
                Map.Add(gameObj);
            }
            foreach (SerializableCoins obj in level.Coins)
            {
                IGameObject gameObj = EntitiesFactory.GetEntities("NormalCoin", Game,
                  new Vector2(obj.LocationX * 32, obj.LocationY * 32));
                gameObjects.Add(gameObj);
            }

            foreach (SerializableFlags obj in level.Flags)
            {
                IGameObject gameObj = EntitiesFactory.GetEntities("Flag", Game, new Vector2(obj.LocationX * 32, obj.LocationY * 32));
                gameObjects.Add(gameObj);
                Map.Add(gameObj);
            }
        }

        public void ClearLevel()
        {
            soundManager.PlayCoinSound();
            Map.RemoveObj(Mario);
            Mario = null;
            foreach (IGameObject obj in gameObjects)
            {
                Map.Remove(obj);
            }
            gameObjects.Clear();
        }

        public void ResetLevel()
        {
            ClearLevel();
            LoadLevel();
        }

        public void AddGameObject(IGameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public void RemoveGameObject(IGameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }
    }
}
