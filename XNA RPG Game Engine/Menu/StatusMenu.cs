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
    class StatusMenu : Menu
    {
        string[] stats;
        int[] statsnum;
        int playerindex = 0;
        List<Player> Players = new List<Player>();
        public StatusMenu()
            : base()
        {
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
        }
        public void AddPlayers(Player player)
        {
            Players.Add(player);
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                if (playerindex >= Players.Count - 1)
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
                    playerindex = Players.Count - 1;
                }
                else
                {
                    playerindex--;
                }
            }

            statsnum[0] = Players[playerindex].Level;
            statsnum[1] = Players[playerindex].HP;
            statsnum[2] = Players[playerindex].MP;
            statsnum[3] = Players[playerindex].SP;
            statsnum[4] = Players[playerindex].ATK;
            statsnum[5] = Players[playerindex].DEF;
            statsnum[6] = Players[playerindex].INT;
            statsnum[7] = Players[playerindex].RES;
            statsnum[8] = Players[playerindex].SPD;
            statsnum[9] = Players[playerindex].EVD;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x <= 8; x++)
            {
                Vector2 FontOrigin = RAM.GetFont(0).MeasureString(GetText(x)) / 2;
                Vector2 FontPos = new Vector2(100, 320 + (x * 30));
                spriteBatch.DrawString(RAM.GetFont(0), GetText(x), FontPos, Color.Yellow, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
                Vector2 FontOrigin2 = RAM.GetFont(0).MeasureString(GetStatText(x).ToString()) / 2;
                Vector2 FontPos2 = new Vector2(300, 320 + (x * 30));
                spriteBatch.DrawString(RAM.GetFont(0), GetStatText(x).ToString(), FontPos2, Color.Yellow, 0, FontOrigin2, 1.0f, SpriteEffects.None, 0.5f);
            }
            Vector2 FontOrigin3 = RAM.GetFont(0).MeasureString(RAM.GetPlayer(GetPlayerIndex()).name) / 2;
            Vector2 FontPos3 = new Vector2(300, 120);
            spriteBatch.DrawString(RAM.GetFont(0), RAM.GetPlayer(GetPlayerIndex()).name, FontPos3, Color.Yellow, 0, FontOrigin3, 1.0f, SpriteEffects.None, 0.5f);
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
        public void StatsMenuOpen(bool state)
        {
            if (state == false)
            {
                while (Players.Count >= 1)
                {
                    Players.Remove(Players[0]);
                }
            }
        }

    }
}
