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
    public class BasicSpriteInfo : Microsoft.Xna.Framework.Game
    {

         Texture2D Sprite;
         Vector2 Position;
         Vector2 Offset;
         int LayerLevel;
         public Time time = new Time(30);
         bool Collision = true;
         bool Visible = true;
         public BasicSpriteInfo(Vector2 offset, Texture2D sprite)
        {
            Position = new Vector2(0, 0);
           
            Offset = offset;
            if (sprite == null)
            {
                 Sprite = RAM.LoadContent(@"DefultSprite");
            }
            else
            {
                Sprite = sprite;
            }
        }
        public void Update(GameTime gametime)
        {
            time.Update(gametime);

        }
        public bool CollisionCheck(Rectangle Rec1, Rectangle Rec2)
        {
            if (Collision == true)
            {
                if (Rec1.Intersects(Rec2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public Texture2D GetSprite()
        {
            return (Sprite);
        }
        public void SetSprite(Texture2D sprite)
        {
            Sprite = sprite;
        }
        public Vector2 GetPosition()
        {
            return Position;
        }
        public float GetPositionX()
        {
            return Position.X;
        }
        public float GetPositionY()
        {
            return Position.Y;
        }
        public void SetPosition(Vector2 position)
        {
            Position = position;
        }
        public void SetPositionX(float x)
        {
            Position.X = x;
        }
        public void SetPositionY(float y)
        {
            Position.Y = y;
        }
        public void SetOffset(Vector2 offset)
        {
            Offset = offset;
        }
        public  Vector2 GetOffset()
        {
            return Offset;
        }
        public void SetCollision(bool col)
        {
            Collision = col;
        }
        public bool GetCollision()
        {
            return Collision;
        }

        public void SetVisibility(bool visible)
        {
            Visible = visible;
        }
        public bool GetVisibility()
        {
            return Visible;
        }
        public void SetLayerLevel(int level)
        {
            LayerLevel = level;
        }
        public int GetLayerLevel()
        {
            return LayerLevel;
        }
    }
    public class BaseEnitiy : BasicSpriteInfo
    {
        int InteractionArea = 24;
        float time = 0;
        CollisionRectangle rec = new CollisionRectangle();
        CollisionCircle cir = new CollisionCircle();
        public Animation CurrentAnimation;

        public BaseEnitiy(Vector2 position, Vector2 offset)
            : base(offset, null)
        {
            SetPosition(position);
            SetOffset(offset);
            rec.SetRectangle((int)position.X, (int)position.Y, RAM.TILESIZE, RAM.TILESIZE);
           // rec.GetCollisionRectangle().Offset(-(RAM.TILESIZE / 2), -(RAM.TILESIZE / 2));
        }
        public void SetCurrentAnimation(Animation animation)
        {
            CurrentAnimation = animation;
        }
        public CollisionRectangle GetRec()
        {
            return rec;
        }
        public int GetInteractionArea()
        {
            return InteractionArea;
        }
        public CollisionCircle GetCir()
        {
            return cir;
        }
        public void SetCircle(CollisionCircle Circ)
        {
            cir = Circ;
        }
        public void SetPosition(Vector2 position)
        {
            base.SetPosition(position);
            rec.SetRectangle((int)position.X, (int)position.Y , rec.GetCollisionRectangle().Width, rec.GetCollisionRectangle().Height);
        }
        public void SetPositionX(float x)
        {
            base.SetPositionX(x);
            rec.SetRectangle((int)x , (int)GetPositionY() , rec.GetCollisionRectangle().Width, rec.GetCollisionRectangle().Height);
        }
        public void SetPositionY(float y)
        {
            base.SetPositionY(y);
            rec.SetRectangle((int)GetPositionX() , (int)y , rec.GetCollisionRectangle().Width, rec.GetCollisionRectangle().Height);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            time += (float)gametime.ElapsedGameTime.TotalMilliseconds;
            if (time >= 166.67)
            {
                time = 0;
                if (CurrentAnimation.GetFrame() != CurrentAnimation.GetMaxFrame())
                {
                    CurrentAnimation.SetFrame(CurrentAnimation.GetFrame() + 1);
                }
                else
                {
                    CurrentAnimation.SetFrame(0);
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D aa = RAM.LoadContent(@"Pixel");

            if (rec != null)
            {
                for (int x = rec.GetInteractiveRectangle().Left; x <= rec.GetInteractiveRectangle().Right; x++)
                {
                    for (int y = rec.GetInteractiveRectangle().Top; y <= rec.GetInteractiveRectangle().Bottom; y++)
                    {
                        if (x <= rec.GetInteractiveRectangle().Left
                            || rec.GetInteractiveRectangle().Right <= x
                            || y <= rec.GetInteractiveRectangle().Top
                            || rec.GetInteractiveRectangle().Bottom <= y)
                        {
                            spriteBatch.Draw(aa, new Vector2(x, y), Color.Red);
                        }
                    }
                }
               /* for (int x = rec.GetCollisionRectangle().Left; x <= rec.GetCollisionRectangle().Right; x++)
                    {
                        for (int y = rec.GetCollisionRectangle().Top; y <= rec.GetCollisionRectangle().Bottom; y++)
                        {
                            if (x <= rec.GetCollisionRectangle().Left
                                || rec.GetCollisionRectangle().Right <= x
                                || y <= rec.GetCollisionRectangle().Top
                                || rec.GetCollisionRectangle().Bottom <= y)
                            {
                                spriteBatch.Draw(bb, new Vector2(x, y), Color.White);
                            }
                        }
                    }*/
            }
            if (cir != null)
            {
                for (int x = 0; x <= 200; x++)
                {
                    int a = (int)Math.Round((GetPosition().X) + (cir.GetRadius() * Math.Cos(x)));
                    int b = (int)Math.Round((GetPosition().Y) - (cir.GetRadius() * Math.Sin(x)));
                    spriteBatch.Draw(aa, new Vector2((float)a, (float)b), Color.Green);
                }
                if (this is AvatarSprite)
                {
                    for (int x = 0; x <= 200; x++)
                    {
                        int a = (int)Math.Round((GetPosition().X) + (cir.GetRadius() + cir.GetInteractionArea()) * Math.Cos(x));
                        int b = (int)Math.Round((GetPosition().Y) - (cir.GetRadius() + cir.GetInteractionArea()) * Math.Sin(x));
                        spriteBatch.Draw(aa, new Vector2((float)a, (float)b), Color.Red);
                    }
                }
            }
            spriteBatch.Draw(aa, GetPosition(), Color.Aqua);
            spriteBatch.Draw(this.GetSprite(), this.GetPosition() + this.GetOffset(), Color.White); 
        }
    }
    public class PlayerCharacter : BaseEnitiy
    {
        public int ObjectID;
        int LookDirection = (int)Looking.kDown;
        public PlayerCharacter(Vector2 position, Vector2 offset)
            : base(position, offset)
        {
            CollisionCircle circ = new CollisionCircle(25, new Vector2((GetSprite().Width / 2), (GetSprite().Height + 70)));
            SetCircle(circ);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
        }
        public void SetLookDirection(int Look)
        {
            LookDirection = Look;
        }
        public int GetLookDirection()
        {
            return LookDirection;
        }
    }

}