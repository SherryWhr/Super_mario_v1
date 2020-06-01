using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using MahJong.GameObject;
using MahJong.GameObject.Mario;
using MahJong.GameObject.Mario.ActionState;
using MahJong.GameObject.Mario.PowerUpState;
using MahJong.GameObject.Sprites;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace MahJong.Factory
{
    internal class MarioSpriteFactory : SpriteFactory
    {
        private static MarioSpriteFactory _instance;
        private static Dictionary<String, Sprite> sprites = new Dictionary<string, Sprite>();
        private Dictionary<int, Dictionary<int, Point>> CollisionSize;

        private MarioSpriteFactory()
        {
            CollisionSize = new Dictionary<int, Dictionary<int, Point>>();

            // In order to unify the boundingbox
            foreach (MarioPowerUp power in Enum.GetValues(typeof(MarioPowerUp)))
            {
                if (power == MarioPowerUp.Star)
                    continue;

                CollisionSize[(int)power] = new Dictionary<int, Point>();
                foreach (MarioAction action in Enum.GetValues(typeof(MarioAction)))
                {
                    int temp = action == MarioAction.Crouch ? (int)MarioAction.Crouch : (int)MarioAction.Idle;
                    CollisionSize[(int)power][(int)action] = Helper(temp, (int)power, MarioDirection.Left);
                }
            }
        }

        public static MarioSpriteFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MarioSpriteFactory();
                }
                return _instance;
            }
        }

        public static int[] MarioSpriteType(IActionState currActionState, IPowerUpState currPowerUpState)
        {
            int[] type = new int[2];
            if (currActionState is IdleState)
                type[0] = (int)MarioAction.Idle;
            else
            if (currActionState is MoveState)
                type[0] = (int)MarioAction.Move;
            else
            if (currActionState is JumpState)
                type[0] = (int)MarioAction.Jump;
            else
            if (currActionState is CrouchState)
                type[0] = (int)MarioAction.Crouch;
            else
            if (currActionState is FallingState)
                type[0] = (int)MarioAction.Fall;
            else
            if (currActionState is FlagState)
                type[0] = (int)MarioAction.Flag;

            if (currPowerUpState is NormalState)
                type[1] = (int)MarioPowerUp.Normal;
            else
            if (currPowerUpState is SuperState)
                type[1] = (int)MarioPowerUp.Super;
            else
            if (currPowerUpState is FireState)
                type[1] = (int)MarioPowerUp.Fire;
            else
            if (currPowerUpState is StarState)
                type[1] = (int)MarioPowerUp.Star;
            else
            if (currPowerUpState is DeadState)
                type[1] = (int)MarioPowerUp.Dead;

            return type;
        }

        public static Point Helper(int actionType, int powerUpType, MarioDirection marioDirection)
        {
            MarioAction marioAction = (MarioAction)actionType;
            MarioPowerUp marioPowerUp = (MarioPowerUp)powerUpType;
            String resourceString = "Mario/";
            int frameNumber = (actionType == (int)MarioAction.Move) ? 3 : 1;

            if (marioAction == MarioAction.Crouch && marioPowerUp == MarioPowerUp.Normal)
            {
                resourceString += (MarioPowerUp.Normal).ToString() + "Idle" + (marioDirection).ToString()
                    + "Mario";
            }
            else if (marioPowerUp != MarioPowerUp.Dead)
            {
                resourceString +=
                    (marioPowerUp).ToString()
                    + (marioAction).ToString()
                    + (marioDirection).ToString()
                    + "Mario";

                //return new Sprite(
                //    game.Content.Load<Texture2D>(resourceString),
                //    new Point(frameNumber, 1),
                //    marioAction == MarioAction.Move,
                //    frameNumber);
            }
            else
            {

                //return new Sprite(game.Content.Load<Texture2D>("DeadMario"), new Point(1, 1), false);
                resourceString += "DeadMario";
            }
            if (!sprites.ContainsKey(resourceString))
            {
                Sprite sprite = new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber, 1),
                (marioAction == MarioAction.Move),
                frameNumber,0.0f, 150);
                sprites.Add(resourceString, sprite);
            }

            return sprites[resourceString].frameSize;
        }

        public Point GetSize(IActionState currActionState, IPowerUpState currPowerUpState, Mario mario)
        {
            if (currPowerUpState is StarState)
            {
                int[] type = MarioSpriteType(currActionState, mario.StateBeforeStar);
                return CollisionSize[type[1]][type[0]];
            }
            else
            {
                int[] type = MarioSpriteType(currActionState, currPowerUpState);
                return CollisionSize[type[1]][type[0]];
            }
           
        }

        public static ISprite BuildMario(
            IActionState currActionState, IPowerUpState currPowerUpState, MarioDirection marioDirection, Mario mario)
        {
            int[] type = MarioSpriteType(currActionState, currPowerUpState);
            MarioAction marioAction = (MarioAction)type[0];
            MarioPowerUp marioPowerUp = (MarioPowerUp)type[1];
            String resourceString = "Mario/";
            int frameNumber = (type[0] == (int)MarioAction.Move) ? 3 : 1;

            if (marioAction == MarioAction.Crouch && marioPowerUp == MarioPowerUp.Normal)
            {
                resourceString += (MarioPowerUp.Normal).ToString() + "Idle" + (marioDirection).ToString()
                    + "Mario";
            }
            else if (marioPowerUp == MarioPowerUp.Star)
            {
                String preState = "Star";
                String Action = (marioAction).ToString();
                if (mario.StateBeforeStar is NormalState)
                {
                    //preState = "Normal";
                    if ((marioAction == MarioAction.Crouch))
                        Action = "Idle";
                }
                else if (mario.StateBeforeStar is SuperState)
                    preState += "Large";
                else if (mario.StateBeforeStar is FireState)
                    preState += "Large";

                resourceString +=
                    preState
                    + Action
                    + (marioDirection).ToString()
                    + "Mario";
            }
            else if (marioPowerUp != MarioPowerUp.Dead)
            {
                resourceString +=
                    (marioPowerUp).ToString()
                    + (marioAction).ToString()
                    + (marioDirection).ToString()
                    + "Mario";

            }
            else
            {

                //return new Sprite(game.Content.Load<Texture2D>("DeadMario"), new Point(1, 1), false);
                resourceString += "DeadMario";
            }
            if (!sprites.ContainsKey(resourceString))
            {
                Sprite sprite = new Sprite(
                game.Content.Load<Texture2D>(resourceString),
                new Point(frameNumber, 1),
                (marioAction == MarioAction.Move),
                frameNumber, 0.0f, 150)
                {
                    LayerDepth = 1f
                };
                sprites.Add(resourceString, sprite);
            }
            return sprites[resourceString];

        }
    }
}
