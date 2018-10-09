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
        const int TILESIZE = 50;
        const string BASEFILEPATH = "C:/Users/dothackzero/Desktop/New Folder (4)/Test/Test/Test/";
        const int ENCONTURE_RATE = 25;
        Vector2 PLAYERCOR = new Vector2(640, 360);
        Tile[] tile;
        ObjectTileIndex ObjectTile = new ObjectTileIndex();
        Tile[][] TileMap;
        Vector2 playercor = new Vector2(640, 360);
        Texture2D text;
        int[][] numbers;
        Vector2 TempPos = new Vector2(0, 0);
        bool Move = true;
        bool BattleStart = false;
        int XArea;
        int YArea;
        int quicktempx;
        int quicktempy;
        int TileCounter = 0;
        int ObjectTileCounter = 0;
        List<BaseEnitiy> Objects = new List<BaseEnitiy>();
        String map;
        public Map()
        {
            tile = new Tile[10];
            
            
        }
        public void AddTile(Texture2D Addtile, bool Collidable)
        {
            text = Addtile;
            tile[TileCounter] = new Tile(Addtile);
            tile[TileCounter].SetTileType(Collidable);
            TileCounter++;
        }
        public void AddObjectTile(Texture2D Addtile)
        {
            ObjectTile.AddTile(Addtile);
            ObjectTileCounter++;
        }
        public void LoadMap(string mapname)
        {
            map = mapname;
            XArea = 0;
            YArea = 0;
            int Y = 0;
            int X = 0;
            string line;
            string line2 = "";
            string tempstring = "";
            string num = "";
            bool FirstRun = false;

            using (StreamReader sr = new StreamReader(BASEFILEPATH + mapname))
            {
                while ((line = sr.ReadLine()) != null)
                {
                   YArea++;
                    line2 += line.Replace("\r\n", string.Empty);
                    if (FirstRun == false)
                    {
                        tempstring = line2;
                        tempstring = line.Replace(",", string.Empty);
                        XArea = line2.Length - tempstring.Length;
                        FirstRun = true;
                    }
                }
            }
            numbers = new int[XArea][];
            for (int x = 0; x < XArea; x++)
            {
                numbers[x] = new int[YArea];
            }
            for (int x = 0; x <= line2.Length - 1; x++)
            {
                if (line2[x] == ',')
                {
                    if (num.Length != 0)
                    {

                        if (X == XArea)
                        {
                            X = 0;
                            Y++;
                        }
                        numbers[X][Y] = int.Parse(num);
                        X++;
                    }
                    num = "";
                }
                else
                {
                    num += line2[x];
                }
            }
            TileMap = new Tile[XArea][];
            for (int x = 0; x < XArea; x++)
            {
                TileMap[x] = new Tile[YArea];

                for (int y = 0; y < YArea; y++)
                {
                        TileMap[x][y] = tile[numbers[x][y]];
                        TileMap[x][y].SetPositionX(40+(x * TILESIZE));
                        TileMap[x][y].SetPositionY(10+(y * TILESIZE));
                }
            }
        }
        public void LoadObjects(string objectmap)
        {
            string objectline;
            using (StreamReader sr = new StreamReader(BASEFILEPATH + objectmap))
            {
                while ((objectline = sr.ReadLine()) != null)
                {
                    char objectLine = objectline[0];
                    string num = "";
                    float X = 0;
                    float Y = 0;
                    bool firstcor = true;
                    string fileloc = "";
                    for (int x = 1; x <= objectline.Length - 1; x++)
                    {
                       
                        if (x == 0)
                        {
                            x++;
                        }
                        if (objectline[x] == ',')
                        {
                            if (num.Length != 0)
                            {
                                if (firstcor == true)
                                {
                                    X = int.Parse(num);
                                    firstcor = false;
                                }
                                else
                                {
                                    Y = int.Parse(num);
                                }
                            }
                            num = "";
                        }
                        else if (char.IsDigit(objectline[x]))
                        {
                            num += objectline[x];
                        }
                        else
                        {
                            fileloc += objectline[x];
                        }
                    }
                    Vector2 pos = new Vector2(40+(X * TILESIZE),10+ (Y * TILESIZE));
                    if (objectLine == 'C')
                    {
                        Objects.Add(new Chest(pos, ObjectTile.GetTile(0)));
                    }
                    else if (objectLine == 'S')
                    {
                        Objects.Add(new Stairs(pos, fileloc, ObjectTile.GetTile(1)));
                    }
                }
            }
        }
        public void UpatePosition(GameTime gametime, Vector2 pos)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            int tempX = (int)playercor.X / 50;
            int tempY = (int)playercor.Y / 50;
            quicktempx = (int)playercor.X / 50;
            quicktempy = (int)playercor.Y / 50;
            Random rand = new Random();
            if (keyboardState.IsKeyDown(Keys.Up))
            {

                if (rand.Next(ENCONTURE_RATE) == 1)
                {
                    BattleStart = true;
                }
                playercor.Y -= TILESIZE;
                if (quicktempy - 1 == -1)
                {
                    Move = false;
                    playercor.Y += TILESIZE;
                }
                else
                {
                    if (TileMap[quicktempx][quicktempy - 1].GetTileType() == true)
                    {
                        Move = false;
                        playercor.Y += TILESIZE;
                    }
                    else
                    {
                        Move = true;
                        foreach (BaseEnitiy objectz in Objects)
                        {
                            if (objectz.GetPosition() == TileMap[quicktempx][quicktempy-1].GetPosition())
                            {
                                if (objectz.GetCollision() == true)
                                {
                                    Move = false;
                                    playercor.Y += TILESIZE;
                                    foreach (BaseEnitiy objectzz in Objects)
                                    {
                                        if (objectzz != objectz)
                                        {
                                            objectzz.SetPosition(objectzz.GetPosition().X, objectzz.GetPosition().Y - TILESIZE);
                                        }
                                    }
                                }
                                else if (objectz.GetCollision() == false && objectz is Stairs)
                                {
                                    int count = Objects.Count;
                                    for (int x = 0; x <= count - 1; x++)
                                    {
                                        Objects.Remove(Objects[0]);
                                    }
                                    LoadMap(((Stairs)objectz).GetMap());
                                    playercor = PLAYERCOR;
                                    playercor.Y -= TILESIZE;
                                    break;
                                }
                                else
                                {
                                    objectz.SetPosition(objectz.GetPosition().X, objectz.GetPosition().Y + TILESIZE);
                                }
                            }
                            else
                            {
                                objectz.SetPosition(objectz.GetPosition().X, objectz.GetPosition().Y + TILESIZE);
                            }
                        }
                    }
                }
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                playercor.Y += TILESIZE;

                if (rand.Next(ENCONTURE_RATE) == 1)
                {
                    BattleStart = true;
                }
                    if (quicktempy + 1 == YArea)
                    {
                        Move = false;
                        playercor.Y -= TILESIZE;
                    }
                    else
                    {
                        if (TileMap[quicktempx][quicktempy+1].GetTileType() == true)
                        {
                            Move = false;
                            playercor.Y -= TILESIZE;
                        }
                        else
                        {
                            Move = true;
                            foreach (BaseEnitiy objectz in Objects)
                            {
                                if (objectz.GetPosition() == TileMap[quicktempx][quicktempy + 1].GetPosition())
                                {
                                    if (objectz.GetCollision() == true)
                                    {
                                        Move = false;
                                        playercor.Y -= TILESIZE;
                                        foreach (BaseEnitiy objectzz in Objects)
                                        {
                                            if (objectzz != objectz)
                                            {
                                                objectzz.SetPosition(objectzz.GetPosition().X, objectzz.GetPosition().Y + TILESIZE);
                                            }
                                        }
                                    }
                                    else if (objectz.GetCollision() == false && objectz is Stairs)
                                    {
                                        int count = Objects.Count;
                                        for (int x = 0; x <= count - 1; x++)
                                        {
                                            Objects.Remove(Objects[0]);
                                        }
                                        LoadMap(((Stairs)objectz).GetMap());
                                        playercor = PLAYERCOR;
                                        playercor.Y += TILESIZE;
                                        break;
                                    }
                                    else
                                    {
                                        objectz.SetPosition(objectz.GetPosition().X, objectz.GetPosition().Y - TILESIZE);
                                    }
                                }
                                else
                                {
                                    objectz.SetPosition(objectz.GetPosition().X, objectz.GetPosition().Y - TILESIZE);
                                }
                            }
                        }
                    }

            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                if (rand.Next(ENCONTURE_RATE) == 1)
                {
                    BattleStart = true;

                }
                playercor.X -= TILESIZE;
                if (quicktempx - 1 == -1)
                {
                    Move = false;
                    playercor.X += TILESIZE;
                }
                else
                {
                    if (TileMap[quicktempx - 1][quicktempy].GetTileType() == true)
                    {
                        Move = false;
                        playercor.X += TILESIZE;
                    }
                    else
                    {
                        Move = true;
                        foreach (BaseEnitiy objectz in Objects)
                        {

                                if (objectz.GetPosition() == TileMap[quicktempx - 1][quicktempy].GetPosition())
                                {
                                    if (objectz.GetCollision() == true)
                                    {
                                        Move = false;
                                        playercor.X += TILESIZE;
                                        foreach (BaseEnitiy objectzz in Objects)
                                        {
                                            if (objectzz != objectz)
                                            {
                                                objectzz.SetPosition(objectzz.GetPosition().X - TILESIZE, objectzz.GetPosition().Y);
                                            }
                                        }
                                    }
                                    else if (objectz.GetCollision() == false && objectz is Stairs)
                                    {
                                        int count = Objects.Count;
                                        for (int x = 0; x <= count - 1; x++)
                                        {
                                            Objects.Remove(Objects[0]);
                                        }
                                        LoadMap(((Stairs)objectz).GetMap());
                                        playercor = PLAYERCOR;
                                        playercor.X -= TILESIZE;
                                        break;
                                    }
                                    else
                                    {
                                        objectz.SetPosition(objectz.GetPosition().X + TILESIZE, objectz.GetPosition().Y);
                                    }
                                }
                            else
                            {
                                objectz.SetPosition(objectz.GetPosition().X + TILESIZE, objectz.GetPosition().Y);
                            }
                        }
                    }
                }

            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                playercor.X += TILESIZE;
                if (rand.Next(ENCONTURE_RATE) == 1)
                {
                    BattleStart = true;
                }
                if (quicktempx + 1 == XArea)
                {
                    Move = false;
                    playercor.X -= TILESIZE;
                }
                else
                {
                    if (TileMap[quicktempx + 1][quicktempy].GetTileType() == true)
                    {
                        Move = false;
                        playercor.X -= TILESIZE;
                    }
                    else
                    {
                        Move = true;
                        foreach (BaseEnitiy objectz in Objects)
                        {

                            if (objectz.GetPosition() == TileMap[quicktempx + 1][quicktempy].GetPosition())
                            {
                                if (objectz.GetCollision() == true)
                                {
                                    Move = false;
                                    playercor.X -= TILESIZE;
                                    foreach (BaseEnitiy objectzz in Objects)
                                    {
                                        if (objectzz != objectz)
                                        {
                                            objectzz.SetPosition(objectzz.GetPosition().X + TILESIZE, objectzz.GetPosition().Y);
                                        }
                                    }
                                }
                                else if (objectz.GetCollision() == false && objectz is Stairs)
                                {
                                    int count = Objects.Count;
                                    for (int x = 0; x <= count - 1; x++)
                                    {
                                        Objects.Remove(Objects[0]);
                                    }
                                    
                                    LoadMap(((Stairs)objectz).GetMap());
                                    LoadObjects("TextFileObjectt.txt");
                                   //playercor = PLAYERCOR;
                                   playercor.X = 4 * 50;
                                   playercor.Y = 8 * 50;
                                   playercor.X += TILESIZE;
     
                                    break;
                                }
                                else
                                {
                                    objectz.SetPosition(objectz.GetPosition().X - TILESIZE, objectz.GetPosition().Y);
                                }
                            }
                            else
                            {
                                objectz.SetPosition(objectz.GetPosition().X - TILESIZE, objectz.GetPosition().Y);
                            }
                        }
                    }
                }
            }
            if (Move == true)
            {
                for (int x = 0; x < XArea; x++)
                {
                    for (int y = 0; y < YArea; y++)
                    {

                        if (keyboardState.IsKeyDown(Keys.Up))
                        {
                            TileMap[x][y].SetPositionY(TileMap[x][y].GetPosition().Y + TILESIZE);
                        }
                        else if (keyboardState.IsKeyDown(Keys.Down))
                        {
                            TileMap[x][y].SetPositionY(TileMap[x][y].GetPosition().Y - TILESIZE);
                        }
                        else if (keyboardState.IsKeyDown(Keys.Left))
                        {
                            TileMap[x][y].SetPositionX(TileMap[x][y].GetPosition().X + TILESIZE);
                        }
                        else if (keyboardState.IsKeyDown(Keys.Right))
                        {
                            TileMap[x][y].SetPositionX(TileMap[x][y].GetPosition().X - TILESIZE);
                        }
                    }
                }
            }    
        }
        public BaseEnitiy GetObject(int x)
        {
            return (Objects[x]);
        }
        public int GetObjectIndex()
        {
            return (Objects.Count);
        }
        public int GetXArea()
        {
            return (XArea);
        }
        public int GetYArea()
        {
            return (YArea);
        }
        public Vector2 GetPos(int x, int y)
        {
            return TileMap[x][y].GetPosition();
        }
        public Texture2D GetTile(int x, int y)
        {
            return (TileMap[x][y].GetTexture());
        }
        public void SetBattleMsg(bool msg)
        {
            BattleStart = msg;
        }
        public bool GetBattleMsg()
        {
            return BattleStart;
        }
    }
}
