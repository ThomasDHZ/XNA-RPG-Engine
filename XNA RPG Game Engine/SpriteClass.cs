using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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

    public class Animation : Microsoft.Xna.Framework.Game
    {                          
        const String BasePath = @"C:/Users/dothackzero/Desktop/New Folder (4)/Test/Test/TestContent/";
        int MaxFrame;
        int Frame = 0;
        string[] SpriteName;
        bool flag = true;
        int frames = 1;
        String Name;
        public Animation(string name)
        {
            
            Name = name;
            int number = 1;
            int stringlength = Name.Length;
            string NumberString = number.ToString();
            while (flag == true)
            {
                CheckNumbers(number);
                number++;
                NumberString = number.ToString();
                Name = Name.Insert(Name.Length, NumberString);
                if (File.Exists(BasePath + Name + ".png") ||
                    File.Exists(BasePath + Name + ".tga") ||
                    File.Exists(BasePath + Name + ".bmp") ||
                    File.Exists(BasePath + Name + ".jpeg"))
                {
                    frames++;
                }
                else
                {
                    flag = false;
                }
            }
            SpriteName = new string[frames];
            MaxFrame = frames - 1;
            CheckNumbers(number);
            number = 0;
            for (int x = 0; x <= frames-1; x++)
            {
                String afsd = Name;
                CheckNumbers(number);
                number++;
                NumberString = number.ToString();
                Name = Name.Insert(Name.Length, NumberString);
                SetSpriteName(x, Name);
               // Sprite = Content.Load<Texture2D>(GetSpriteName(x));
            }
           // Sprite = Content.Load<Texture2D>(@"arrow_down");
            int sd = 34;
        }
        private void CheckNumbers(int Numbers)
        {
            if (Numbers >= 10 && Numbers < 99)
            {
                Name = Name.Remove(Name.Length - 2);
            }
            else if (Numbers <= 9 && Numbers > 0)
            {
                Name = Name.Remove(Name.Length - 1);
            }
        }
        public void SetSpriteName(int frame, string spriteName)
        {
            SpriteName[frame] = spriteName;
        }
        public string GetSpriteName(int frame)
        {
            return (SpriteName[frame]);
        }
        public void SetFrame(int frame)
        {
            Frame = frame;
        }
        public int GetMaxFrame()
        {
            return (MaxFrame);
        }
        public int GetFrame()
        {
            return (Frame);
        }
 
    }
}