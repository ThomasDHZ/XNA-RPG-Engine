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
    public class StoryText
    {
        const int KERN = 12;
        const int LINESPACE = 30;
        const int XFORMATING = 640;
        const int YFORMATING = 190;
        const int MAXLINELENGTH = 100;
        List<String> StringList = new List<string>();
        Time InputTime = new Time(125);
        Time Lettertime = new Time(100);
        int LineCounter = 0;
        int Letter = 0;

        public StoryText()
        {
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Lettertime.Update(gameTime);
            InputTime.Update(gameTime);
            if (Lettertime.GetTimeFlag() == true)
            {
                if (Letter <= MAXLINELENGTH - 1)
                {
                    Letter++;
                }
            }
            if (InputTime.GetTimeFlag() == true)
            {
                
                try
                {
                    if (StringList[0] != null)
                    {
                        if (keyboardState.IsKeyDown(Keys.Space))
                        {
                            if (Letter != MAXLINELENGTH)
                            {
                                Letter = MAXLINELENGTH;
                            }
                            else
                            {
                                try
                                {
                                    if (StringList[0] != null)
                                    {
                                        try
                                        {
                                            int x = 0;
                                            while (x != 4)
                                            {
                                                StringList.Remove(StringList[0]);
                                                x++;
                                            }
                                        }
                                        catch (ArgumentOutOfRangeException)
                                        { }
                                        Letter = 0;
                                    }
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                }
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    RAM.TalkFlag = false;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (RAM.TalkFlag == true)
            {
                spriteBatch.Draw(RAM.LoadContent(@"TextBox"), new Vector2(RAM.camera.GetTextBoxPosition().X - XFORMATING, RAM.camera.GetTextBoxPosition().Y + YFORMATING), Color.White);

                try
                {
                    for (int x = 0; x <= Letter; x++)
                    {

                        if (x <= StringList[LineCounter].Length - 1)
                        {
                            spriteBatch.DrawString(RAM.GetFont(0), StringList[LineCounter][x].ToString(), new Vector2((RAM.camera.GetTextBoxPosition().X - 590) + (x * KERN), (RAM.camera.GetTextBoxPosition().Y + 215) + (LineCounter * LINESPACE)), Color.White);
                        }
                       if(LineCounter + 1 <= StringList.Count-1)
                       {
                        if (x <= StringList[LineCounter + 1].Length - 1)
                        {
                            spriteBatch.DrawString(RAM.GetFont(0), StringList[(LineCounter + 1)][x].ToString(), new Vector2((RAM.camera.GetTextBoxPosition().X - 590) + (x * KERN), (RAM.camera.GetTextBoxPosition().Y + 215) + ((LineCounter + 1) * LINESPACE)), Color.White);
                        }
                    }
                       if (LineCounter + 2 <= StringList.Count - 1)
                       {
                           if (x <= StringList[LineCounter + 2].Length - 1)
                           {
                               spriteBatch.DrawString(RAM.GetFont(0), StringList[(LineCounter + 2)][x].ToString(), new Vector2((RAM.camera.GetTextBoxPosition().X - 590) + (x * KERN), (RAM.camera.GetTextBoxPosition().Y + 215) + ((LineCounter + 2) * LINESPACE)), Color.White);
                           }
                       }
                       if (LineCounter + 3 <= StringList.Count - 1)
                       {
                           if (x <= StringList[LineCounter + 3].Length - 1)
                           {
                               spriteBatch.DrawString(RAM.GetFont(0), StringList[(LineCounter + 3)][x].ToString(), new Vector2((RAM.camera.GetTextBoxPosition().X - 590) + (x * KERN), (RAM.camera.GetTextBoxPosition().Y + 215) + ((LineCounter + 3) * LINESPACE)), Color.White);
                           }
                       }
                    }
                }
                catch (ArgumentOutOfRangeException)
                { }
            }
        }
        public void AddText(string text)
        {
            string ReadLine;
            const string BASEFILEPATH = "C:/Users/dothackzero/Desktop/New Folder (4)/Test/Test/Test/";
            using (StreamReader sr = new StreamReader(BASEFILEPATH + text))
            {
                while ((ReadLine = sr.ReadLine()) != null)
                {
                    StringList.Add(ReadLine);
                }
            }
        }
    }
}

