using System.Diagnostics;

using MahJong.Factory;
using MahJong.GameObject.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MahJong.Sound;
using MahJong.GameObject.Mario.ActionState;
using MahJong.GameObject.Enemies;
using MahJong.GameObject.Mario;

namespace MahJong.GameObject.Obstacles
{

    internal class Pipe : BaseCollideObject, IBlock
    {
        public bool IsWarp { get; set; }
        public bool IsSecret { get; set; }
        public Point Target { get; set; }
        public bool IsHidden { get; set; }

        //private bool isViewable;

        public Pipe(MarioGame game, Vector2 location, bool isWarp, Point target, bool hasEnemy, bool isSecret)
            : base(game, location)
        {
            this.IsWarp = isWarp;
            this.IsSecret = isSecret;
            currSprite = ItemSpriteFactory.BuiildItem("pipe");
            Size = new Point(currSprite.frameSize.X + offset, currSprite.frameSize.Y + offset);
            //Size = new Point(currSprite.frameSize.X, currSprite.frameSize.Y );
            Target = target;

            IsHidden = false;
            //isViewable = true ;
            
        }

        public void SetEnemy(ZombiePrincess enemy)
        {
            enemy.SetPipe(this);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            currSprite.Draw(spriteBatch, Location);
        }

        public override void CollideOnTop(IGameObject b)
        {
            if(b is Mario.Mario)
            {
                Mario.Mario mario = b as Mario.Mario;
                if(mario.CurrentPowerUpState is Mario.PowerUpState.SuperState ||mario.CurrentPowerUpState is Mario.PowerUpState.StarState || mario.CurrentPowerUpState is Mario.PowerUpState.FireState)
                {
                    SoundManager.Instance.PlayPipeSound();
                }
                //isViewable = false;              
            }
            //Debug.WriteLine(isViewable);
            //Debug.WriteLine("Mario triggered pipe");
            //if (isWarp && b is Mario.Mario)
            //{
            //    Mario.Mario mario = b as Mario.Mario;
            //    if (mario.CurrentActionState is CrouchState)
            //    {
            //        mario.Grounded = false;
            //        mario.Fall();
            //    }
            //}
        }

        //public override void CollideOnLeft(IGameObject b)
        //{
        //    if (b is Mario.Mario)
        //    {
        //        isViewable = false;
        //    }
        //}

        //public override void CollideOnRight(IGameObject b)
        //{
        //    if (b is Mario.Mario)
        //    {
        //        isViewable = false;
        //    }
        //}

        public bool IsViewable()
        {
            Mario.Mario Mario = Game.GameModel.Mario;
            MarioDirection FacingDirection = Mario.FacingDirection;
            //float LocationX = FacingDirection == MarioDirection.Right ? 
            //    Mario.Location.X + Mario.Size.X : Mario.Location.X;

            float LocationX =  Mario.Location.X + Mario.Size.X;

            // d > 0.5 * Mario Width && d < 200 px
            //Debug.WriteLine((this.Location.X - this.Size.X) + "\t" + LocationX +"\t\t\t" + (Mario.Size.X / 2));
            //return FacingDirection == MarioDirection.Right ?  
            //   (this.Location.X - this.Size.X - LocationX) > (float)Mario.Size.X / 2 && (this.Location.X - LocationX) < 200 :
            //   (- this.Location.X + this.Size.X + LocationX) > (float)Mario.Size.X / 2 && (- this.Location.X + LocationX) < 200;
            return FacingDirection == MarioDirection.Right &&
               (this.Location.X - this.Size.X - LocationX) > (float)Mario.Size.X / 2 && (this.Location.X - LocationX) < 200;
        }

        public void Remove()
        {
        }
    }
}
