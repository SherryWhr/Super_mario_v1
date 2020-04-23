using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject.Obstacles.ObstacleState;
using MahJong.Factory;
using System;
using System.Diagnostics;
using MahJong.Sound;

namespace MahJong.GameObject.Obstacles
{
    internal class BrickBlock :BaseCollideObject, IBlock
    {

        public Dictionary<BrickState, IBlockState> BrickBlockStates;
        public IBlockState CurrentBrickBlockState;
        public IBlockState PreBrickBlockState;

        public Boolean IsHidden { get; set; }
        public bool IsUsed = false;
        //public string PowerItem;
        public int CoinNum;
        private MarioGame game;
        private Vector2 iniPosition;
        public BrickBlock(MarioGame game, Vector2 location, bool isHidden, int coinNum)
            :base(game, location)
        {

            BrickBlockStates = new Dictionary<BrickState, IBlockState>
            {
                { BrickState.Normal, new BrickNormalState(this) },
                { BrickState.Used, new BrickUsedState(this) },
                { BrickState.Hidden, new BrickHiddenState(this) },
                { BrickState.Explode, new BrickExplodeState(this) },
                { BrickState.Bump, new BrickBumpState(this) }
            };
            CurrentBrickBlockState = new BrickNormalState(this);
            this.game = game;
            IsHidden = isHidden;
            CoinNum = coinNum;
            //PowerItem = itemType;
            if (IsHidden)
            {
                CurrentBrickBlockState = new BrickHiddenState(this);
            }
            currSprite = BrickSpriteFactory.BuildBrick(CurrentBrickBlockState);
            Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            iniPosition = location;
        }

        public void Bump(Mario.Mario mario)
        {
            if (mario.CurrentPowerUpState is Mario.PowerUpState.NormalState)
            {
                MarioGame.Mariogame.SoundManager.PlayBumpSound();
                if (!IsUsed)
                {
                    ReleaseNextItem();
                }
                CurrentBrickBlockState.Bump(mario);
            }
            else if (mario.CurrentPowerUpState is Mario.PowerUpState.DeadState)
            {
                //do nothing
            }
            else
            {
                MarioGame.Mariogame.SoundManager.PlayBreakSound();
                Explode();
                SoundManager.Instance.PlayBreakSound();
                Remove();
            }
                
        }

        //public void Hidden()
        //{

        //}
        //public void Show()
        //{
        //    CurrentBrickBlockState.Show();
        //}

        public void Explode()
        {

            game.GameModel.AddGameObject(new PieceUpRight("upright", Location));
            game.GameModel.AddGameObject(new PieceUpleft("upleft", Location));
            game.GameModel.AddGameObject(new PieceLowRight("lowright", Location));
            game.GameModel.AddGameObject(new PieceLowleft("lowleft", Location));
            

        }

        public void ReleaseNextItem()
        {
            if (CoinNum > 0)
            {
                MarioGame.Mariogame.SoundManager.PlayCoinSound();
                IGameObject coin = EntitiesFactory.GetEntities("JumpCoin", game, new Vector2(Location.X, Location.Y - 10));
                game.GameModel.AddGameObject(coin);
                CoinNum--;
                if (CoinNum == 0)
                {
                    IsUsed = true;
                }
            }
            //else
            //{
            //    //SoundManager.Instance.PlayPowerUpAppearSound();
            //}

            
        }

        public void Remove()
        {
            Debug.WriteLine("RemoveBlock");
            Map.RemoveObj(this);

        }
        public override void Update(GameTime gameTime)
        {

            CurrentBrickBlockState.Update();
            //Console.WriteLine(CurrentBrickBlockState);
            if (CurrentBrickBlockState != PreBrickBlockState)
            {
                UpdateSprite();
                PreBrickBlockState = CurrentBrickBlockState;
            }

                currSprite.Update(gameTime);

        }



        public override void Draw(SpriteBatch spriteBatch)
        {
                if(CurrentBrickBlockState is BrickUsedState)
                    currSprite.Draw(spriteBatch, iniPosition);
                else
                    currSprite.Draw(spriteBatch, Location);

        }

        public void UpdateSprite()
        {

            if (CurrentBrickBlockState is BrickUsedState)
            {
                currSprite = BrickSpriteFactory.BuildBrick(CurrentBrickBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }
            else
            if (CurrentBrickBlockState is BrickHiddenState)
            {
                currSprite = BrickSpriteFactory.BuildBrick(CurrentBrickBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }
            else
            if (CurrentBrickBlockState is BrickNormalState)
            {
                currSprite = BrickSpriteFactory.BuildBrick(CurrentBrickBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }

        }
        public override void CollideOnBottom(IGameObject b)
        {
            if (b is Mario.Mario)
            {
                Mario.Mario mario = b as Mario.Mario;

                if (CurrentBrickBlockState is BrickHiddenState)
                {
                    if (b.Velocity.Y <= 0)
                        Bump(mario);
                        SoundManager.Instance.PlayBumpSound();
                }
                else
                {
                    Bump(mario);
                    SoundManager.Instance.PlayBumpSound();
                }
            }

        }

    }
}
