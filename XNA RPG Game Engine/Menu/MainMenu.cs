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
    public class MainMenu : Menu
    {
        const int MENUNUMBER = 7;
        Vertical_Pointer pointer = new Vertical_Pointer(new Vector2(30, 90), 6, 30);
        string[] MenuItems;
        Menu menu = null;
        float time = 0;
        int pointerpoint = 0;
        bool TimeMove = true;
        bool MainMenuFlag = true;

        Texture2D background = RAM.LoadContent(@"background");
        Texture2D background2 = RAM.LoadContent(@"background2"); 
        Texture2D background3 = RAM.LoadContent(@"background3"); 
            Texture2D background4 = RAM.LoadContent(@"background4"); 
        Texture2D background5 = RAM.LoadContent(@"background5"); 
            Texture2D background6 = RAM.LoadContent(@"background6");
        Texture2D background7 = RAM.LoadContent(@"background7"); 
            Texture2D background8 = RAM.LoadContent(@"background8"); 
        Texture2D background9 = RAM.LoadContent(@"background9"); 
            Texture2D background10 = RAM.LoadContent(@"background10"); 
        Texture2D Avatar1 = RAM.LoadContent(@"Avatar1"); 
            Texture2D PartyStats = RAM.LoadContent(@"PartyStats"); 

        public MainMenu() : base()
        {
            MenuItems = new string[MENUNUMBER];
            MenuItems[0] = "Items";
            MenuItems[1] = "Skills";
            MenuItems[2] = "Equipment";
            MenuItems[3] = "Tactics";
            MenuItems[4] = "Status";
            MenuItems[5] = "Settings";
            MenuItems[6] = "File";
            
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            pointer.Update(gametime);
            if (TimeMove == true)
            {
                time += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            }
            if (time >= 150)
            {
                if (keyboardState.IsKeyDown(Keys.Down)
                    || keyboardState.IsKeyDown(Keys.Up)
                    || keyboardState.IsKeyDown(Keys.Right)
                    || keyboardState.IsKeyDown(Keys.Left)
                    || keyboardState.IsKeyDown(Keys.Enter)
                    || keyboardState.IsKeyDown(Keys.Escape))
                {
                    time = 0;
                }
                if (MainMenuFlag == true)
                {
                    if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        if (pointerpoint >= MenuItems.Length - 1)
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
                            pointerpoint = MenuItems.Length - 1;
                        }
                        else
                        {
                            pointerpoint--;
                        }
                    }
                    if (keyboardState.IsKeyDown(Keys.Enter))
                    {
                        MainMenuFlag = false;
                        switch (pointerpoint)
                        {
                            case 0:
                                {
                                    menu = new ItemMenu();
                                    break;
                                }
                            case 1:
                                {
                                    menu = new SkillsMenu();
                                    break;
                                }
                            case 2:
                                {
                                    menu = new EquipmentMenu();
                                    break;
                                }
                            case 3:
                                {
                                    menu = new TacticsMenu();
                                    break;
                                }
                            case 4:
                                {
                                    menu = new StatusMenu();
                                    break;
                                }
                            case 5:
                                {
                                    menu = new SettingsMenu();
                                    break;
                                }
                            case 6:
                                {
                                    menu = new FileMenu();
                                    break;
                                }
                        }
                    }
                }
                else if(menu != null)
                {
                    if (keyboardState.IsKeyDown(Keys.Escape))
                    {
                        if (menu is ItemMenu)
                        {
                            if (((ItemMenu)menu).GetItemType() == true)
                            {
                                
                                MainMenuFlag = true;
                                menu = null;
                            }
                        }
                        else
                        {
                            MainMenuFlag = true;
                            menu = null;
                        }
                    }
                }
                if (menu is ItemMenu)
                {
                    ((ItemMenu)menu).Update(gametime);
                }
                else if (menu is SkillsMenu)
                {
                    ((SkillsMenu)menu).Update(gametime);
                }
                else if (menu is EquipmentMenu)
                {
                    ((EquipmentMenu)menu).Update(gametime);
                }
                else if (menu is TacticsMenu)
                {
                    ((TacticsMenu)menu).Update(gametime);
                }
                else if (menu is StatusMenu)
                {
                    ((StatusMenu)menu).Update(gametime);
                }
                else if (menu is SettingsMenu)
                {
                    ((SettingsMenu)menu).Update(gametime);
                }
                else if (menu is FileMenu)
                {
                    ((FileMenu)menu).Update(gametime);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (MainMenuFlag == true)
            {
                int tempy = 0;
                int tempx = 0;
                spriteBatch.Draw(background, new Vector2(0, 48), Color.White);
                spriteBatch.Draw(background, new Vector2(1120, 48), Color.White);
                spriteBatch.Draw(background2, new Vector2(0, 672), Color.White);
                spriteBatch.Draw(background2, new Vector2(0, 0), Color.White);
                spriteBatch.Draw(background3, new Vector2(160, 48), Color.White);

                for (int x = 0; x <= RAM.GetPlayerCount(); x++)
                {
                    if ((x % 2) == 1)
                    {

                        spriteBatch.Draw(background4, new Vector2(160 + (480 * tempx), 48 + (156 * tempy)), Color.White);
                        spriteBatch.Draw(Avatar1, new Vector2(160 + (480 * tempx), 48 + (156 * tempy)), Color.White);
                        spriteBatch.DrawString(RAM.GetFont(1), "LV", new Vector2(448 + (480 * tempx), 61 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "HP", new Vector2(256 + (480 * tempx), 89 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "MP", new Vector2(256 + (480 * tempx), 119 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "SP", new Vector2(256 + (480 * tempx), 145 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "Next LV", new Vector2(256 + (480 * tempx), 171 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), RAM.GetPlayer(x).name, new Vector2(272 + (480 * tempx), 74 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).name) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).Level.ToString(), new Vector2(500 + (480 * tempx), 58 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).HP.ToString() + "/" + RAM.GetPlayer(x).MaxHP.ToString(), new Vector2(448 + (480 * tempx), 100 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).HP.ToString() + "/" + RAM.GetPlayer(x).MaxHP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).MP.ToString() + "/" + RAM.GetPlayer(x).MaxMP.ToString(), new Vector2(448 + (480 * tempx), 126 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).MP.ToString() + "/" + RAM.GetPlayer(x).MaxMP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).SP.ToString() + "/" + RAM.GetPlayer(x).MaxSP.ToString(), new Vector2(448 + (480 * tempx), 152 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).SP.ToString() + "/" + RAM.GetPlayer(x).MaxSP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).EXP.ToString(), new Vector2(448 + (480 * tempx), 168 + (156 * tempy)), Color.White, 0, new Vector2(-100, 0), 1.0f, SpriteEffects.None, 0.5f);
                        tempy++;
                    }
                    else
                    {
                        spriteBatch.Draw(background5, new Vector2(160 + (480 * tempx), 48 + (156 * tempy)), Color.White);
                        spriteBatch.Draw(Avatar1, new Vector2(160 + (480 * tempx), 48 + (156 * tempy)), Color.White);
                        spriteBatch.DrawString(RAM.GetFont(1), "LV", new Vector2(448 + (480 * tempx), 61 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "HP", new Vector2(256 + (480 * tempx), 89 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "MP", new Vector2(256 + (480 * tempx), 119 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "SP", new Vector2(256 + (480 * tempx), 145 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), "Next LV", new Vector2(256 + (480 * tempx), 171 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(1), RAM.GetPlayer(x).name, new Vector2(272 + (480 * tempx), 74 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).name) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).Level.ToString(), new Vector2(500 + (480 * tempx), 58 + (156 * tempy)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).HP.ToString() + "/" + RAM.GetPlayer(x).MaxHP.ToString(), new Vector2(448 + (480 * tempx), 100 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).HP.ToString() + "/" + RAM.GetPlayer(x).MaxHP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).MP.ToString() + "/" + RAM.GetPlayer(x).MaxMP.ToString(), new Vector2(448 + (480 * tempx), 126 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).MP.ToString() + "/" + RAM.GetPlayer(x).MaxMP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).SP.ToString() + "/" + RAM.GetPlayer(x).MaxSP.ToString(), new Vector2(448 + (480 * tempx), 152 + (156 * tempy)), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.GetPlayer(x).SP.ToString() + "/" + RAM.GetPlayer(x).MaxSP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                        spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(x).EXP.ToString(), new Vector2(448 + (480 * tempx), 168 + (156 * tempy)), Color.White, 0, new Vector2(-100, 0), 1.0f, SpriteEffects.None, 0.5f);
                        tempx++;
                        if (tempx == 2)
                        {
                            tempx = 0;
                        }
                    }
                }
                for (int x = 0; x <= MENUNUMBER - 1; x++)
                {
                    Vector2 FontOrigin = RAM.GetFont(0).MeasureString(MenuItems[x]) / 2;
                    Vector2 FontPos = new Vector2(80, 100 + (x * 30));
                    spriteBatch.DrawString(RAM.GetFont(0), MenuItems[x], FontPos, Color.White, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                    pointer.Draw(spriteBatch);
                }
                int hours = gameTime.TotalGameTime.Hours;
                int minutes = gameTime.TotalGameTime.Minutes;
                int sec = gameTime.TotalGameTime.Seconds;
                string time;
                if (hours >= 10)
                {
                    if (minutes >= 10)
                    {
                        if (sec >= 10)
                        {
                            time = hours.ToString() + ":" + minutes.ToString() + ":" + sec.ToString();
                        }
                        else
                        {
                            time = hours.ToString() + ":" + minutes.ToString() + ":0" + sec.ToString();
                        }
                    }
                    else
                    {
                        if (sec >= 10)
                        {
                            time = hours.ToString() + ":" + minutes.ToString() + ":" + sec.ToString();
                        }
                        else
                        {
                            time = hours.ToString() + ":0" + minutes.ToString() + ":0" + sec.ToString();
                        }
                    }
                }
                else
                {
                    if (minutes >= 10)
                    {
                        if (sec >= 10)
                        {
                            time = "0" + hours.ToString() + ":" + minutes.ToString() + ":" + sec.ToString();
                        }
                        else
                        {
                            time = "0" + hours.ToString() + ":0" + minutes.ToString() + ":0" + sec.ToString();
                        }
                    }
                    else
                    {
                        if (sec >= 10)
                        {
                            time = "0" + hours.ToString() + ":0" + minutes.ToString() + ":" + sec.ToString();
                        }
                        else
                        {
                            time = "0" + hours.ToString() + ":0" + minutes.ToString() + ":0" + sec.ToString();
                        }
                    }
                }


                spriteBatch.DrawString(RAM.GetFont(1), "Time", new Vector2(1200, 480), Color.White, 0, RAM.GetFont(0).MeasureString("Time") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), time, new Vector2(1200, 520), Color.White, 0, RAM.GetFont(0).MeasureString(time) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(1), "Money", new Vector2(1200, 540), Color.White, 0, RAM.GetFont(0).MeasureString("Money") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), RAM.Money.ToString(), new Vector2(1200, 560), Color.White, 0, RAM.GetFont(0).MeasureString(RAM.Money.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
            }

            if (menu is ItemMenu)
            {
                ((ItemMenu)menu).Draw(spriteBatch);
            }
            else if (menu is SkillsMenu)
            {
                ((SkillsMenu)menu).Draw(spriteBatch);
            }
            else if (menu is EquipmentMenu)
            {
                ((EquipmentMenu)menu).Draw(spriteBatch);
            }
            else if (menu is TacticsMenu)
            {
                ((TacticsMenu)menu).Draw(spriteBatch);
            }
            else if (menu is StatusMenu)
            {
                ((StatusMenu)menu).Draw(spriteBatch);
            }
            else if (menu is SettingsMenu)
            {
                ((SettingsMenu)menu).Draw(spriteBatch);
            }
            else if (menu is FileMenu)
            {
                ((FileMenu)menu).Draw(spriteBatch);
            }
                
             
        }
        public bool GetMainMenuFlag()
        {
            return MainMenuFlag;
        }
    }
}
