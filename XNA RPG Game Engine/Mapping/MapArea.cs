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
    public class MapArea
    {
        const string BASEFILEPATH = "C:/Users/dothackzero/Desktop/New Folder (4)/Test/Test/Test/";
        Vector2 Position;
        List<BaseEnitiy> Objects = new List<BaseEnitiy>();
        List<BasicSpriteInfo> Wall = new List<BasicSpriteInfo>();
        public List<List<Tile>> TileMapBottomLayer = new List<List<Tile>>();
        public List<List<Tile>> TileMapTopLayer = new List<List<Tile>>();
        public List<List<List<Tile>>> Test = new List<List<List<Tile>>>();
        public int MAPLAYER = 0;
        public bool SeeTopLayer = true;
        List<TileInfo> TileList = new List<TileInfo>();
        
        int X = 0;
        public MapArea(string MapFile)
        {
            Position = new Vector2(0,0);
            string ReadLine;
            int counter = 0;
            int Layer = 0;
            using (StreamReader sr = new StreamReader(BASEFILEPATH + MapFile))
            {
                while ((ReadLine = sr.ReadLine()) != null)
                {
                    if (ReadLine == "T")
                    {
                        ReadLine = sr.ReadLine();
                        LoadTileList(ReadLine);
                    }
                    if (ReadLine == "M")
                    {
                        while ((ReadLine = sr.ReadLine()) != "O")
                        {
                            LoadMap(ReadLine, Layer);
                        }
                    }
                    if (ReadLine == "O")
                    {
                        while ((ReadLine = sr.ReadLine()) != null)
                        {
                            LoadObjects(ReadLine);
                        }
                    }
                    counter++;
                }
            }
        }
        public void LoadTileList(string tilelist)
        {
            Texture2D tempTex = null;
            int tempColl = -1;
            string ReadLine;
            using (StreamReader sr = new StreamReader(BASEFILEPATH + tilelist))
            {
                while ((ReadLine = sr.ReadLine()) != null)
                {
                    try
                    {
                        tempColl = int.Parse(ReadLine);
                    }
                    catch(FormatException)
                    {
                        if (ReadLine != "")
                        {
                            tempTex = RAM.LoadContent(ReadLine);
                        }
                    }
                    if (tempColl != -1 && tempTex != null)
                    {
                        
                        TileList.Add(new TileInfo(tempTex, tempColl));
                        tempColl = -1;
                        tempTex = null;
                    }
                }
            }
        }
        public void LoadMap(string mapfile, int Layer)
        {

            int TempX = 0;
            int Y = 0;
            string ReadLine;
            string line = "";

            using (StreamReader sr = new StreamReader(BASEFILEPATH + mapfile))
            {
                List<List<Tile>> tempTile2 = new List<List<Tile>>();
                while ((ReadLine = sr.ReadLine()) != null)
                {
                    List<Tile> tempTile = new List<Tile>();
                    for (int x = 0; x <= ReadLine.Length - 1; x++)
                    {
                        if (ReadLine[x] != ',')
                        {
                            line += ReadLine[x];
                        }
                        else
                        {

                            int asd = int.Parse(line);

                            tempTile.Add(new Tile(TileList[asd].GetTexture(), new Vector2(TempX * RAM.TILESIZE, Y * RAM.TILESIZE), TileList[asd].GetTileType()));

                            TempX++;
                            line = "";
                        }
                    }
                    if (Y == 0)
                    {
                        X = TempX;
                    }
                    TempX = 0;
                    Y++;
                    tempTile2.Add(tempTile);

                }

                Test.Add(tempTile2);
            }
        }
        public void LoadObjects(string objectmap)
        {
            string ReadLine;
            string ObjectName;
  
            Vector2 pos = Vector2.Zero;
            RAM.VRAM.LayerCount++;
            List<BaseEnitiy> TempObjectList = new List<BaseEnitiy>();

            using (StreamReader sr = new StreamReader(BASEFILEPATH + objectmap))
            {
                while ((ReadLine = sr.ReadLine()) != null)
                {
                        ObjectName = ReadLine;
                        if (ObjectName == "AvatarSprite")
                        {
                            TempObjectList.Add(new AvatarSprite(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()))));
                        }
                        else if (ObjectName == "NPC")
                        {
                            TempObjectList.Add(new NPC(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()))));
                        }
                        else if (ObjectName == "Chest")
                        {
                            TempObjectList.Add(new Chest(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine())), new Potion()));
                        }
                        else if (ObjectName == "Door")
                        {
                            TempObjectList.Add(new Door(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()))));
                        }
                        else if (ObjectName == "LayerChange")
                        {
                            TempObjectList.Add(new LayerChange(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine())), new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine())), sr.ReadLine()));
                        }
                        else if (ObjectName == "EncounterArea")
                        {
                            TempObjectList.Add(new Encounter_Area(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine())), new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()))));
                        }
                        else if (ObjectName == "Boat")
                        {
                            TempObjectList.Add(new Boat(new Vector2(float.Parse(sr.ReadLine()), float.Parse(sr.ReadLine()))));
                        }
                }
            }
            RAM.VRAM.AddObject(TempObjectList);
        }
        public Vector2 GetFloorPosition()
        {
            return Position;
        }
        public void SetFloorPosition(Vector2 pos)
        {
            Position = pos;
        }
        public BaseEnitiy GetObject(int Objectz)
        {
            return Objects[Objectz];
        }

        public bool MoveOnFoot(int x, int y)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            int X = (int)x;
            int Y = (int)y;
            foreach (List<Tile> tile in Test[MAPLAYER])
            {
                foreach (Tile tile2 in tile)
                {
                    if (tile2.GetPositionX() + RAM.TILESIZE >= x
                        && tile2.GetPositionX() <= x)
                    {
                        if (tile2.GetPositionY() <= y)
                            {
                                if (tile2.GetPositionY() + RAM.TILESIZE >= y)
                                {
                                    X = (int)tile2.GetPositionX() / RAM.TILESIZE;
                                    Y = (int)tile2.GetPositionY() / RAM.TILESIZE;
                                }
                            }
                        
                    }
                }
            }
            try
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            return false;
        }
        public bool MoveOnShip(int x, int y)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            int X = (int)x;
            int Y = (int)y;
            foreach (List<Tile> tile in Test[MAPLAYER])
            {
                foreach (Tile tile2 in tile)
                {
                    if (tile2.GetPositionX() + RAM.TILESIZE >= x
                        && tile2.GetPositionX() <= x)
                    {
                        if (tile2.GetPositionY() <= y)
                        {
                            if (tile2.GetPositionY() + RAM.TILESIZE >= y)
                            {
                                X = (int)tile2.GetPositionX() / RAM.TILESIZE;
                                Y = (int)tile2.GetPositionY() / RAM.TILESIZE;
                            }
                        }

                    }
                }
            }
            try
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    if (Test[MAPLAYER][Y][X].GetTileType() == 3)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
            return false;
        }
        public void AddObjects(BaseEnitiy enitiy)
        {
            Objects.Add(enitiy);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int d = 0;
            for (int x = 0; x <= MAPLAYER;)
            {
                foreach (List<Tile> tiley in Test[x])
                {
                    foreach (Tile tilex in tiley)
                    {
                        spriteBatch.Draw(tilex.GetTexture(), tilex.GetPosition(), Color.White);
                    }
                }
                if (d <= RAM.VRAM.LayerLevel)
                {
                    foreach (BaseEnitiy Entity in RAM.VRAM.ObjectList[d])
                    {
                        if (Entity.GetVisibility() == true)
                        {
                            Entity.Draw(spriteBatch);
                        }
                    }
                }
                if (SeeTopLayer == true)
                {
                    foreach (List<Tile> tiley in Test[MAPLAYER + 1])
                    {
                        foreach (Tile tilex in tiley)
                        {
                            spriteBatch.Draw(tilex.GetTexture(), tilex.GetPosition(), Color.White);
                        }
                    }
                }

                x += 2;
                d++;
            }
            
        }
    }
}
