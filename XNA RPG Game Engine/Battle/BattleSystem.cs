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
    public class BattleChar : PlayerCharacter
    {

        public string name = "Test Enemy";
        public int Level;
        public int MaxHP;
        public int MaxMP;
        public int MaxSP;
        public int HP;
        public int MP;
        public int SP;
        public int ATK;
        public int DEF;
        public int INT;
        public int RES;
        public int SPD;
        public int EVD;
        public int EXP;
        public int StaticID;
        public int Clock;
        public bool MoveFlag = true;
        public int TargetPlayer;
        public int Damage = -1;
        public float MoveSpeed;
        public List<Vector2> MoveList = new List<Vector2>();
        public Vector2 CollisionTile;

        public Animation WalkForwardAnimation;
        public Animation WalkLeftAnimation;
        public Animation WalkRightAnimation;
        public Animation WalkBackwardAnimation;
        public Animation WalkUpRightAnimation;
        public Animation WalkUpLeftAnimation;
        public Animation WalkDownRightAnimation;
        public Animation WalkDownLeftAnimation;
        public Animation ForwardStandAnimation;
        public Animation BackwardStandAnimation;
        public Animation LeftStandAnimation;
        public Animation RightStandAnimation;

        CollisionCircle cir;
        CollisionCircle MoveCircle;
        public bool Targeted = false;

        public BattleChar(int ID, Vector2 position, Vector2 Offset, int enemy, int Radius)
            : base(position, Offset)
        {
            // SetOffset(new Vector2(position.X + GetSprite().Width, position.X + GetSprite().Height));
            StaticID = ID;
            SetCurrentAnimation(ForwardStandAnimation);
            cir = new CollisionCircle(25,Vector2.Zero);
            MoveCircle = new CollisionCircle(350, Vector2.Zero);
            
        }
        public void Update(GameTime gametime)
        {
            /* float time = (float)gametime.ElapsedGameTime.TotalMilliseconds;
             float sdf = (float)SPD / 999999.0F;
             float TempSpeed = sdf * .1F;
             MoveSpeed = (time * (.4F + TempSpeed));
             CollisionTile = GetPosition();
             base.Update(gametime);*/
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D bb = RAM.LoadContent(@"Pixel");
            if (Targeted == false)
            {
                spriteBatch.Draw(this.GetSprite(), this.GetPosition() + this.GetOffset(), Color.White);
            }
            else
            {
                spriteBatch.Draw(this.GetSprite(), this.GetPosition() + this.GetOffset(), Color.Red);
            }
            
            int dsd = cir.GetRadius();
            for (int x = 0; x <= 300; x++)
            {
                int a = (int)Math.Round((GetPosition().X) + cir.GetRadius() * Math.Cos(x));
                int b = (int)Math.Round((GetPosition().Y) - cir.GetRadius() * Math.Sin(x));
                spriteBatch.Draw(bb, new Vector2((float)a, (float)b), Color.Red);
            }

            for (int x = 0; x <= 350  * 3; x++)
            {
                int a = (int)Math.Round((GetPosition().X) + MoveCircle.GetRadius() * Math.Cos(x));
                int b = (int)Math.Round((GetPosition().Y) - MoveCircle.GetRadius() * Math.Sin(x));
                spriteBatch.Draw(bb, new Vector2((float)a, (float)b), Color.Red);
            }

        }
    }

    class BattleSystem : VisualRAM
    {
        Vertical_Pointer pointer = new Vertical_Pointer(new Vector2(108, 475), 6, 36);
        
        bool Menuflag = true;
        Player ControlledPlayer = null;
        Time MoveTime = new Time(30);
        string[] MenuItems;
        Vector2 StatsPos;

        public BattleSystem(List<BaseEnitiy> objectlist)
        {
            ObjectList.Add(objectlist);
            RAM.camera.SetPosition(Vector2.Zero);

            MenuItems = new string[6];
            MenuItems[0] = "Move";
            MenuItems[1] = "Attack";
            MenuItems[2] = "Magic";
            MenuItems[3] = "Skill";
            MenuItems[4] = "Defend";
            MenuItems[5] = "Run";

            
        }
        public void Chase(GameTime gameTime, BattleChar battlechar, BattleChar Chased)
        {
            float MoveSpeed = battlechar.MoveSpeed;
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Vector2 point = new Vector2(0, 0);
            point.Y = 0;
            point.X = 0;

            if (battlechar is Enemy)
            {

                point.Y = Chased.GetPosition().Y - battlechar.GetPosition().Y;
                point.X = Chased.GetPosition().X - battlechar.GetPosition().X;
                int ds = 32;
            }
            else if (battlechar is Player)
            {
                point.Y = battlechar.GetPosition().Y - Chased.GetPosition().Y;
                point.X = battlechar.GetPosition().X - Chased.GetPosition().X;
            }

            float slope = point.Y / point.X;
            float yn;
            if (battlechar.MoveFlag == true)
            {
                if (float.IsInfinity(slope))
                {
                    if (battlechar is Enemy)
                    {
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 20
                            && battlechar.GetPosition().Y >= Chased.GetPosition().Y - 20)
                        {
                            int ssd = 34;
                        }
                        else
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {

                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + (time * (MoveSpeed / 10))));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - (time * (MoveSpeed / 10))));
                            }
                        }
                    }
                }
                else if (slope == 0)
                {
                    if (battlechar is Enemy)
                    {
                        if (Chased.GetPosition().Y < battlechar.GetPosition().Y)
                        {

                            for (float x = battlechar.GetPosition().X; x >= Chased.GetPosition().X; )
                            {
                                x -= MoveSpeed;
                                battlechar.SetPosition(new Vector2(x, battlechar.GetPosition().Y));
                            }
                        }
                        else
                        {
                            for (float x = battlechar.GetPosition().X; x <= Chased.GetPosition().X; )
                            {
                                x += MoveSpeed;
                                battlechar.SetPosition(new Vector2(x, battlechar.GetPosition().Y));
                            }
                        }
                    }
                }
                else
                {
                    if (battlechar is Enemy)
                    {
                        float sdfer = battlechar.GetPositionY();
                        float ewr = (time * MoveSpeed);
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 10
                        || battlechar.GetPosition().Y >= Chased.GetPosition().Y + 10)
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {

                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - MoveSpeed));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + MoveSpeed));
                            }
                            int sd = 34;
                        }
                        if (battlechar.GetPosition().X >= Chased.GetPosition().X + 5
                             || battlechar.GetPosition().X <= Chased.GetPosition().X - 5)
                        {
                            if (battlechar.GetPosition().X >= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X - MoveSpeed, battlechar.GetPosition().Y));
                            }
                            if (battlechar.GetPosition().X <= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X + MoveSpeed, battlechar.GetPosition().Y));
                            }
                        }
                    }
                    else
                    {
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 10
                            || battlechar.GetPosition().Y >= Chased.GetPosition().Y + 10)
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {
                                battlechar.SetLookDirection((int)Looking.kUp);
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - MoveSpeed));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetLookDirection((int)Looking.kDown);
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + MoveSpeed));
                            }
                            int sd = 34;
                        }
                        if (battlechar.GetPosition().X >= Chased.GetPosition().X + 5
                             || battlechar.GetPosition().X <= Chased.GetPosition().X - 5)
                        {
                            if (battlechar.GetPosition().X >= Chased.GetPosition().X)
                            {
                                battlechar.SetLookDirection((int)Looking.kLeft);
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X - MoveSpeed, battlechar.GetPosition().Y));
                            }
                            if (battlechar.GetPosition().X <= Chased.GetPosition().X)
                            {
                                battlechar.SetLookDirection((int)Looking.kRight);
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X + MoveSpeed, battlechar.GetPosition().Y));
                            }
                        }
                    }
                }
            }
            else
            {
                if (float.IsInfinity(slope))
                {
                    if (battlechar is Enemy)
                    {
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 25
                            && battlechar.GetPosition().Y >= Chased.GetPosition().Y - 25)
                        {
                            int ssd = 34;
                        }
                        else
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {

                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - (time * (MoveSpeed / 10))));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + (time * (MoveSpeed / 10))));
                            }
                        }
                    }
                }
                else if (slope == 0)
                {
                    if (battlechar is Enemy)
                    {
                        if (Chased.GetPosition().Y < battlechar.GetPosition().Y)
                        {

                            for (float x = battlechar.GetPosition().X; x >= Chased.GetPosition().X; )
                            {
                                x -= MoveSpeed;
                                battlechar.SetPosition(new Vector2(x, battlechar.GetPosition().Y));
                            }
                        }
                        else
                        {
                            for (float x = battlechar.GetPosition().X; x <= Chased.GetPosition().X; )
                            {
                                x += MoveSpeed;
                                battlechar.SetPosition(new Vector2(x, battlechar.GetPosition().Y));
                            }
                        }
                    }
                }
                else
                {
                    if (battlechar is Enemy)
                    {
                        float sdfer = battlechar.GetPositionY();
                        float ewr = (time * MoveSpeed);
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 15
                        || battlechar.GetPosition().Y >= Chased.GetPosition().Y + 15)
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {

                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + MoveSpeed));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - MoveSpeed));
                            }
                            int sd = 34;
                        }
                        if (battlechar.GetPosition().X >= Chased.GetPosition().X + 10
                             || battlechar.GetPosition().X <= Chased.GetPosition().X - 10)
                        {
                            if (battlechar.GetPosition().X >= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X + MoveSpeed, battlechar.GetPosition().Y));
                            }
                            if (battlechar.GetPosition().X <= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X - MoveSpeed, battlechar.GetPosition().Y));
                            }
                        }
                    }
                    else
                    {
                        if (battlechar.GetPosition().Y <= Chased.GetPosition().Y + 15
                            || battlechar.GetPosition().Y >= Chased.GetPosition().Y + 15)
                        {
                            if (battlechar.GetPosition().Y >= Chased.GetPosition().Y)
                            {
                                
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y + MoveSpeed));
                            }
                            if (battlechar.GetPosition().Y <= Chased.GetPosition().Y)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X, battlechar.GetPosition().Y - MoveSpeed));
                            }
                            int sd = 34;
                        }
                        if (battlechar.GetPosition().X >= Chased.GetPosition().X + 10
                             || battlechar.GetPosition().X <= Chased.GetPosition().X - 10)
                        {
                            if (battlechar.GetPosition().X >= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X + MoveSpeed, battlechar.GetPosition().Y));
                            }
                            if (battlechar.GetPosition().X <= Chased.GetPosition().X)
                            {
                                battlechar.SetPosition(new Vector2(battlechar.GetPosition().X - MoveSpeed, battlechar.GetPosition().Y));
                            }
                        }
                    }
                }
            }
        }
        public void Update(GameTime gameTime)
        {
            ((Player)ObjectList[0][0]).ControlledPlayer = true;
            foreach (BaseEnitiy obj in ObjectList[0])
            {
                if(obj is Player)
                {
                    if (((Player)obj).ControlledPlayer == true)
                    {
                        ControlledPlayer = (Player)obj;
                    }
                }
                obj.SetSprite(RAM.LoadContent(obj.CurrentAnimation.GetSpriteName(obj.CurrentAnimation.GetFrame())));
            }
                    
                    

            KeyboardState keyboardState = Keyboard.GetState();
            if (Menuflag == true)
            {
                pointer.Update(gameTime);
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    if (pointer.GetChoice() == 0)//Move
                    {
                        Menuflag = false;
                    }
                    else if (pointer.GetChoice() == 1)//Attack
                    {
                        ((BattleChar)ObjectList[0][5]).Targeted = true;
                    }
                    else if (pointer.GetChoice() == 2)//Magic
                    { }
                    else if (pointer.GetChoice() == 3)//Skill
                    { }
                    else if (pointer.GetChoice() == 4)//Defend
                    { }
                    else if (pointer.GetChoice() == 5)//Run
                    {
                        RAM.BattleFlag = false;
                    }
                }
            }
            else
            {
                // base.Update();
                MoveTime.Update(gameTime);
                foreach (BaseEnitiy obj in ObjectList[0])
                {
                    if (obj is Player)
                    {
                       ((Player)obj).Update(gameTime);
                    }
                    if (obj != ControlledPlayer)
                    {
                        if (obj.GetCir().Intersects(ControlledPlayer.GetPosition(), obj.GetPosition()) == false)
                        {
                            if (keyboardState.IsKeyDown(Keys.Up)
                               && keyboardState.IsKeyDown(Keys.Left))
                            {
                                ControlledPlayer.SetPosition(new Vector2(ControlledPlayer.GetPosition().X + (RAM.TILESIZE / 8), ControlledPlayer.GetPosition().Y + (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Up)
                                && keyboardState.IsKeyDown(Keys.Right))
                            {
                                ControlledPlayer.SetPosition(new Vector2(ControlledPlayer.GetPosition().X - (RAM.TILESIZE / 8), ControlledPlayer.GetPosition().Y + (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                                && keyboardState.IsKeyDown(Keys.Left))
                            {
                                ControlledPlayer.SetPosition(new Vector2(ControlledPlayer.GetPosition().X + (RAM.TILESIZE / 8), ControlledPlayer.GetPosition().Y - (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                                && keyboardState.IsKeyDown(Keys.Right))
                            {
                                ControlledPlayer.SetPosition(new Vector2(ControlledPlayer.GetPosition().X - (RAM.TILESIZE / 8), ControlledPlayer.GetPosition().Y - (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Up))
                            {
                                ControlledPlayer.SetPositionY(ControlledPlayer.GetPosition().Y + RAM.TILESIZE / 8);
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down))
                            {
                                ControlledPlayer.SetPositionY(ControlledPlayer.GetPosition().Y - RAM.TILESIZE / 8);
                            }
                            else if (keyboardState.IsKeyDown(Keys.Left))
                            {
                                ControlledPlayer.SetPositionX(ControlledPlayer.GetPosition().X + RAM.TILESIZE / 8);
                            }
                            else if (keyboardState.IsKeyDown(Keys.Right))
                            {
                                ControlledPlayer.SetPositionX(ControlledPlayer.GetPosition().X - RAM.TILESIZE / 8);
                            }
                        }
                    }
                }
            }
            /*
            KeyboardState keyboardState = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            BattleChar Chased = null;
            base.Update();
            
            //TempList = ObjectList;
            for (int x = 0; x <= PlayerList.Count - 1; )
            {
                PlayerList.Remove(PlayerList[x]);
            }
            for (int x = 0; x <= EnemyList.Count - 1; )
            {
                EnemyList.Remove(EnemyList[x]);
            }
            foreach (BattleChar obj in ObjectList)
            {
                obj.MoveFlag = true;
                if (obj is Player)
                {
                    if(((Player)obj).ControlledPlayer == true)
                    {
                        ControlledPlayer = ((Player)obj);
                    }
                    PlayerList.Add(((Player)obj));
                    ((Player)obj).Update(gameTime);
                }
                if (obj is Enemy)
                {
                    EnemyList.Add(((Enemy)obj));
                    ((Enemy)obj).Update(gameTime);
                }
                CircleCollision(time);
            }
            LeftX = lowest;
            lowest = 0;
            int test = 0;
            /////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////
            
            foreach (Enemy enemy in EnemyList)
            {
                if (enemy.MoveFlag == true)
                {
                    int LowestHP = PlayerList[0].HP;
                    foreach (Player player in PlayerList)
                    {

                        if (LowestHP <= player.HP)
                        {
                            Chased = player;
                        }
                    }

                    Chase(gameTime, enemy, Chased);
                }
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (Player player in PlayerList)
            {
                float MoveSpeed = player.MoveSpeed;
                if (player.MoveFlag == true)
                {
                        if (player is TestPlayer)
                        {
                            
                            if (keyboardState.IsKeyDown(Keys.Right))
                            {
                                float dsd = player.GetPosition().X;
                                float dse = player.GetPosition().Y;
                                int sdf = 34;
                            }
                                                    if (keyboardState.IsKeyDown(Keys.Up)
                                && keyboardState.IsKeyDown(Keys.Left))
                            {

                                player.SetPosition(new Vector2(player.GetPosition().X - MoveSpeed, player.GetPosition().Y - MoveSpeed));
                                camera.SetPosition(new Vector2(camera.GetPosition().X + MoveSpeed, camera.GetPosition().Y + MoveSpeed));
                                StatsPos.X -= MoveSpeed;
                                StatsPos.Y -= MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Up)
                                && keyboardState.IsKeyDown(Keys.Right))
                            {
                                player.SetPosition(new Vector2(player.GetPosition().X + MoveSpeed, player.GetPosition().Y - MoveSpeed));
                                camera.SetPosition(new Vector2(camera.GetPosition().X - MoveSpeed, camera.GetPosition().Y + MoveSpeed));
                                StatsPos.X += MoveSpeed;
                                StatsPos.Y -= MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                            && keyboardState.IsKeyDown(Keys.Left))
                            {
                                player.SetPosition(new Vector2(player.GetPosition().X - MoveSpeed, player.GetPosition().Y + MoveSpeed));
                                camera.SetPosition(new Vector2(camera.GetPosition().X + MoveSpeed, camera.GetPosition().Y - MoveSpeed));
                                StatsPos.X -= MoveSpeed;
                                StatsPos.Y += MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                            && keyboardState.IsKeyDown(Keys.Right))
                            {
                                player.SetPosition(new Vector2(player.GetPosition().X + MoveSpeed, player.GetPosition().Y + MoveSpeed));
                                camera.SetPosition(new Vector2(camera.GetPosition().X - MoveSpeed, camera.GetPosition().Y - MoveSpeed));
                                StatsPos.X += MoveSpeed;
                                StatsPos.Y += MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Up))
                            {
                                player.SetPositionY(player.GetPosition().Y - MoveSpeed);
                                camera.SetPosition(new Vector2(camera.GetPosition().X, camera.GetPosition().Y + MoveSpeed));
                                StatsPos.Y -= MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down))
                            {
                                player.SetPositionY( player.GetPosition().Y + MoveSpeed);
                                camera.SetPosition(new Vector2(camera.GetPosition().X, camera.GetPosition().Y - MoveSpeed));
                                StatsPos.Y += MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Left))
                            {
                                player.SetPositionX(player.GetPositionX() - MoveSpeed);
                                camera.SetPosition(new Vector2(camera.GetPosition().X + MoveSpeed, camera.GetPosition().Y));
                                StatsPos.X -= MoveSpeed;
                            }
                            else if (keyboardState.IsKeyDown(Keys.Right))
                            {
                                float dsd = player.GetPosition().X;
                                float dse = player.GetPosition().Y;
                                float erew = MoveSpeed;
                                player.SetPositionX(player.GetPositionX() + MoveSpeed);
                                camera.SetPosition(new Vector2(camera.GetPosition().X - MoveSpeed, camera.GetPosition().Y));
                                StatsPos.X += MoveSpeed;
                                float dsdg = player.GetPosition().X;
                                int ds = 34;
                            }
                        }
                        else
                        {
                            Chased = EnemyList[0];
                            Chase(gameTime, player,Chased);
                        }     
                }
            }
            foreach (BattleChar obj in ObjectList)
            {
                if (obj.HP < 0)
                {
                    ObjectList.Remove(obj);
                    break;
                }
            }*/
            foreach (BattleChar obj in ObjectList[0])
            {

                 obj.SetSprite(RAM.LoadContent(obj.CurrentAnimation.GetSpriteName(obj.CurrentAnimation.GetFrame())));
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BattleChar obj in ObjectList[0])
            {
                obj.Draw(spriteBatch);
            }
            
            for(int count = 0; count <= 5; count++)
            {
                spriteBatch.DrawString(RAM.GetFont(0), MenuItems[count], new Vector2(108 , 500 + (25* count)), Color.White, 0, RAM.GetFont(0).MeasureString(MenuItems[count]) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.Draw(pointer.GetTexture(), pointer.GetPosition(), Color.White);
            }
            //spriteBatch.Draw(MasterDatabase.GetTile(2).GetTexture(), new Vector2(0, 0), Color.White);
            int x = 0;
            foreach(Player player in RAM.PlayerList)
            {
                spriteBatch.DrawString(RAM.GetFont(0), player.name, new Vector2(StatsPos.X + (108 + (256 * x)), StatsPos.Y + 100), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.name) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), "LV:", new Vector2(StatsPos.X + (200 + (256 * x)), StatsPos.Y + 100), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("LV:") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.Level.ToString(), new Vector2(StatsPos.X + (230 + (256 * x)), StatsPos.Y + 100), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.Level.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);


                spriteBatch.DrawString(RAM.GetFont(0), "HP", new Vector2(StatsPos.X + (20 + (256 * x)), StatsPos.Y + 124), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("HP") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.HP.ToString(), new Vector2(StatsPos.X + (98 + (256 * x)), StatsPos.Y + 124), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.HP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), "/", new Vector2(StatsPos.X + (148 + (256 * x)), StatsPos.Y + 124), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("/") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.MaxHP.ToString(), new Vector2(StatsPos.X + (198 + (256 * x)), StatsPos.Y + 124), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.MaxHP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);


                spriteBatch.DrawString(RAM.GetFont(0), "MP", new Vector2(StatsPos.X + (20 + (256 * x)), StatsPos.Y + 148), Color.White, 0,
                       RAM.GetFont(0).MeasureString("MP") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.MP.ToString(), new Vector2(StatsPos.X + (98 + (256 * x)), StatsPos.Y + 148), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.MP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), "/", new Vector2(StatsPos.X + (148 + (256 * x)), StatsPos.Y + 148), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("/") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.MaxMP.ToString(), new Vector2(StatsPos.X + (198 + (256 * x)), StatsPos.Y + 148), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.MaxMP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);


                spriteBatch.DrawString(RAM.GetFont(0), "SP", new Vector2(StatsPos.X + (20 + (256 * x)), StatsPos.Y + 172), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("SP") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.SP.ToString(), new Vector2(StatsPos.X + (98 + (256 * x)), StatsPos.Y + 172), Color.White, 0,
                       RAM.GetFont(0).MeasureString(player.SP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), "/", new Vector2(StatsPos.X + (148 + (256 * x)), StatsPos.Y + 172), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("/") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.MaxSP.ToString(), new Vector2(StatsPos.X + (198 + (256 * x)), StatsPos.Y + 172), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.MaxSP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);

                spriteBatch.DrawString(RAM.GetFont(0), "Next", new Vector2(StatsPos.X + (34 + (256 * x)), StatsPos.Y + 196), Color.White, 0,
                                       RAM.GetFont(0).MeasureString("Next") / 2, 1.0f, SpriteEffects.None, 0.5f);
                spriteBatch.DrawString(RAM.GetFont(0), player.EXP.ToString(), new Vector2(StatsPos.X + (198 + (256 * x)), StatsPos.Y + 196), Color.White, 0,
                                       RAM.GetFont(0).MeasureString(player.EXP.ToString()) / 2, 1.0f, SpriteEffects.None, 0.5f);
                x++;
            }
            
            /*for (int x = 0; x <= GetObjectCount() - 1; x++)
            {
                GetObject(x).Draw(spriteBatch);
            }*/
        }
    } 
}
