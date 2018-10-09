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
    
    class Map : Microsoft.Xna.Framework.Game
    {
        AvatarSprite MainChar;
        bool TalkFlag = false;

        public Map()
        {
            RAM.MapArea = new MapArea("Load Files/Master Load File/AreaX.txt");
        }
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            RAM.VRAM.Update();
            for (int x = 0; x <= RAM.VRAM.LayerCount; x++)
            {
                try
                {
                    foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[x])
                    {
                        if (obj is AvatarSprite)
                        {
                            MainChar = (AvatarSprite)obj;
                            ((AvatarSprite)obj).Update(gameTime);
                        }
                        else if (obj is NPC)
                        {
                            ((NPC)obj).Update(gameTime);
                        }
                        else if (obj is Chest)
                        {
                            ((Chest)obj).Update(gameTime);
                        }
                        else if (obj is Door)
                        {
                            ((Door)obj).Update(gameTime);
                        }
                        else if (obj is LayerChange)
                        {
                            ((LayerChange)obj).Update(gameTime);
                        }
                        else if (obj is Encounter_Area)
                        {
                            ((Encounter_Area)obj).Update(gameTime);
                        }
                        else if (obj is Boat)
                        {
                            ((Boat)obj).Update(gameTime);
                        }
                        obj.SetSprite(RAM.LoadContent(obj.CurrentAnimation.GetSpriteName(obj.CurrentAnimation.GetFrame())));
                    }
                }
                catch (InvalidOperationException)
                {
                    Update(gameTime);
                }
            }
            if (RAM.TalkFlag == true)
            {
               // RAM.Storytext.Update(gameTime);
            }

             if (TalkFlag == false)
             {
                 foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                 {
                     if (obj != MainChar)
                     {

                         if (obj.GetCollision() == true)
                         {
                             if (obj.GetRec().GetCollisionRectangle().Intersects(MainChar.GetRec().GetCollisionRectangle()))
                             {
                                 if (keyboardState.IsKeyDown(Keys.Up)
                                    && keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X + (RAM.TILESIZE / 8), MainChar.GetPosition().Y + (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Up)
                                     && keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X - (RAM.TILESIZE / 8), MainChar.GetPosition().Y + (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down)
                                     && keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X + (RAM.TILESIZE / 8), MainChar.GetPosition().Y - (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down)
                                     && keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X - (RAM.TILESIZE / 8), MainChar.GetPosition().Y - (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Up))
                                 {
                                     MainChar.SetPositionY(MainChar.GetPosition().Y + RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down))
                                 {
                                     MainChar.SetPositionY(MainChar.GetPosition().Y - RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPositionX(MainChar.GetPosition().X + RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X + (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPositionX(MainChar.GetPosition().X - RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X - (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                                 }
                             }
                             if (obj.GetCir().Intersects(MainChar.GetPosition(),obj.GetPosition()) == false)
                             {
                                 if (keyboardState.IsKeyDown(Keys.Up)
                                    && keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X + (RAM.TILESIZE / 8), MainChar.GetPosition().Y + (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Up)
                                     && keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X - (RAM.TILESIZE / 8), MainChar.GetPosition().Y + (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down)
                                     && keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X + (RAM.TILESIZE / 8), MainChar.GetPosition().Y - (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down)
                                     && keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPosition(new Vector2(MainChar.GetPosition().X - (RAM.TILESIZE / 8), MainChar.GetPosition().Y - (RAM.TILESIZE / 8)));
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Up))
                                 {
                                     MainChar.SetPositionY(MainChar.GetPosition().Y + RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Down))
                                 {
                                     MainChar.SetPositionY(MainChar.GetPosition().Y - RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Left))
                                 {
                                     MainChar.SetPositionX(MainChar.GetPosition().X + RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X + (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                                 }
                                 else if (keyboardState.IsKeyDown(Keys.Right))
                                 {
                                     MainChar.SetPositionX(MainChar.GetPosition().X - RAM.TILESIZE / 8);
                                     RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X - (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                                 }
                             }
                         }
                     }
                 }
             }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            RAM.MapArea.Draw(spriteBatch);
            for (int x = 0; x <= RAM.VRAM.ObjectList.Count - 1; x++)
            {
                foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[x])
                {
                    if (obj.GetLayerLevel() == RAM.VRAM.LayerLevel)
                    {
                        if (obj is NPC)
                        {
                            ((NPC)obj).Draw(spriteBatch);
                        }
                        if (obj is Chest)
                        {
                            ((Chest)obj).Draw(spriteBatch);
                        }
                    }
                }
            }
        }
    }
}
