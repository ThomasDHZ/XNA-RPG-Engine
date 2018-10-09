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
    public class WeaponItem : EquipmentItems
    {
        public WeaponItem()
            : base()
        {
            EquipmentType = 0;
        }
        public WeaponItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 0;
        }
    }
    public class HelmetItem : EquipmentItems
    {
        public HelmetItem()
            : base()
        {
            EquipmentType = 1;
        }
        public HelmetItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 1;
        }
    }
    public class ArmorItem : EquipmentItems
    {
        public ArmorItem()
            : base()
        {
            EquipmentType = 2;
        }
        public ArmorItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 2;
        }
    }
    public class BracersItem : EquipmentItems
    {
        public BracersItem()
            : base()
        {
            EquipmentType = 3;
        }
        public BracersItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 3;
        }
    }
    public class ShieldItem : EquipmentItems
    {
        public ShieldItem()
            : base()
        {
            EquipmentType = 4;
        }
        public ShieldItem(string Name, string Desc, int Count)
            : base()
        {
            EquipmentType = 4;
        }
    }
    public class GreavesItem : EquipmentItems
    {
        public GreavesItem()
            : base()
        {
            EquipmentType = 5;
        }
        public GreavesItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 5;
        }
    }
    public class TinGreaves : GreavesItem
    {
        public TinGreaves()
            : base("TinGreaves", "sword made of tin", 1)
        {
        }
    }
    public class AccessoryItem : EquipmentItems
    {
        public AccessoryItem()
            : base()
        {
            EquipmentType = 6;
        }
        public AccessoryItem(string Name, string Desc, int Count)
            : base(Name, Desc, Count)
        {
            EquipmentType = 6;
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>

    public class TinSword : WeaponItem
    {
        public TinSword()
            : base("TinSword", "sword made of tin", 1)
        {
            ATK = 5;
        }
    }
    public class RustySword : WeaponItem
    {
        public RustySword()
            : base("Rusty Sword", "It's a key... to a door", 1)
        {
            ATK = 500;
        }
    }
    public class BrassSword : WeaponItem
    {
        public BrassSword()
            : base("Brass Sword", "It's a key... to a door", 1)
        {
            ATK= 500000;
        }
    }
    public class SilverSword : WeaponItem
    {
        public SilverSword()
            : base("Silver Sword", "It's a key... to a door", 1)
        {
            ATK = 500;
        }
    }
    public class GoldSword : WeaponItem
    {
        public GoldSword()
            : base("Gold Sword", "It's a key... to a door", 1)
        {
            ATK = 500000;
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>

    public class TinHelmet : HelmetItem
    {
        public TinHelmet()
            : base("TinHelmet", "sword made of tin", 1)
        {
            DEF = 5;
        }
    }
    public class RustyHelmet : HelmetItem
    {
        public RustyHelmet()
            : base("RustyHelmet", "It's a key... to a door", 1)
        {
            DEF = 500;
        }
    }
    public class BrassHelmet : HelmetItem
    {
        public BrassHelmet()
            : base("Brass Helmet", "It's a key... to a door", 1)
        {
            DEF = 500000;
        }
    }
    public class SilverHelmet : HelmetItem
    {
        public SilverHelmet()
            : base("Silver Helmet", "It's a key... to a door", 1)
        {
            DEF = 500;
        }
    }
    public class GoldHelmet : HelmetItem
    {
        public GoldHelmet()
            : base("Gold Helmet", "It's a key... to a door", 1)
        {
            DEF = 500000;
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>
    
    public class TinArmor : ArmorItem
    {
        public TinArmor()
            : base("TinArmor", "sword made of tin", 1)
        {
        }
    }
    public class RustyArmor : ArmorItem
    {

        public RustyArmor()
            : base("Rusty Armor", "It's old", 1)
        {
            DEF = 50;
        }
    }
    public class BrassArmor : ArmorItem
    {
        public BrassArmor()
            : base("Brass Armor", "It's a key... to a door", 1)
        {
            DEF = 500000;
        }
    }
    public class SilverArmor : ArmorItem
    {
        public SilverArmor()
            : base("Silver Armor", "It's a key... to a door", 1)
        {
            DEF = 500;
        }
    }
    public class GoldArmor : ArmorItem
    {
        public GoldArmor()
            : base("Gold Armor", "It's a key... to a door", 1)
        {
            DEF = 500000;
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>
    
    public class TinBracers : BracersItem
    {
        public TinBracers()
            : base("TinBracers", "sword made of tin", 1)
        {
        }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// //////////////////////////////////////////////////////
    /// </summary>
    
    public class TinShield : ShieldItem
    {
        public TinShield()
            : base("TinShield", "sword made of tin", 1)
        {
        }
    }
}
