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

    public class TileInfo
    {
        Texture2D texture;
        int TileType;
         public TileInfo(Texture2D Texture, int Tiletype)
         {
             texture = Texture;
             TileType = Tiletype;
         }
        public Texture2D GetTexture()
        {
            return texture;
        }
        public int GetTileType()
        {
            return TileType;
        }
    }
    public struct Tile
    {
        Vector2 position;
        Texture2D texture;
        int TileType;

        public Tile(Texture2D Texture, Vector2 Position, int Tiletype)
        {
            texture = Texture;
            position = Position;
            TileType = Tiletype;
        }
        public void SetTexture(Texture2D textures)
        {
            texture = textures;
        }
        public Texture2D GetTexture()
        {
            return (texture);
        }
        public Vector2 GetPosition()
        {
            return (position);
        }
        public float GetPositionX()
        {
            return (position.X);
        }
        public float GetPositionY()
        {
            return (position.Y);
        }
        public int GetTileType()
        {
            return TileType;
        }
        public void SetPositionX(float X)
        {
            position.X = X;
        }
        public void SetPositionY(float Y)
        {
            position.Y = Y;
        }
        public void SetPosition(Vector2 vector)
        {
            position = vector;
        }
    }
    public class VisualRAM
    {
        public List<List<BaseEnitiy>> ObjectList = new List<List<BaseEnitiy>>();
        public int ObjectID;
        public int LayerCount = -1;
        public int LayerLevel = 0;
        public VisualRAM()
        {
        }
        public void AddObject(List<BaseEnitiy> TempObjectList)
        {
            ObjectList.Add(TempObjectList);
        }
        public BaseEnitiy GetObject(int Layer, int Object)
        {
            return (ObjectList[Layer][Object]);
        }
        public int GetObjectCount()
        {
            return ObjectList.Count - 1;
        }
        public void Update()
        {
           
            BaseEnitiy[][] objectList = new BaseEnitiy[ObjectList.Count][];
            for (int y = 0; y <= ObjectList.Count - 1; y++)
            {
                objectList[y] = new BaseEnitiy[ObjectList[y].Count];
                for (int x = 0; x <= ObjectList[y].Count - 1; x++)
                {
                    ObjectList[y][x].SetLayerLevel(y);
                    objectList[y][x] = ObjectList[y][x];
                    
                }
            }
            for (int y = 0; y <= ObjectList.Count - 1; y++)
            {
                for (int x = 0; x <= ObjectList[y].Count() - 1; x++)
                {
                    BaseEnitiy temp;
                    if (x != ObjectList[y].Count() - 1)
                    {
                        if (objectList[y][x].GetPosition().Y + objectList[y][x].GetSprite().Height + objectList[y][x].GetOffset().Y
                               > objectList[y][x + 1].GetPosition().Y + objectList[y][x + 1].GetSprite().Height + objectList[y][x + 1].GetOffset().Y)
                        {
                            temp = objectList[y][x];
                            objectList[y][x] = objectList[y][x + 1];
                            objectList[y][x + 1] = temp;
                            x = -1;
                        }
                    }
                }
            }
            ClearVRAM();
            for (int y = 0; y <= objectList.Length - 1; y++)
            {
                List<BaseEnitiy> sdf = new List<BaseEnitiy>(objectList[y]);
                ObjectList.Add(sdf);
            }
        }
        public void ClearVRAM()
        {
            while (ObjectList.Count != 0)
            {
                ObjectList.Remove(ObjectList[ObjectID]);
            }
        }
    }
}