using System;
using System.Collections.Generic;
using System.Linq;
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
        public class Player : BattleChar
    {

        public WeaponItem Weaponitem;
        public HelmetItem Helmetitem;
        public ArmorItem Armoritem;
        public BracersItem Bracersitem;
        public ShieldItem Shielditem;
        public GreavesItem Greavesitem;
        public AccessoryItem Accessoryitem1;
        public AccessoryItem Accessoryitem2;
        public AccessoryItem Accessoryitem3;
        public AccessoryItem Accessoryitem4;

        public string ProfileSprite;
        public string SquareSprite;

        public bool ControlledPlayer = false;
        Enemy TargetEnemy;

        public Player(int ID, Vector2 Posistion, Vector2 Offset, int player, int Radius)
            : base(ID, Posistion, Offset, player, Radius)
        {
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            KeyboardState keyboardState = Keyboard.GetState();
            if (ControlledPlayer == true)
            {

                if (keyboardState.IsKeyDown(Keys.Up)
                && keyboardState.IsKeyDown(Keys.Left))
                {

                    SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                    // RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Up)
                    && keyboardState.IsKeyDown(Keys.Right))
                {

                    SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Down)
                    && keyboardState.IsKeyDown(Keys.Left))
                {

                    SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                    // RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Down)
                    && keyboardState.IsKeyDown(Keys.Right))
                {
                    SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {

                    SetPositionY(GetPosition().Y - (RAM.TILESIZE / 8));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {

                    SetPositionY(GetPosition().Y + (RAM.TILESIZE / 8));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));

                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {

                    SetPositionX(GetPosition().X - (RAM.TILESIZE / 8));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X - (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);

                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {

                    SetPositionX(GetPosition().X + (RAM.TILESIZE / 8));
                    //RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X + (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);

                }
                if (keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Down) &&
                keyboardState.IsKeyUp(Keys.Left) &&
                keyboardState.IsKeyUp(Keys.Right))
                {
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
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    SetLookDirection((int)Looking.kUp);
                    SetCurrentAnimation(WalkBackwardAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    SetLookDirection((int)Looking.kDown);
                    SetCurrentAnimation(WalkForwardAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    SetLookDirection((int)Looking.kLeft);
                    SetCurrentAnimation(WalkLeftAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    SetLookDirection((int)Looking.kRight);
                    SetCurrentAnimation(WalkRightAnimation);
                }
            }
        }
        public void SetControlledPlayer(bool Controlled)
        {
            ControlledPlayer = Controlled;

        }
        public void SetEquipment(EquipmentItems equip)
        {

            if (equip is WeaponItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if(RAM.MasterItemList[x].name != "None")
                    {
                    if (Weaponitem.name == RAM.MasterItemList[x].name)
                    {
                        RAM.MasterItemList[x].count += 1;
                    }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] -= Weaponitem.Stats[x];
                }
                Weaponitem = ((WeaponItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                  //  Stats[x] += equip.Stats[x];
                }
            }
            else if (equip is HelmetItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if (RAM.MasterItemList[x].name != "None")
                    {
                        if (Helmetitem.name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x].count += 1;
                        }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] -= Helmetitem.Stats[x];
                }
                Helmetitem = ((HelmetItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] += equip.Stats[x];
                }
            }
            else if (equip is ArmorItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if (RAM.MasterItemList[x].name != "None")
                    {
                        if (Armoritem.name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x].count += 1;
                        }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                    //Stats[x] -= Armoritem.Stats[x];
                }
                Armoritem = ((ArmorItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] += equip.Stats[x];
                }
            }
            else if (equip is BracersItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if (RAM.MasterItemList[x].name != "None")
                    {
                        if (Bracersitem.name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x].count += 1;
                        }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] -= Bracersitem.Stats[x];
                }
                Bracersitem = ((BracersItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] += equip.Stats[x];
                }
            }
            else if (equip is ShieldItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if (RAM.MasterItemList[x].name != "None")
                    {
                        if (Shielditem.name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x].count += 1;
                        }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] -= Shielditem.Stats[x];
                }
                Shielditem = ((ShieldItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                  //  Stats[x] += equip.Stats[x];
                }

            }
            else if (equip is GreavesItem)
            {
                for (int x = 0; x <= RAM.MasterItemList.Count - 1; x++)
                {
                    if (RAM.MasterItemList[x].name != "None")
                    {
                        if (Greavesitem.name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x].count += 1;
                        }
                    }
                }
                for (int x = 0; x <= 14; x++)
                {
                   // Stats[x] -= Greavesitem.Stats[x];
                }
                Greavesitem = ((GreavesItem)equip);
                for (int x = 0; x <= 14; x++)
                {
                  //  Stats[x] += equip.Stats[x];
                }
            }
            else if (equip is AccessoryItem)
            {
            }
            for (int x = 0; x <= RAM.MasterItemList.Count -1; x++)
            {
                if (RAM.MasterItemList[x].name != "None")
                {
                    if (equip.name == RAM.MasterItemList[x].name)
                    {
                        RAM.MasterItemList[x].count -= 1;
                    }
                }
            }
        }
    
    }
    class TestPlayer : Player
    {
        public TestPlayer(int ID, Vector2 Posistion, Vector2 Offset)
            : base(ID, Posistion, Offset, 0, 10)
        {
            name = "Valvatorez";
            ProfileSprite = "ValAvatar";
            Level = 255;
            MaxHP = 3723;
            MaxMP = 2103;
            MaxSP = 2443;
            HP = 3723;
            MP = 2103;
            SP = 2443;
            ATK = 2463;
            DEF = 1623;
            INT = 1107;
            RES = 850;
            SPD = 999999;
            EVD = 335;
            EXP = 304;
                            WalkForwardAnimation = new Animation(@"Val_Move_Forward\Val_Walk_Forward-1");
                WalkLeftAnimation = new Animation(@"Val_Move_Left\Val_Walk_Left-1");
                WalkRightAnimation = new Animation(@"Val_Move_Right\Val_Walk_Right-1");
                WalkBackwardAnimation = new Animation(@"Val_Move_Backward\Val_Walk_Backrward-1");
                WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
                WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
                WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
                WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
                ForwardStandAnimation = new Animation(@"Val_Standing_Forward\Val_Standing_Forward-1");
                BackwardStandAnimation = new Animation(@"Val_Standing_Backward\Val_Standing_Backward-1");
                LeftStandAnimation = new Animation(@"Val_Standing_Left\Val_Standing_Left-1");
                RightStandAnimation = new Animation(@"Val_Standing_Right\Val_Standing_Right-1");
                SetCurrentAnimation(ForwardStandAnimation);
        }
        public void Update(GameTime gametime, Animation ani)
        {
            base.Update(gametime);
        }
    }
    class TestPlayer2 : Player
    {
        public TestPlayer2(int ID, Vector2 Posistion, Vector2 Offset)
            : base(ID, Posistion, Offset, 1, 10)
        {
            name = "Fuka";
            ProfileSprite = "FukaAva";
            Level = 155;
            MaxHP = 4423;
            MaxMP = 103;
            MaxSP = 3143;
            HP = 4423;
            MP = 103;
            SP = 3143;
            ATK = 2563;
            DEF = 1923;
            INT = 307;
            RES = 250;
            SPD = 999999;
            EVD = 345;
            EXP = 304;
            WalkForwardAnimation = new Animation(@"Fuka_Move_Forward\Fuka_Walk_Forward-1");
            WalkLeftAnimation = new Animation(@"Fuka_Move_Left\Fuka_Walk_Left-1");
            WalkRightAnimation = new Animation(@"Fuka_Move_Right\Fuka_Walk_Right-1");
            WalkBackwardAnimation = new Animation(@"Fuka_Move_Backward\Fuka_Walk_Backrward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Fuka_Standing_Forward\Fuka_Standing_Forward-1");
            BackwardStandAnimation = new Animation(@"Fuka_Standing_Backward\Fuka_Standing_Backward-1");
            LeftStandAnimation = new Animation(@"Fuka_Standing_Left\Fuka_Standing_Left-1");
            RightStandAnimation = new Animation(@"Fuka_Standing_Right\Fuka_Standing_Right-1");
            SetCurrentAnimation(ForwardStandAnimation);
        }
        public void Update(GameTime gametime, Animation ani)
        {
            base.Update(gametime);
        }
    }
    class TestPlayer3 : Player
    {
        public TestPlayer3(int ID, Vector2 Posistion, Vector2 Offset)
            : base(ID, Posistion, Offset, 2, 10)
        {
            name = "Artina";
            ProfileSprite = "ArtAvatar";
            Level = 88;
            MaxHP = 1423;
            MaxMP = 3703;
            MaxSP = 403;
            HP = 1423;
            MP = 3703;
            SP = 403;
            ATK = 963;
            DEF = 1123;
            INT = 2307;
            RES = 1450;
            SPD = 620;
            EVD = 30;
            EXP = 304;
            WalkForwardAnimation = new Animation(@"Art_Move_Forward\Art_Walk_Forward-1");
            WalkLeftAnimation = new Animation(@"Art_Move_Left\Art_Walk_Left-1");
            WalkRightAnimation = new Animation(@"Art_Move_Right\Art_Walk_Right-1");
            WalkBackwardAnimation = new Animation(@"Art_Move_Backward\Art_Walk_Backward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Art_Standing_Forward\Art_Standing_Forward-1");
            BackwardStandAnimation = new Animation(@"Art_Standing_Backward\Art_Standing_Backward-1");
            LeftStandAnimation = new Animation(@"Art_Standing_Left\Art_Standing_Left-1");
            RightStandAnimation = new Animation(@"Art_Standing_Right\Art_Standing_Right-1");
            SetCurrentAnimation(ForwardStandAnimation);
        }
        public void Update(GameTime gametime, Animation ani)
        {
            base.Update(gametime);
        }
    }
    class TestPlayer4 : Player
    {
        public TestPlayer4(int ID, Vector2 Posistion, Vector2 Offset)
            : base(ID, Posistion, Offset, 1, 10)
        {
            name = "Test Enemy";
            ProfileSprite = "GigAva";
            Level = 120;
            MaxHP = 3423;
            MaxMP = 3103;
            MaxSP = 2143;
            HP = 3423;
            MP = 3103;
            SP = 2143;
            ATK = 1563;
            DEF = 1523;
            INT = 1207;
            RES = 1050;
            SPD = 1720;
            EVD = 524;
            EXP = 304;
            WalkForwardAnimation = new Animation(@"Fuka_Move_Forward\Fuka_Walk_Forward-1");
            WalkLeftAnimation = new Animation(@"Fuka_Move_Left\Fuka_Walk_Left-1");
            WalkRightAnimation = new Animation(@"Fuka_Move_Right\Fuka_Walk_Right-1");
            WalkBackwardAnimation = new Animation(@"Fuka_Move_Backward\Fuka_Walk_Backrward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Fuka_Standing_Forward\Fuka_Standing_Forward-1");
            BackwardStandAnimation = new Animation(@"Fuka_Standing_Backward\Fuka_Standing_Backward-1");
            LeftStandAnimation = new Animation(@"Fuka_Standing_Left\Fuka_Standing_Left-1");
            RightStandAnimation = new Animation(@"Fuka_Standing_Right\Fuka_Standing_Right-1");
            SetCurrentAnimation(ForwardStandAnimation);
        }
        public void Update(GameTime gametime, Animation ani)
        {
            base.Update(gametime);
        }
    }
    class TestPlayer5 : Player
    {
        public TestPlayer5(int ID, Vector2 Posistion, Vector2 Offset)
            : base(ID, Posistion, Offset, 0, 10)
        {
            name = "Test Enemy";
            ProfileSprite = "PrireeAva";
            Level = 255;
            MaxHP = 2265;
            MaxMP = 2342;
            MaxSP = 2342;
            HP = 2265;
            MP = 2342;
            SP = 2342;
            ATK = 2432;
            DEF = 2342;
            INT = 1234;
            RES = 756;
            SPD = 2345;
            EVD = 760;
            EXP = 304;

            WalkForwardAnimation = new Animation(@"Val_Move_Forward\Val_Walk_Forward-1");
            WalkLeftAnimation = new Animation(@"Val_Move_Left\Val_Walk_Left-1");
            WalkRightAnimation = new Animation(@"Val_Move_Right\Val_Walk_Right-1");
            WalkBackwardAnimation = new Animation(@"Val_Move_Backward\Val_Walk_Backrward-1");
            WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
            WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
            WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
            WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");
            ForwardStandAnimation = new Animation(@"Val_Standing_Forward\Val_Standing_Forward-1");
            BackwardStandAnimation = new Animation(@"Val_Standing_Backward\Val_Standing_Backward-1");
            LeftStandAnimation = new Animation(@"Val_Standing_Left\Val_Standing_Left-1");
            RightStandAnimation = new Animation(@"Val_Standing_Right\Val_Standing_Right-1");
            SetCurrentAnimation(ForwardStandAnimation);
        }
        public void Update(GameTime gametime, Animation ani)
        {
            base.Update(gametime);
        }
    }
}
