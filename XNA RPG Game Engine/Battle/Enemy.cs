using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace Test
{
    class Enemy : BattleChar
    {

        public int AIPersonality;
        public int StaticID;
        Player TargetPlayer;

        public Enemy(int ID, Vector2 Posistion, Vector2 Offset, int enemy, int Radius)
            : base(ID, Posistion, Offset, enemy, Radius)
        {
            
            base.ObjectID = ID;

            
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            KeyboardState keyboardState = Keyboard.GetState();
                switch (GetLookDirection())
                {
                    case (int)Looking.kUp:
                        {
                            SetCurrentAnimation(WalkForwardAnimation);
                            break;
                        }
                    case (int)Looking.kDown:
                        {
                            SetCurrentAnimation(WalkBackwardAnimation);
                            break;
                        }
                    case (int)Looking.kLeft:
                        {
                            SetCurrentAnimation(LeftStandAnimation);
                            break;
                        }
                    case (int)Looking.kRight:
                        {
                            SetCurrentAnimation(RightStandAnimation);
                            break;
                        }
                    case (int)Looking.kUpLeft:
                        {
                            SetCurrentAnimation(WalkUpLeftAnimation);
                            break;
                        }
                    case (int)Looking.kUpRight:
                        {
                            SetCurrentAnimation(WalkUpRightAnimation);
                            break;
                        }
                    case (int)Looking.kDownLeft:
                        {
                            SetCurrentAnimation(WalkDownLeftAnimation);
                            break;
                        }
                    case (int)Looking.kDownRight:
                        {
                            SetCurrentAnimation(WalkDownRightAnimation);
                            break;
                        }
            }
        }
    }
    class Reaper : Enemy
    {
        public Reaper(int ID, Vector2 Posistion, Vector2 Offset, int enemy, int Radius)
            : base(ID, Posistion, Offset, enemy, Radius)
        {
            MaxHP = 3723;
            MaxMP = 123;
            MaxSP = 234;
            HP = 3723;
            MP = 123;
            SP = 234;
            ATK = 443;
            DEF = 345;
            INT = 654;
            RES = 234;
            SPD = 1323;
            EVD = 23;
            WalkForwardAnimation = new Animation(@"Reaper_Forward\reaper-Forward-1");
            WalkLeftAnimation = new Animation(@"Reaper_Left\reaper-Left-1");
            WalkRightAnimation = new Animation(@"Reaper_Right\reaper-Right-1");
            WalkBackwardAnimation = new Animation(@"Reaper_Backward\reaper-Backward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Reaper_Forward\reaper-Forward-1");
            BackwardStandAnimation = new Animation(@"Reaper_Backward\reaper-Backward-1");
            LeftStandAnimation = new Animation(@"Reaper_Left\reaper-Left-1");
            RightStandAnimation = new Animation(@"Reaper_Right\reaper-Right-1");
            SetCurrentAnimation(WalkForwardAnimation);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
        }
    }
    class Succubus : Enemy
    {
        public Succubus(int ID, Vector2 Posistion, Vector2 Offset, int enemy, int Radius)
            : base(ID, Posistion, Offset, enemy, Radius)
        {
            MaxHP = 3723;
            MaxMP = 123;
            MaxSP = 234;
            HP = 3723;
            MP = 123;
            SP = 234;
            ATK = 443;
            DEF = 345;
            INT = 654;
            RES = 234;
            SPD = 1323;
            EVD = 23;
            WalkForwardAnimation = new Animation(@"Succubus_Move_Forward\Succubus_Move_Forward-1");
            WalkLeftAnimation = new Animation(@"Succubus_Move_Left\Succubus_Move_Left-1");
            WalkRightAnimation = new Animation(@"Succubus_Move_Right\Succubus_Move_Right-1");
            WalkBackwardAnimation = new Animation(@"Succubus_Move_Backward\Succubus_Move_Backward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Succubus_Move_Forward\Succubus_Move_Forward-1");
            LeftStandAnimation = new Animation(@"Succubus_Move_Left\Succubus_Move_Left-1");
            RightStandAnimation = new Animation(@"Succubus_Move_Right\Succubus_Move_Right-1");
            BackwardStandAnimation = new Animation(@"Succubus_Move_Backward\Succubus_Move_Backward-1");
            SetCurrentAnimation(WalkForwardAnimation);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
        }
    }
}
