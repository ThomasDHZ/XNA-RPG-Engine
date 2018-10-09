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
    class Potion : UseableItems
    {
        Player Charstats;
        public Potion(int count = 1)
            : base("potion", "It heals you", count)
        {
        }
        public void Effect(Player charstats)
        {
            charstats.HP += 999999999;
            Charstats = charstats;
        }
        public Player GetUpdatedCharStats()
        {
            return Charstats;
        }
    }
    class HIpotion : UseableItems
    {
        Player Charstats;
        public HIpotion(int count = 1)
            : base("HIpotion", "It heals you", count)
        {
        }
        public void Effect(Player charstats)
        {
            charstats.HP += 999999999;
            Charstats = charstats;
        }
        public Player GetUpdatedCharStats()
        {
            return Charstats;
        }
    }
    class Megapotion : UseableItems
    {
        Player Charstats;
        public Megapotion(int count = 1)
            : base("Megapotion", "It heals you", count)
        {
        }
        public void Effect(Player charstats)
        {
            charstats.HP += 999999999;
            Charstats = charstats;
        }
        public Player GetUpdatedCharStats()
        {
            return Charstats;
        }
    }
    class Extremepotion : UseableItems
    {
        Player Charstats;
        public Extremepotion(int count = 1)
            : base("Extremepotion", "It heals you", count)
        {
        }
        public void Effect(Player charstats)
        {
            charstats.HP += 999999999;
            Charstats = charstats;
        }
        public Player GetUpdatedCharStats()
        {
            return Charstats;
        }
    }
}
