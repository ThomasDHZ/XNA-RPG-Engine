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
    class Pointer
    {
        Texture2D pointer;
        Vector2 PointerPos;
        public Pointer(Texture2D texture, Vector2 Pos)
        {
            pointer = texture;
            PointerPos = Pos;
        }
        public Vector2 GetPosition()
        {
            return PointerPos;
        }
        public void SetPosition(Vector2 pos)
        {
            PointerPos = pos;
        }
        public Texture2D GetTexture()
        {
            return pointer;
        }
    }
    class Vertical_Pointer : Microsoft.Xna.Framework.Game
    {
        Texture2D pointer = RAM.LoadContent(@"arrow");
         Vector2 BasePointerPos;
         Vector2 PointerPos;
         Time time = new Time(150);
         int Multiplier;
        int MaxChoices = 0;
        int Choices = 0;
        public Vertical_Pointer(Vector2 BasePointerpos, int MaxChoice, int multiplier)
        {
            BasePointerPos = BasePointerpos;
            MaxChoices = MaxChoice;
            Multiplier = multiplier;
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            time.Update(gametime);
            if (time.GetTimeFlag() == true)
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (Choices <= 0)
                    {
                        Choices = MaxChoices;
                    }
                    else
                    {
                        Choices--;
                    }

                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (Choices >= MaxChoices)
                    {
                        Choices = 0;
                    }
                    else
                    {
                        Choices++;
                    }
                }
                PointerPos.Y = BasePointerPos.Y + (Choices * Multiplier);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pointer, PointerPos, Color.White);
        }
        public void SetMaxChoices(int MaxChoice)
        {
            MaxChoices = MaxChoice;
        }
        public void SetPosition(Vector2 pos)
        {
            BasePointerPos = pos;
            PointerPos = pos;
        }
        public void SetPositionX(float pos)
        {
            BasePointerPos.X = pos;
            PointerPos.X = pos;
        }
        public void SetPositionY(float pos)
        {
            BasePointerPos.Y = pos;
            PointerPos.Y = pos;
        }
        public Vector2 GetPosition()
        {
            return PointerPos;
        }
        public Texture2D GetTexture()
        {
            return pointer;
        }
        public int GetChoice()
        {
            return Choices;
        }
    }
    class Horizontal_Pointer : Microsoft.Xna.Framework.Game
    {
        Texture2D pointer = RAM.LoadContent(@"arrow");
        Vector2 BasePointerPos;
        Vector2 PointerPos;
        Time time = new Time(150);
        int Multiplier;
        int MaxChoices = 0;
        int Choices = 0;
        public Horizontal_Pointer(Vector2 BasePointerpos, int MaxChoice, int multiplier)
        {
            BasePointerPos = BasePointerpos;
            MaxChoices = MaxChoice;
            Multiplier = multiplier;
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            time.Update(gametime);
            if (time.GetTimeFlag() == true)
            {
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (Choices <= 0)
                    {
                        Choices = MaxChoices;
                    }
                    else
                    {
                        Choices--;
                    }

                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (Choices >= MaxChoices)
                    {
                        Choices = 0;
                    }
                    else
                    {
                        Choices++;
                    }
                }
                PointerPos.X = BasePointerPos.X + (Choices * Multiplier);
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(pointer, PointerPos, Color.White);
        }
        public void SetMaxChoices(int MaxChoice)
        {
            MaxChoices = MaxChoice;
        }
        public void SetPosition(Vector2 pos)
        {
            BasePointerPos = pos;
            PointerPos = pos;
        }
        public void SetPositionX(float pos)
        {
            BasePointerPos.X = pos;
            PointerPos.X = pos;
        }
        public void SetPositionY(float pos)
        {
            BasePointerPos.Y = pos;
            PointerPos.Y = pos;
        }
        public Vector2 GetPosition()
        {
            return PointerPos;
        }
        public Texture2D GetTexture()
        {
            return pointer;
        }
    }
}
