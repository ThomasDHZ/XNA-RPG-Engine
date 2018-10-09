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
    class EquipmentMenu : Menu
    {
        Pointer pointer = new Pointer(RAM.LoadContent(@"arrow"), Vector2.Zero);
        string[] stats;
        string[] equipment;
        EquipmentItems[] Equipment;
        int[] statsnum;
        int pointerpoint = 0;
        int playerindex = 0;
        int Equipmenttype = 0;
        int ListPoint = 0;

        SpriteFont Font1;
        List<Items> EquipmentItemList = new List<Items>();

        public bool Equipmentmenuflag = true;

        public EquipmentMenu()
            : base()
        {
            Font1 = RAM.GetFont(0);
            stats = new string[10];
            statsnum = new int[10];
            stats[0] = "LV";
            stats[1] = "HP";
            stats[2] = "MP";
            stats[3] = "SP";
            stats[4] = "ATK";
            stats[5] = "DEF";
            stats[6] = "INT";
            stats[7] = "RES";
            stats[8] = "SPD";
            stats[9] = "EVD";
            Equipment = new EquipmentItems[10];
            equipment = new string[10];
            equipment[0] = "Weapon";
            equipment[1] = "Helmet";
            equipment[2] = "Armor";
            equipment[3] = "Bracers";
            equipment[4] = "Shield";
            equipment[5] = "Greaves";
            equipment[6] = "Accessory";
            equipment[7] = "Accessory";
            equipment[8] = "Accessory";
            equipment[9] = "Accessory";
           // EquipmentItemList.Add(new WeaponItem());
            //EquipmentItemList.Add(new HelmetItem());
            //EquipmentItemList.Add(new ArmorItem());
            //EquipmentItemList.Add(new BracersItem());
            //EquipmentItemList.Add(new ShieldItem());
            //EquipmentItemList.Add(new GreavesItem());

            //for(int x = 0; x <= RAM.PlayerList.Count - 1
            //RAM.PlayerList
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (Equipmentmenuflag == true)
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (playerindex >= RAM.PlayerList.Count - 1)
                    {
                        playerindex = 0;
                    }
                    else
                    {
                        playerindex++;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (playerindex <= 0)
                    {
                        playerindex = RAM.PlayerList.Count - 1;
                    }
                    else
                    {
                        playerindex--;
                    }
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (pointerpoint >= equipment.Length - 1)
                    {
                        pointerpoint = 0;
                    }
                    else
                    {
                        pointerpoint++;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (pointerpoint <= 0)
                    {
                        pointerpoint = equipment.Length - 1;
                    }
                    else
                    {
                        pointerpoint--;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    Equipmenttype = pointerpoint;
                    Equipmentmenuflag = false;
                }
                statsnum[0] = RAM.PlayerList[playerindex].Level;
                statsnum[1] = RAM.PlayerList[playerindex].MaxHP;
                statsnum[2] = RAM.PlayerList[playerindex].MaxMP;
                statsnum[3] = RAM.PlayerList[playerindex].MaxSP;
                statsnum[4] = RAM.PlayerList[playerindex].ATK;
                statsnum[5] = RAM.PlayerList[playerindex].DEF;
                statsnum[6] = RAM.PlayerList[playerindex].INT;
                statsnum[7] = RAM.PlayerList[playerindex].RES;
                statsnum[8] = RAM.PlayerList[playerindex].SPD;
                statsnum[9] = RAM.PlayerList[playerindex].EVD;
                Equipment[0] = RAM.PlayerList[playerindex].Weaponitem;
                Equipment[1] = RAM.PlayerList[playerindex].Helmetitem;
                Equipment[2] = RAM.PlayerList[playerindex].Armoritem;
                Equipment[3] = RAM.PlayerList[playerindex].Bracersitem;
                Equipment[4] = RAM.PlayerList[playerindex].Shielditem;
                Equipment[5] = RAM.PlayerList[playerindex].Greavesitem;
                Equipment[6] = RAM.PlayerList[playerindex].Accessoryitem1;
                Equipment[7] = RAM.PlayerList[playerindex].Accessoryitem2;
                Equipment[8] = RAM.PlayerList[playerindex].Accessoryitem3;
                Equipment[9] = RAM.PlayerList[playerindex].Accessoryitem4;
                pointer.SetPosition(new Vector2(680, 320 + (pointerpoint * 30)));
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (ListPoint >= EquipmentItemList.Count - 1)
                    {
                        ListPoint = 0;
                    }
                    else
                    {
                        ListPoint++;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (ListPoint <= 0)
                    {
                        ListPoint = EquipmentItemList.Count - 1;
                    }
                    else
                    {
                        ListPoint--;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    Equipmentmenuflag = true;
                }
                else if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    for (int x = 0; x <= RAM.GetItemListCount(); x++)
                    {
                        if (RAM.PlayerList[playerindex].Weaponitem == RAM.MasterItemList[x])
                        {
                            RAM.MasterItemList.Remove(RAM.MasterItemList[x]);
                        }
                    }
                    if (0 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Weaponitem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((WeaponItem)EquipmentItemList[ListPoint]));
                    }
                    else if (1 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Helmetitem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((HelmetItem)EquipmentItemList[ListPoint]));
                    }
                    else if (2 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Armoritem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((ArmorItem)EquipmentItemList[ListPoint]));
                    }
                    else if (3 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Bracersitem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((BracersItem)EquipmentItemList[ListPoint]));

                    }
                    else if (4 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Shielditem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((ShieldItem)EquipmentItemList[ListPoint]));
                    }
                    else if (5 == Equipmenttype)
                    {
                        RAM.MasterItemList.Add(RAM.PlayerList[playerindex].Greavesitem);
                        ((TestPlayer)RAM.GetPlayer(playerindex)).SetEquipment(((GreavesItem)EquipmentItemList[ListPoint]));
                    }
                    ListPoint = 0;
                    Equipmentmenuflag = true;
                }
               // EquipmentItemList = RefeshList(EquipmentItemList);

                if (0 == Equipmenttype)
                {
                    //EquipmentItemList.Add(new WeaponItem());
                }
                else if (1 == Equipmenttype)
                {
                    //EquipmentItemList.Add(new HelmetItem());
                }
                else if (2 == Equipmenttype)
                {
                    //EquipmentItemList.Add(new ArmorItem());
                }
                else if (3 == Equipmenttype)
                {
                    //EquipmentItemList.Add(new BracersItem());
                }
                else if (4 == Equipmenttype)
                {
                   // EquipmentItemList.Add(new ShieldItem());
                }
                else if (5 == Equipmenttype)
                {
                    //EquipmentItemList.Add(new GreavesItem());
                }
                for (int x = 0; x <= RAM.GetItemListCount(); x++)
                {
                    if (2 == RAM.GetItem(x).type) // 2 == Equipment Items
                    {
                        //if (((EquipmentItems)RAM.GetItem(x)).EquipmentType == Equipmenttype)
                       // {
                         //   if (RAM.GetItem(x).count >= 1)
                         //   {
                         //       EquipmentItemList.Add(RAM.MasterItemList[x]);
                        //    }
                       // }
                    }
                }
                pointer.SetPosition(new Vector2(680, 320 + (ListPoint * 30)));
            }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Equipmentmenuflag == true)
            {
                for (int x = 0; x <= 8; x++)
                {
                    Vector2 FontOrigin = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos = new Vector2(100, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, GetText(x), FontPos, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                    Vector2 FontOrigin2 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos2 = new Vector2(300, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, GetStatText(x).ToString(), FontPos2, Color.Yellow, 0, FontOrigin2, 1.0f, SpriteEffects.None, 0.5f);
                    Vector2 FontOrigin3 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos3 = new Vector2(700, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, equipment[x], FontPos3, Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                    Vector2 FontOrigin4 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos4 = new Vector2(900, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, Equipment[x].name, FontPos4, Color.Yellow, 0, FontOrigin4, 1.0f, SpriteEffects.None, 0.5f);
                }
            }
            else
            {
                for (int x = 0; x <= 8; x++)
                {
                    Vector2 FontOrigin = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos = new Vector2(100, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, GetText(x), FontPos, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                    Vector2 FontOrigin2 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos2 = new Vector2(300, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, GetStatText(x).ToString(), FontPos2, Color.Yellow, 0, FontOrigin2, 1.0f, SpriteEffects.None, 0.5f);
                  
                }
                spriteBatch.DrawString(Font1, RAM.GetPlayer(playerindex).Weaponitem.name, new Vector2(500, 350), Color.Yellow, 0, Font1.MeasureString(RAM.GetPlayer(playerindex).Weaponitem.name) / 2, 1.0f, SpriteEffects.None, 0.5f);
              /* int MaxHP = RAM.PlayerList[playerindex].MaxHP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxHP;
                int MaxMP = RAM.PlayerList[playerindex].MaxMP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxMP;
                int MaxSP = RAM.PlayerList[playerindex].MaxSP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxSP;
                int HP = RAM.PlayerList[playerindex].HP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxHP;
                int MP = RAM.PlayerList[playerindex].MP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxMP;
                int SP = RAM.PlayerList[playerindex].SP + ((EquipmentItems)EquipmentItemList[ListPoint]).MaxSP;
                int ATK = RAM.PlayerList[playerindex].ATK + ((EquipmentItems)EquipmentItemList[ListPoint]).ATK;
                int DEF = RAM.PlayerList[playerindex].DEF + ((EquipmentItems)EquipmentItemList[ListPoint]).DEF;
                int INT = RAM.PlayerList[playerindex].INT + ((EquipmentItems)EquipmentItemList[ListPoint]).INT;
                int RES = RAM.PlayerList[playerindex].RES + ((EquipmentItems)EquipmentItemList[ListPoint]).RES;
                int SPD = RAM.PlayerList[playerindex].SPD + ((EquipmentItems)EquipmentItemList[ListPoint]).SPD;
                int EVD = RAM.PlayerList[playerindex].EVD + ((EquipmentItems)EquipmentItemList[ListPoint]).EVD;*

                Color Green = Color.Green;
                Color Red = Color.Red;
                Vector2 FontOrigin3 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                spriteBatch.DrawString(Font1, MaxHP.ToString(), new Vector2(500, 350), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, MaxMP.ToString(), new Vector2(500, 380), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, MaxSP.ToString(), new Vector2(500, 410), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                // spriteBatch.DrawString(Font1, HP.ToString(), new Vector2(500, 410), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                //spriteBatch.DrawString(Font1, MP.ToString(), new Vector2(500, 440), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                //spriteBatch.DrawString(Font1, SP.ToString(), new Vector2(500, 470), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                if (ATK == (ATK = RAM.PlayerList[playerindex].Stats[(int)stats.kATK] + ((EquipmentItems)EquipmentItemList[ListPoint]).Stats[(int)stats.kATK]) + ((EquipmentItems)EquipmentItemList[ListPoint]).ATK)
                {
                    spriteBatch.DrawString(Font1, ATK.ToString(), new Vector2(500, 440), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                }
                else if (ATK < (ATK = RAM.PlayerList[playerindex].Stats[(int)stats.kATK] + ((EquipmentItems)EquipmentItemList[ListPoint]).Stats[(int)stats.kATK]) + ((EquipmentItems)EquipmentItemList[ListPoint]).ATK)
                {
                    spriteBatch.DrawString(Font1, ATK.ToString(), new Vector2(500, 440), Color.Green, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                }
                else if (ATK > (ATK = RAM.PlayerList[playerindex].Stats[(int)stats.kATK] + ((EquipmentItems)EquipmentItemList[ListPoint]).Stats[(int)stats.kATK]) + ((EquipmentItems)EquipmentItemList[ListPoint]).ATK)
                {
                    spriteBatch.DrawString(Font1, ATK.ToString(), new Vector2(500, 440), Color.DarkGreen, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                }*/


                /*spriteBatch.DrawString(Font1, DEF.ToString(), new Vector2(500, 470), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, INT.ToString(), new Vector2(500, 500), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, RES.ToString(), new Vector2(500, 530), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, SPD.ToString(), new Vector2(500, 560), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(Font1, EVD.ToString(), new Vector2(500, 590), Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);*/
                for (int x = 0; x <= EquipmentItemList.Count - 1; x++)
                {
                    Vector2 FontOrigin4 = Font1.MeasureString("fdgsdfgSFDG") / 2;
                    Vector2 FontPos4 = new Vector2(900, 320 + (x * 30));
                    spriteBatch.DrawString(Font1, EquipmentItemList[x].name, FontPos4, Color.Yellow, 0, FontOrigin4, 1.0f, SpriteEffects.None, 0.5f);
                }
            }
            spriteBatch.Draw(pointer.GetTexture(), pointer.GetPosition(), Color.White);
            //  Vector2 FontOrigin3 = Font1.MeasureString(Players[GetPlayerIndex()].name) / 2;
            // Vector2 FontPos3 = new Vector2(300, 120);
            //  spriteBatch.DrawString(Font1, Players[GetPlayerIndex()].name, FontPos3, Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
        }
        public string GetText(int index)
        {
            return stats[index];
        }
        public int GetStatText(int index)
        {
            return statsnum[index];
        }
        public int GetPlayerIndex()
        {
            return playerindex;
        }
        public void EquipmentMenuOpen(bool state)
        {
            /*if (state == false)
            {
                while (Players.Count >= 1)
                {
                    Players.Remove(Players[0]);
                }
            }*/
        }

    }
}
