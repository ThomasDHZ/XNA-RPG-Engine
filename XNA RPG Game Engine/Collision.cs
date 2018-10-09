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
  /*public class Collision
    {
        int Collisiontype;
        CollisionCircle Circle = null;
        CollisionRectangle rectangle = null;
        public Collision(int radius, Vector2 offset)
        {
            Circle = new CollisionCircle(radius, offset);
            Collisiontype = (int)ColliderType.kCircle;
        }
        public Collision(int x, int y, int Width, int Height)
        {
            rectangle = new CollisionRectangle(x, y, Width, Height);
            Collisiontype = (int)ColliderType.kRectangle;
        }
        public void Update(GameTime gametime)
        {
            if (Collisiontype == (int)ColliderType.kCircle)
            {
                
            }
            if (Collisiontype == (int)ColliderType.kRectangle)
            {
            }
        }
        public void Draw(SpriteBatch spritebatch)
        {
        }
    }*/
    public class CollisionCircle
    {
        int Radius;
        Vector2 Offset;
        int InteractionArea = 0;
        public CollisionCircle()
        {
        }
        public CollisionCircle(int radius, Vector2 offset)
        {
            Radius = radius;
            Offset = offset;
        }
        public bool Intersects(Vector2 vec1, Vector2 vec2)
        {
            if (Math.Sqrt((vec1.X - vec2.X) * (vec1.X - vec2.X) + (vec1.Y - vec2.Y) * (vec1.Y - vec2.Y)) < (Radius + Radius))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int GetRadius()
        {
            return Radius;
        }
        public Vector2 GetOffset()
        {
            return Offset;
        }
        public void SetInteractionArea(int area)
        {
            InteractionArea = area;
        }
        public int GetInteractionArea()
        {
            return InteractionArea;
        }
    }
    public class CollisionRectangle
    {
        Rectangle CollideRectangle;
        Rectangle InteractiveRectangle;
        public CollisionRectangle()
        {
            CollideRectangle = new Rectangle(0, 0, 0, 0);
        }
        public Rectangle GetCollisionRectangle()
        {
            return CollideRectangle;
        }
        public Rectangle GetInteractiveRectangle()
        {
            return InteractiveRectangle;
        }
        public void SetRectangle(int x, int y, int Width, int Height)
        {
            CollideRectangle = new Rectangle(x, y, Width, Height);
        }
        public void SetInteractiveRectangle(int x, int y, int Width, int Height)
        {
            InteractiveRectangle = new Rectangle(x, y, Width, Height);
        }
    }
}
