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
    public enum RecTypes
    {
        kNormal,
        kPartial,
        kSwitch
    }
    public enum RectangleSideFlags
    {
        kTop,
        kBottom,
        kRight,
        kLeft
    }
    public enum ImportantSprite
    {
        kDefultSprite,
        kPointerSprite,
        kCollisionPixel,
        kInterActionPixel,
        kBridgePixel
    }
    public enum Pixels
    {
        kCollisionPixel,
        kInterActionPixel,
        kBridgePixel
    }
    public enum ColliderType
    {
        kRectangle,
        kCircle
    }
    public enum Players
    {
        Val,
        Fuka,
        Art
    }
    public enum AI_Personality
    {
    }
    public enum Collision
    {
        kNoCollision,
        kCollidable_On_Foot,
        kCollidable_On_Boat,
        kCollidable_On_AirShip,


    }
    public enum Item_Sub_Class
    {
        kUseableItems,
        kEquipmentItems,
        kBattleItems,
        kSythItems,
        kKeyItems
    };
    public enum Looking
    {
        kUp,
        kUpRight,
        kRight,
        kDownRight,
        kDown,
        kDownLeft,
        kLeft,
        kUpLeft
    };
    public enum Flags
    {
        kMainGameFlag,
        kBattleFlag,
        kMenuFlag,
        kTalkFlag,
    };
}
