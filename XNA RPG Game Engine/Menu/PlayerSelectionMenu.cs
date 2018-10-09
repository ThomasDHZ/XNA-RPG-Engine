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
    class PlayerSelectionMenu : Menu
    {
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
        int x = 0;
        int y = 0;
        Pointer pointer = new Pointer(RAM.LoadContent(@"arrow"), Vector2.Zero);
        Items SelectedItem;
        bool ItemEffectActive = false;
        List<Player> Players = new List<Player>();
        float time = 0;
        public PlayerSelectionMenu(Items item) : base()
        {
            SelectedItem = item;
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;


            if (keyboardState.IsKeyDown(Keys.Down))
            {
                    y++;
            }
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                    y--;
            }
            else if(keyboardState.IsKeyDown(Keys.Enter))
            {
                if (time >= 150)
                {
                    time = 0;
                    if (SelectedItem.name == "potion")
                    {
                        ((Potion)SelectedItem).Effect(RAM.GetPlayer(0));
                        for (int z = 0; z < RAM.MasterItemList.Count; z++)
                        {
                            if ("potion" == RAM.MasterItemList[z].name)
                            {
                                RAM.MasterItemList[z].count -= 1;
                            }
                        }
                    }
                }
            }
            pointer.SetPosition(new Vector2(218 + (x * 285), 84 + (y * 156)));

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int tempy = 0;
            int tempx = 0;
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
            spriteBatch.Draw(GetPointer().GetTexture(), GetPointer().GetPosition(), Color.White); 
        }
        public Pointer GetPointer()
        {
            return pointer;
        }
        public Items GetSelectedItem()
        {
            return SelectedItem;
        }
        public void LoadPlayers(Player players)
        {
            Players.Add(players);
        }
        public bool GetItemEffectFlag()
        {
            return ItemEffectActive;
        }
        public void SetItemEffectFlag(bool effect)
        {
            ItemEffectActive = effect;
        }

    }
}
