using System.Collections.Generic;
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.Factory;
using MahJong.GameObject.Obstacles.ObstacleState;
using MahJong.Enums;
using MahJong.Sound;

namespace MahJong.GameObject.Obstacles
{
    internal class QuestionBlock: BaseCollideObject,IBlock 
    {
        public Boolean IsHidden { get; set; }

        public bool IsUsed = false;
        public string PowerItem;
        public int CoinNum;
        private MarioGame game;
        private IBlockState preQuestionBlockState;
        private Vector2 iniPosition;
        public Dictionary<QuestionState, IBlockState> QuestionBlockStates { get; }
        public IBlockState CurrentQuestionBlockState { get; set; }

        public QuestionBlock(MarioGame game, Vector2 location, bool isHidden, int coinNum, string itemType)
            :base(game, location)
        {
            IsHidden = false;
            QuestionBlockStates = new Dictionary<QuestionState, IBlockState>
            {
                { QuestionState.Normal, new QuestionNormalState(this) },
                { QuestionState.Used, new QuestionUsedState(this) },
                { QuestionState.Hidden, new QuestionHiddenState(this) },
                { QuestionState.Bump, new QuestionBumpState(this) },
            };
            CurrentQuestionBlockState = new QuestionNormalState(this);
            IsHidden = isHidden;
            CoinNum = coinNum;
            PowerItem = itemType;
            this.game = game;
            if (IsHidden)
            {
                CurrentQuestionBlockState = new QuestionHiddenState(this);
            }
            preQuestionBlockState = CurrentQuestionBlockState;
            iniPosition = location;
            currSprite = QuestionBlockSpriteFactory.BuildQuestionBlock(CurrentQuestionBlockState);
            Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
        }

        public void Bump(Mario.Mario  mario)
        {
            CurrentQuestionBlockState.Bump(mario);
            
        }

        public void ReleaseNextItem()
        {
            IGameObject Item = EntitiesFactory.GetEntities(PowerItem, game, new Vector2(Location.X, Location.Y - 10));
            if (!(Item == null))
            {
                game.GameModel.AddGameObject(Item);
                Map.Add(Item);
            }
            if (CoinNum > 0)
            {
                SoundManager.Instance.PlayCoinSound();
                Item = EntitiesFactory.GetEntities("JumpCoin", game, Location);
                game.GameModel.AddGameObject(Item);
                Map.Add(Item);
            }
            else
            {
                SoundManager.Instance.PlayPowerUpAppearSound();
            }
            IsUsed = true;    
                
        }
   
        //public void Show()
        //{
        //    CurrentQuestionBlockState.Show();
        //}
        
        //public void Bounce()
        //{
        //   // this.isBouncing = true;
        //}

        public override void Update(GameTime gameTime)
        {

            if (CurrentQuestionBlockState != preQuestionBlockState)
            {
                UpdateSprite();
                preQuestionBlockState = CurrentQuestionBlockState;
            }
            currSprite.Update(gameTime);
            CurrentQuestionBlockState.Update();
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if(CurrentQuestionBlockState is QuestionUsedState)
                currSprite.Draw(spriteBatch, iniPosition);
            else
            currSprite.Draw(spriteBatch, Location);
        }

        public void Remove()
        {
            Map.RemoveObj(this);
        }
        public void UpdateSprite()
        {

            if (CurrentQuestionBlockState is QuestionUsedState)
            {
                currSprite = QuestionBlockSpriteFactory.BuildQuestionBlock(CurrentQuestionBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }
            else
            if (CurrentQuestionBlockState is QuestionHiddenState)
            {
                currSprite = QuestionBlockSpriteFactory.BuildQuestionBlock(CurrentQuestionBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }
            else
            if (CurrentQuestionBlockState is QuestionNormalState)
            {
                currSprite = QuestionBlockSpriteFactory.BuildQuestionBlock(CurrentQuestionBlockState);
                Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            }

        }

        public override void CollideOnBottom(IGameObject b)
        {
            if (b is Mario.Mario)
            {
                Mario.Mario mario = b as Mario.Mario;  
                Bump(mario);
                SoundManager.Instance.PlayBumpSound();
            }


        }
    }
}
