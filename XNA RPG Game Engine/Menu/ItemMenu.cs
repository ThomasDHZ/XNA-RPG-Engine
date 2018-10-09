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
    class ItemMenu : Menu
    {
        const int ITEM_Y_MULTIPLIER = 30;
        const int MAX_ITEMS_SHOWN = 54;//Limit of Items shown on screen in the item menus.
        const int ITEMSPERROW = 3;
        const int LINE_COUNT_OF_CAMERA_VEIW = 17; //The number of lines that you can go down before the Item Cam goes down a another line.
        public static List<Items> ItemList = new List<Items>();
        int itemnum = 0;
        bool ItemType = true;
        int ItemTypeNum = 0;
        int ItemTypeSelected = 0;
        Pointer pointer = new Pointer(RAM.LoadContent(@"arrow"),Vector2.Zero);
        Vector2 point;
        int MasterPointY = 0;
        int showingline = 0;
        int maxshowingline = 0;
        int type;
        int px = 0;
        int py = 0;
        float time = 0;
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
        //List<Items> item = new List<Items>();
        Menu menu;
        bool MenuFlag = false;

        public ItemMenu() : base()
        {
            point = Vector2.Zero;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            maxshowingline = ItemList.Count;
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //////////////////////////////////////////////////////////////
                
            if ((maxshowingline % ITEMSPERROW) >= 1)
            {
                maxshowingline /= ITEMSPERROW;
                maxshowingline++;
            }
            else
            {
                maxshowingline /= ITEMSPERROW;
            }
            ItemTypeSelected = ItemTypeNum;
            if (ItemType == true)
            {
                showingline = 0;
                point.X = 0;
                point.Y = 0;
                MasterPointY = 0;
                itemnum = 0;
            }
            px = (int)point.X;
            py = MasterPointY * 3;
            //////////////////////////////////////////////////////////////
            if (menu is PlayerSelectionMenu)
            {
                if(((PlayerSelectionMenu)menu).GetSelectedItem().count == 0)
                {
                    menu = null;
                }
            }
            if (menu == null)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    if (time >= 150)
                    {
                        time = 0;
                        if (ItemType == true)
                        {
                            ItemType = false;
                        }
                        else
                        {
                            if (px >= 0 && py >= 0)
                            {
                                if (ItemList.Count > px + py)
                                {
                                    switch (ItemList[px + py].type)
                                    {
                                        case 1:
                                            {
                                                menu = new PlayerSelectionMenu(ItemList[px + py]);
                                                MenuFlag = true;
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    ItemType = true;
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (ItemType == false)
                    {
                        if (point.X <= 1)
                        {
                            point.X++;
                            itemnum += 1;
                        }
                        else
                        {
                            if (point.Y == LINE_COUNT_OF_CAMERA_VEIW && (showingline / 3) + LINE_COUNT_OF_CAMERA_VEIW <= maxshowingline)
                            {
                                point.X = 0;
                                showingline += ITEMSPERROW;
                                itemnum += 1;
                                MasterPointY++;
                            }
                            else if (point.Y != LINE_COUNT_OF_CAMERA_VEIW)
                            {
                                point.Y++;
                                MasterPointY++;
                                point.X = 0;
                                itemnum += 1;
                            }
                        }
                    }
                    else
                    {
                        if (ItemTypeNum == 5)
                        {
                            ItemTypeNum = 0;
                        }
                        else
                        {
                            ItemTypeNum++;
                        }
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (ItemType == false)
                    {
                        if (point.X >= 1)
                        {
                            point.X--;
                            itemnum -= 1;
                        }
                        else
                        {
                            if (point.Y == 0)
                            {
                                point.X = 2;
                                MasterPointY--;
                                showingline -= ITEMSPERROW;
                                itemnum -= 1;

                                if (MasterPointY <= 0 && point.Y == 0)
                                {
                                    point.X = 0;
                                    point.Y = 0;
                                    MasterPointY = 0;
                                    showingline = 0;
                                    maxshowingline = 0;
                                }
                            }
                            else
                            {
                                point.Y--;
                                MasterPointY--;
                                point.X = 2;
                                itemnum -= 1;
                            }
                        }
                    }
                    else
                    {
                        if (ItemTypeNum <= 0)
                        {
                            ItemTypeNum = 5;
                        }
                        else
                        {
                            ItemTypeNum--;
                        }
                    }
                }

                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (ItemType == false)
                    {
                        if (point.Y >= LINE_COUNT_OF_CAMERA_VEIW)
                        {
                            if (point.Y != LINE_COUNT_OF_CAMERA_VEIW)
                            {
                                point.Y = 0;
                                MasterPointY = 0;
                            }
                            else
                            {
                                if ((showingline / 3) + LINE_COUNT_OF_CAMERA_VEIW <= maxshowingline)
                                {
                                    showingline += ITEMSPERROW;
                                    itemnum += ITEMSPERROW;
                                    MasterPointY++;
                                }
                            }
                        }
                        else
                        {
                            point.Y++;
                            MasterPointY++;
                            itemnum += ITEMSPERROW;
                        }
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (point.Y <= 0)
                    {
                        if (showingline <= 0)
                        {
                        }
                        else
                        {
                            showingline -= ITEMSPERROW;
                            itemnum -= ITEMSPERROW;
                            MasterPointY--;
                        }
                    }
                    else
                    {
                        point.Y--;
                        MasterPointY--;
                        itemnum -= ITEMSPERROW;
                    }
                }
                //////////////////////////////////////////////////////////////

                for (int x = 0; x <= RAM.GetItemListCount(); x++)
                {
                    if (RAM.MasterItemList[x].count == 0)
                    {
                        for (int z = 0; z <= ItemList.Count - 1; z++)
                        {
                            if (ItemList[z].name == RAM.MasterItemList[z].name)
                            {
                                RAM.MasterItemList.Remove(RAM.MasterItemList[x]);
                                ItemList.Remove(ItemList[z]);
                            }
                        }
                    }
                    for (int y = 0; y <= ItemList.Count - 1; y++)
                    {

                        if (ItemList[y].name == RAM.MasterItemList[x].name)
                        {
                            RAM.MasterItemList[x] = ItemList[y];
                            ItemList.Remove(ItemList[y]);
                        }
                    }
                }
                if (ItemTypeSelected == 0)
                {
                    for (int x = 0; x <= RAM.GetItemListCount(); x++)
                    {
                        if (RAM.GetItem(x).count >= 1)
                        {
                            ItemList.Add(RAM.GetItem(x));
                        }
                    }
                }
                else
                {
                    for (int x = 0; x <= RAM.GetItemListCount(); x++)
                    {
                        if (ItemTypeSelected == RAM.GetItem(x).type)
                        {
                            if (RAM.GetItem(x).count >= 1)
                            {
                                ItemList.Add(RAM.GetItem(x));
                            }
                        }
                    }
                }
                /////////////////////////////////////////////////////////////
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    if (time >= 150)
                    {
                        time = 0;
                        menu = null;
                        MenuFlag = false;
                    }
                }
            }
            ////////////////////////////////////////////////////////////////
            if (ItemType == false)
            {
                pointer.SetPosition(new Vector2(218 + (point.X * 285), 84 + (point.Y * 30)));
            }
            else
            {
                pointer.SetPosition(new Vector2((ItemTypeNum * 214), 60));
            }
            /////////////////////////////////////////////////////////////////
            if (menu is PlayerSelectionMenu)
            {
                ((PlayerSelectionMenu)menu).Update(gameTime);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int y = 0;
            int x = 0;
            int count = 0;
            int ItemPassed = showingline;
            spriteBatch.Draw(background6, new Vector2(0, 636), Color.White);
            spriteBatch.Draw(background2, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(background7, new Vector2(0, 48), Color.White);
            spriteBatch.Draw(background8, new Vector2(214, 48), Color.White);
            spriteBatch.Draw(background7, new Vector2(428, 48), Color.White);
            spriteBatch.Draw(background8, new Vector2(642, 48), Color.White);
            spriteBatch.Draw(background7, new Vector2(856, 48), Color.White);
            spriteBatch.Draw(background8, new Vector2(1070, 48), Color.White);
            spriteBatch.Draw(background9, new Vector2(214, 72), Color.White);
            spriteBatch.Draw(background10, new Vector2(0, 72), Color.White);
            spriteBatch.Draw(background10, new Vector2(1066, 72), Color.White);
            spriteBatch.DrawString(RAM.GetFont(4), "All", new Vector2(107, 60), Color.White, 0, RAM.GetFont(0).MeasureString("All") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(RAM.GetFont(4), "Usable Items", new Vector2(321, 60), Color.White, 0, RAM.GetFont(0).MeasureString("Usable Items") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(RAM.GetFont(4), "Equipment", new Vector2(535, 60), Color.White, 0, RAM.GetFont(0).MeasureString("Equipment") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(RAM.GetFont(4), "Battle Items", new Vector2(749, 60), Color.White, 0, RAM.GetFont(0).MeasureString("Battle Items") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(RAM.GetFont(4), "Synthesizing", new Vector2(963, 60), Color.White, 0, RAM.GetFont(0).MeasureString("Synthesizing") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.DrawString(RAM.GetFont(4), "Story Items", new Vector2(1177, 60), Color.White, 0, RAM.GetFont(0).MeasureString("Story Items") / 2, 1.0f, SpriteEffects.None, 0.5f);
            spriteBatch.Draw(pointer.GetTexture(), pointer.GetPosition(), Color.White);

            //////////////////////////////////////////////////////////////////////////////////

            for (int a = 0; a <= ItemList.Count - 1; a++)
            {
                    if (count != MAX_ITEMS_SHOWN)
                    {

                        if (a + ItemPassed < ItemList.Count)
                        {

                            spriteBatch.DrawString(RAM.GetFont(3), ItemList[a + ItemPassed].name, new Vector2(248 + (285 * x), 81 + (ITEM_Y_MULTIPLIER * y)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                            if (ItemTypeSelected != 5)
                            {
                                spriteBatch.DrawString(RAM.GetFont(3), ItemList[a + ItemPassed].count.ToString(), new Vector2(418 + (305 * x), 81 + (ITEM_Y_MULTIPLIER * y)), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                            }
                        }
                        if (ItemList.Count >= itemnum)
                        {
                            if (ItemType == false)
                            {
                                if (px + py >= 0 && px + py <= ItemList.Count -1)
                                {
                                    spriteBatch.DrawString(RAM.GetFont(1), ItemList[px + py].desc, new Vector2(0, 672), Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.5f);
                                    spriteBatch.DrawString(RAM.GetFont(2), ItemList[px + py].name, new Vector2(640, 24), Color.White, 0, RAM.GetFont(2).MeasureString(ItemList[px + py].name) / 2, 1.0f, SpriteEffects.None, 0.5f);
                                }
                            }

                        }
                        x++;
                        count++;
                        if (x == 3)
                        {
                            x = 0;
                            y++;
                        }
                    }
                
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            if (menu is PlayerSelectionMenu)
            {
                ((PlayerSelectionMenu)menu).Draw(spriteBatch);
            }
            ////////////////////////////////////////////////////////////////////////////////////////
        }
            public bool GetItemType()
            {
                return ItemType;
            }
    }

}
