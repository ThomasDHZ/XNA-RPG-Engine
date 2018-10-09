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
    public class TileIndex
    {
        Texture2D[] Tiles;
        int counter = 0;
        public TileIndex()
        {
            Tiles = new Texture2D[10];
        }
        public void AddTile(Texture2D tile)
        {
            Tiles[counter] = tile;
            counter++;
        }
        public Texture2D GetTile(int tile)
        {
            return (Tiles[tile]);
        }
        public int GetTileCount()
        {
            return (counter);
        }
    }
    public class ObjectTileIndex
    {
        Texture2D[] Tiles;
        int counter = 0;
        public ObjectTileIndex()
        {
            Tiles = new Texture2D[10];
        }
        public void AddTile(Texture2D tile)
        {
            Tiles[counter] = tile;
            counter++;
        }
        public Texture2D GetTile(int tile)
        {
            return (Tiles[tile]);
        }
        public int GetTileCount()
        {
            return (counter);
        }
    }

    public struct Tile
    {
        const int TILESIZE = 50;
        Vector2 position;
        Texture2D texture;
        bool collidable;

        public Tile(Texture2D Texture)
        {
            texture = Texture;
            collidable = false;
            position = new Vector2(0, 0);
        }
        public void SetTexture(Texture2D textures)
        {
            texture = textures;
        }
        public Texture2D GetTexture()
        {
            return (texture);
        }
        public void SetTileType(bool Collidable)
        {
            collidable = Collidable;
        }
        public bool GetTileType()
        {
            return (collidable);
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
        public void SetPositionX(float X)
        {
            position.X = X;
        }
        public void SetPositionY(float Y)
        {
            position.Y = Y;
        }
    }

}