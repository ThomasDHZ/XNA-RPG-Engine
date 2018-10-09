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
    public static class RAM
    {
        public const int TILESIZE = 64;
        const int ITEM_TYPES = 6; //Areas of diffrent Item types.
        public static ContentManager Content;
        public static List<SpriteFont> Fonts = new List<SpriteFont>();
        public static List<Items> MasterItemList = new List<Items>();
        public static List<MapArea> Maps = new List<MapArea>();
        public static List<Player> PlayerList = new List<Player>();
        public static VisualRAM VRAM = new VisualRAM();
        public static Camera camera;
        public static int Money;
        public static bool BattleFlag = false;
        public static bool OnFoot = true;
        public static bool OnShip = false;
        public static bool OnAirShip = false;
        public static bool TalkFlag = false;
        public static StoryText Storytext = new StoryText();
        public static MapArea MapArea;
        public static void LoadContentMgr(ContentManager content)
        {
            Content = content;
        }
        public static Texture2D LoadContent(string sprite)
        {
            return Content.Load<Texture2D>(sprite);
        }
        public static void Add_Player(Player player)
        {
            PlayerList.Add(player);
        }
        public static void Add_Map(MapArea map)
        {
            Maps.Add(map);
        }
        public static MapArea GetMap(int map)
        {
            return Maps[map];
        }
        public static void Add_Font(SpriteFont font)
        {
            Fonts.Add(font);
        }
        public static SpriteFont GetFont(int font)
        {
            return Fonts[font];
        }
        public static int GetPlayerCount()
        {
            return PlayerList.Count - 1;
        }
        public static void Add_Item(Items item)
        {
            bool AddCount = false;
            for (int x = 0; x <= GetItemListCount(); x++)
            {
                if (item.name == MasterItemList[x].name)
                {
                    MasterItemList[x].count += 1;
                    AddCount = true;
                    break;
                }
            }
            if (AddCount == false)
            {
                MasterItemList.Add(item);
            }
        }
        public static Player GetPlayer(int player)
        {
            return PlayerList[player];
        }
        public static Items GetItem(int item)
        {
            return MasterItemList[item];
        }
        public static int GetItemListCount()
        {
            return MasterItemList.Count - 1;
        }
        public static int HighestNumber(List<int> numlist)
        {
            return 0;
        }
    }
}
