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
 
    public class Items
    {
        public string name;
        public string desc;
        public int count = 0;
        public int type;
        public Items(string Name, string Desc, int Count, int Type)
        {
            name = Name;
            desc = Desc;
            count = Count;
            type = Type;
        }
        public Items(Items Item)
        {
            name = Item.name;
            desc = Item.desc;
            count = Item.count;
            type = Item.type;
        }
        public void Effect()
        {
        }
        public void AddItemCount()
        {
            count++;
        }
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////
    /// </summary>
    public class UseableItems : Items
    {
        public UseableItems(string Name, string Desc, int Count)
            : base(Name, Desc, Count, 1)
        {
        }
    }

    public class EquipmentItems : Items
    {
        public int EquipmentType;
         public int MaxHP = 0;
         public int MaxMP = 0;
         public int MaxSP = 0;
         public int ATK = 0;
         public int DEF = 0;
         public int INT = 0;
         public int RES = 0;
         public int SPD = 0;
         public int EVD = 0;
        public EquipmentItems()
            : base("None", "", 0, 2)
        {
        }
        public EquipmentItems(string Name, string Desc, int Count)
            : base(Name, Desc, Count, 2)
        {
        }
    }
    public class BattleItems : Items
    {
        public BattleItems(string Name, string Desc, int Count)
            : base(Name, Desc, Count, 3)
        {
        }
    }
    public class Synthesizing : Items
    {
        public Synthesizing(string Name, string Desc, int Count)
            : base(Name, Desc, Count, 4)
        {
        }
    }
    public class StoryItems : Items
    {
        public StoryItems(string Name, string Desc, int Count)
            : base(Name, Desc, Count, 5)
        {
        }
    }
}


















