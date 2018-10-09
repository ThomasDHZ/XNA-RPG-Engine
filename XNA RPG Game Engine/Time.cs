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

namespace Test
{
    public class Time
    {
        float time = 0;
        float timeamount = 0;
        bool TimeFlag = false;
        public Time(float Timeamount)
        {
            timeamount = Timeamount;
        }
        public void Update(GameTime Gametime)
        {
            time += (float)Gametime.ElapsedGameTime.TotalMilliseconds;
            TimeFlag = false;
            if (time >= timeamount)
            {
                time = 0;
                TimeFlag = true;
            }
        }
        public float GetTime()
        {
            return time;
        }
        public bool GetTimeFlag()
        {
            return (TimeFlag);
        }
    }
}
