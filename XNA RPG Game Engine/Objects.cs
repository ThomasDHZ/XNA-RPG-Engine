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
    public class AvatarSprite : PlayerCharacter
    {
        Animation WalkForwardAnimation = new Animation(@"Val_Move_Forward\Val_Walk_Forward-1");
        Animation WalkLeftAnimation = new Animation(@"Val_Move_Left\Val_Walk_Left-1");
        Animation WalkRightAnimation = new Animation(@"Val_Move_Right\Val_Walk_Right-1");
        Animation WalkBackwardAnimation = new Animation(@"Val_Move_Backward\Val_Walk_Backrward-1");

        Animation WalkUpRightAnimation = new Animation(@"Val_Move_UpRight\Val_Walk_UpRight-1");
        Animation WalkUpLeftAnimation = new Animation(@"Val_Move_UpLeft\Val_Walk_UpLeft-1");
        Animation WalkDownRightAnimation = new Animation(@"Val_Move_DownRight\Val_Walk_DownRight-1");
        Animation WalkDownLeftAnimation = new Animation(@"Val_Move_DownLeft\Val_Walk_DownLeft-1");

        Animation ForwardStandAnimation = new Animation(@"Val_Standing_Forward\Val_Standing_Forward-1");
        Animation BackwardStandAnimation = new Animation(@"Val_Standing_Backward\Val_Standing_Backward-1");
        Animation LeftStandAnimation = new Animation(@"Val_Standing_Left\Val_Standing_Left-1");
        Animation RightStandAnimation = new Animation(@"Val_Standing_Right\Val_Standing_Right-1");

        public AvatarSprite(Vector2 Position)
            : base(Position, new Vector2(-30, -130))
        {
            GetRec().SetRectangle((int)GetPositionX()-10, (int)GetPositionY()-10, 20, 20);
            base.SetCurrentAnimation(WalkForwardAnimation);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            RAM.camera.SetPosition(new Vector2(640 - GetPosition().X, 360 - GetPosition().Y));
            float a = 640 - GetPosition().X;
                float b = 360 - GetPosition().Y;
            KeyboardState keyboardState = Keyboard.GetState();

                if (RAM.OnFoot == true)
                {
                    if (time.GetTimeFlag() == true)
                    {
                        if (keyboardState.IsKeyDown(Keys.Up)
                        && keyboardState.IsKeyDown(Keys.Left))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X - (RAM.TILESIZE / 8), (int)GetPosition().Y - (RAM.TILESIZE / 8)) == true)
                            {
                                SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Up)
                            && keyboardState.IsKeyDown(Keys.Right))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X + (RAM.TILESIZE / 8), (int)GetPosition().Y - (RAM.TILESIZE / 8)) == true)
                            {
                                SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Down)
                            && keyboardState.IsKeyDown(Keys.Left))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X - (RAM.TILESIZE / 8), (int)GetPosition().Y + (RAM.TILESIZE / 8)) == true)
                            {
                                SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X - (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Down)
                            && keyboardState.IsKeyDown(Keys.Right))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X + (RAM.TILESIZE / 8), (int)GetPosition().Y + (RAM.TILESIZE / 8)) == true)
                            {
                                SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8),GetPosition().Y + (RAM.TILESIZE / 8)));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X + (RAM.TILESIZE / 8), RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Up))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X, (int)GetPosition().Y - (RAM.TILESIZE / 8)) == true)
                            {
                                SetPositionY(GetPosition().Y - (RAM.TILESIZE / 8));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y - (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Down))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X, (int)GetPosition().Y + (RAM.TILESIZE / 8)) == true)
                            {
                                SetPositionY(GetPosition().Y + (RAM.TILESIZE / 8));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.TextBoxPos.X, RAM.camera.GetTextBoxPosition().Y + (RAM.TILESIZE / 8));
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Left))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X - (RAM.TILESIZE / 8), (int)GetPosition().Y) == true)
                            {
                                SetPositionX(GetPosition().X - (RAM.TILESIZE / 8));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X - (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                            }
                        }
                        else if (keyboardState.IsKeyDown(Keys.Right))
                        {
                            if (RAM.MapArea.MoveOnFoot((int)GetPosition().X + (RAM.TILESIZE / 8), (int)GetPosition().Y) == true)
                            {
                                SetPositionX(GetPosition().X + (RAM.TILESIZE / 8));
                                RAM.camera.TextBoxPos = new Vector2(RAM.camera.GetTextBoxPosition().X + (RAM.TILESIZE / 8), RAM.camera.TextBoxPos.Y);
                            }
                        }
                        CheckOnBoat();
                    }
                
                if (keyboardState.IsKeyUp(Keys.Up) &&
                    keyboardState.IsKeyUp(Keys.Down) &&
                    keyboardState.IsKeyUp(Keys.Left) &&
                    keyboardState.IsKeyUp(Keys.Right))
                {
                    switch (GetLookDirection())
                    {
                        case (int)Looking.kUp:
                            {
                                SetCurrentAnimation(WalkBackwardAnimation);
                                break;
                            }
                        case (int)Looking.kDown:
                            {
                                SetCurrentAnimation(WalkForwardAnimation);
                                break;
                            }
                        case (int)Looking.kLeft:
                            {
                                SetCurrentAnimation(WalkLeftAnimation);
                                break;
                            }
                        case (int)Looking.kRight:
                            {
                                SetCurrentAnimation(WalkRightAnimation);
                                break;
                            }
                        case (int)Looking.kUpLeft:
                            {
                                SetCurrentAnimation(WalkUpLeftAnimation);
                                break;
                            }
                        case (int)Looking.kUpRight:
                            {
                                SetCurrentAnimation(WalkUpRightAnimation);
                                break;
                            }
                        case (int)Looking.kDownLeft:
                            {
                                SetCurrentAnimation(WalkDownLeftAnimation);
                                break;
                            }
                        case (int)Looking.kDownRight:
                            {
                                SetCurrentAnimation(WalkDownRightAnimation);
                                break;
                            }
                    }
                }
                else if (keyboardState.IsKeyDown(Keys.Up)
                && keyboardState.IsKeyDown(Keys.Left))
                {
                    SetLookDirection((int)Looking.kUpLeft);
                    SetCurrentAnimation(WalkUpLeftAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Up)
                    && keyboardState.IsKeyDown(Keys.Right))
                {
                    SetLookDirection((int)Looking.kUpRight);
                    SetCurrentAnimation(WalkUpRightAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Down)
                    && keyboardState.IsKeyDown(Keys.Left))
                {
                    SetLookDirection((int)Looking.kDownLeft);
                    SetCurrentAnimation(WalkDownLeftAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Down)
                    && keyboardState.IsKeyDown(Keys.Right))
                {
                    SetLookDirection((int)Looking.kDownRight);
                    SetCurrentAnimation(WalkDownRightAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Up))
                {
                    SetLookDirection((int)Looking.kUp);
                    SetCurrentAnimation(WalkBackwardAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    SetLookDirection((int)Looking.kDown);
                    SetCurrentAnimation(WalkForwardAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Left))
                {
                    SetLookDirection((int)Looking.kLeft);
                    SetCurrentAnimation(WalkLeftAnimation);
                }
                else if (keyboardState.IsKeyDown(Keys.Right))
                {
                    SetLookDirection((int)Looking.kRight);
                    SetCurrentAnimation(WalkRightAnimation);
                }
            }
        }
        private void CheckOnBoat()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
            {
                if (obj is Boat)
                {
                        if (GetRec().GetCollisionRectangle().Intersects(obj.GetRec().GetCollisionRectangle()))
                        {
                            if (keyboardState.IsKeyDown(Keys.Space))
                            {
                                if (RAM.MapArea.MoveOnFoot((int)GetPosition().X, (int)GetPosition().Y) == false)
                                {
                                    SetVisibility(false);
                                    RAM.OnFoot = false;
                                    RAM.OnShip = true;
                                }
                            }
                        }
                    
                }
            }
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class NPC : PlayerCharacter
    {
        Animation WalkForwardAnimation = new Animation(@"Fuka_Move_Forward\Fuka_Walk_Forward-1");
        Animation WalkLeftAnimation = new Animation(@"Fuka_Move_Left\Fuka_Walk_Left-1");
        Animation WalkRightAnimation = new Animation(@"Fuka_Move_Right\Fuka_Walk_Right-1");
        Animation WalkBackwardAnimation = new Animation(@"Fuka_Move_Backward\Fuka_Walk_Backrward-1");
        Animation ForwardStandAnimation = new Animation(@"Fuka_Standing_Forward\Fuka_Standing_Forward-1");
        Animation BackwardStandAnimation = new Animation(@"Fuka_Standing_Backward\Fuka_Standing_Backward-1");
        Animation LeftStandAnimation = new Animation(@"Fuka_Standing_Left\Fuka_Standing_Left-1");
        Animation RightStandAnimation = new Animation(@"Fuka_Standing_Right\Fuka_Standing_Right-1");
        public string Talk = "";
        string text = "";

        public NPC(Vector2 Position)
            : base(Position, new Vector2(0, -100))
        {
            GetRec().SetInteractiveRectangle((int)GetPositionX() - 16, (int)GetPositionY() - 16, RAM.TILESIZE + 32, RAM.TILESIZE + 32);
            SetCurrentAnimation(ForwardStandAnimation);
            Talk = "In the event of the explosion in the capital of Solaris earlier... ... I had set up a nanomachine virus to diffuse into the atmosphere. I knew they were eventually going to break the seal... But the timing was a little close for comfort... The current mutations of the humans are an initial response to the virus... Once the virus we spread over the world germinates inside of the humans, they are no longer the same. They change into a controllable form. We need humans that do not depend on the key's invocation in order to awaken. In other words, a being to take the place of the original body of god...";
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                {
                    if (obj is AvatarSprite)
                    {
                        if (keyboardState.IsKeyDown(Keys.Space))
                        {
                            if (GetRec().GetInteractiveRectangle().Intersects(obj.GetRec().GetCollisionRectangle()))
                            {
                                if (((AvatarSprite)obj).GetLookDirection() == (int)Looking.kUp)
                                {
                                    SetLookDirection((int)Looking.kDown);
                                }
                                else if (((AvatarSprite)obj).GetLookDirection() == (int)Looking.kDown)
                                {
                                    SetLookDirection((int)Looking.kUp);
                                }
                                else if (((AvatarSprite)obj).GetLookDirection() == (int)Looking.kRight)
                                {
                                    SetLookDirection((int)Looking.kLeft);
                                }
                                else if (((AvatarSprite)obj).GetLookDirection() == (int)Looking.kLeft)
                                {
                                    SetLookDirection((int)Looking.kRight);
                                }
                                if (RAM.TalkFlag == false)
                                {
                                    RAM.Storytext.AddText("Load Files/TextFile1dfd.txt");
                                }
                                    RAM.TalkFlag = true;
                            }
                        }
                    }
                }
                if (keyboardState.IsKeyUp(Keys.Up) &&
                    keyboardState.IsKeyUp(Keys.Down) &&
                    keyboardState.IsKeyUp(Keys.Left) &&
                    keyboardState.IsKeyUp(Keys.Right))
                {
                    switch (GetLookDirection())
                    {
                        case (int)Looking.kUp:
                            {
                                SetCurrentAnimation(ForwardStandAnimation);
                                break;
                            }
                        case (int)Looking.kDown:
                            {
                                SetCurrentAnimation(BackwardStandAnimation);
                                break;
                            }
                        case (int)Looking.kLeft:
                            {
                                SetCurrentAnimation(LeftStandAnimation);
                                break;
                            }
                        case (int)Looking.kRight:
                            {
                                SetCurrentAnimation(RightStandAnimation);
                                break;
                            }
                        case (int)Looking.kUpLeft:
                            {
                                SetCurrentAnimation(ForwardStandAnimation);
                                break;
                            }
                        case (int)Looking.kUpRight:
                            {
                                SetCurrentAnimation(ForwardStandAnimation);
                                break;
                            }
                        case (int)Looking.kDownLeft:
                            {
                                SetCurrentAnimation(BackwardStandAnimation);
                                break;
                            }
                        case (int)Looking.kDownRight:
                            {
                                SetCurrentAnimation(BackwardStandAnimation);
                                break;
                            }
                    }
                }
            }
        }
        public void Talking()
        {
            //RAM.Storytext.Text = Talk;
            //RAM.Storytext.AddText();
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Boat : BaseEnitiy
    {
        Animation animation = new Animation(@"ship-1");
        public bool OnShipFlag = false;
        public Boat(Vector2 position)
            : base(position, new Vector2(0,0))
        {
            SetCollision(false);
            SetCurrentAnimation(animation);
        }
        public void Update(GameTime gametime, BaseEnitiy Enitiy = null)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            base.Update(gametime);
            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                if (RAM.OnShip == true)
                {
                    foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                    {
                        if (obj is AvatarSprite)
                        {
                            RAM.camera.SetPosition(new Vector2(640 - GetPosition().X, 360 - GetPosition().Y));
                            if (time.GetTimeFlag() == true)
                            {
                                if (keyboardState.IsKeyDown(Keys.Up)
                                    && keyboardState.IsKeyDown(Keys.Left))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X - (RAM.TILESIZE / 8), (int)GetPosition().Y - (RAM.TILESIZE / 8)) == true)
                                    {
                                        SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                        obj.SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Up)
                                    && keyboardState.IsKeyDown(Keys.Right))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X + (RAM.TILESIZE / 8), (int)GetPosition().Y - (RAM.TILESIZE / 8)) == true)
                                    {
                                        SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                        obj.SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down)
                                    && keyboardState.IsKeyDown(Keys.Left))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X - (RAM.TILESIZE / 8), (int)GetPosition().Y + (RAM.TILESIZE / 8)) == true)
                                    {
                                        SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                                        obj.SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down)
                                    && keyboardState.IsKeyDown(Keys.Right))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X + (RAM.TILESIZE / 8), (int)GetPosition().Y + (RAM.TILESIZE / 8)) == true)
                                    {
                                        SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                                        obj.SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Up))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X, (int)GetPosition().Y) == true)
                                    {
                                        SetPositionY(GetPosition().Y - (RAM.TILESIZE / 8));
                                        obj.SetPositionY(GetPosition().Y - (RAM.TILESIZE / 8));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Down))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X, (int)GetPosition().Y) == true)
                                    {
                                        SetPositionY(GetPosition().Y + (RAM.TILESIZE / 8));
                                        obj.SetPositionY(GetPosition().Y + (RAM.TILESIZE / 8));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Left))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X, (int)GetPosition().Y) == true)
                                    {
                                        SetPositionX(GetPosition().X - (RAM.TILESIZE / 8));
                                        obj.SetPositionX(GetPosition().X - (RAM.TILESIZE / 8));
                                    }
                                }
                                else if (keyboardState.IsKeyDown(Keys.Right))
                                {
                                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X, (int)GetPosition().Y) == true)
                                    {
                                        SetPositionX(GetPosition().X + (RAM.TILESIZE / 8));
                                        obj.SetPositionX(GetPosition().X + (RAM.TILESIZE / 8));
                                    }
                                }
                                CheckOnFoot();
                            }
                        }
                    }
                }
            }
        }
        private void CheckOnFoot()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
            {
                if (obj is AvatarSprite)
                {

                    if (RAM.MapArea.MoveOnShip((int)GetPosition().X, (int)GetPosition().Y) == true)
                    {
                        if (keyboardState.IsKeyDown(Keys.A))
                        {
                            if (keyboardState.IsKeyDown(Keys.Up)
                                    && keyboardState.IsKeyDown(Keys.Left))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Up)
                                && keyboardState.IsKeyDown(Keys.Right))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y - (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                                && keyboardState.IsKeyDown(Keys.Left))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down)
                                && keyboardState.IsKeyDown(Keys.Right))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPosition().Y + (RAM.TILESIZE / 8)));
                            }
                            if (keyboardState.IsKeyDown(Keys.Up))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X, GetPositionY() - (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Down))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X, GetPositionY() + (RAM.TILESIZE / 8)));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Left))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X - (RAM.TILESIZE / 8), GetPositionY()));
                            }
                            else if (keyboardState.IsKeyDown(Keys.Right))
                            {
                                obj.SetPosition(new Vector2(GetPosition().X + (RAM.TILESIZE / 8), GetPositionY()));
                            }
                            obj.SetVisibility(true);
                            RAM.OnFoot = true;
                            RAM.OnShip = false;
                            OnShipFlag = true;
                        }
                    }
                }
            }
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Chest : BaseEnitiy
    {
        bool Opened = false;
        bool ItemGet = false;
        bool TimePassedFlag = false;
        Items Item;
        Vector2 Pos;
        Animation CloseAnimation = new Animation(@"chestClosed-1");
        Animation FrontOpenAnimation = new Animation(@"treasurechestopen-1");
        Time time = new Time(2000);
        public Chest(Vector2 position, Items item)
            : base(position, new Vector2(0, 0))
        {
            GetRec().SetInteractiveRectangle((int)GetPositionX(), (int)GetPositionY(), RAM.TILESIZE, RAM.TILESIZE + 8);
            Item = item;
            Pos = position;
            SetCurrentAnimation(CloseAnimation);
        }
        public void Update(GameTime gametime)
        {
            
            KeyboardState keyboardState = Keyboard.GetState();
            base.Update(gametime);
            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                time.Update(gametime);
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                    {
                        if (obj is AvatarSprite)
                        {
                            if (GetRec().GetInteractiveRectangle().Intersects(obj.GetRec().GetCollisionRectangle())
                                && ((AvatarSprite)obj).GetLookDirection() == (int)Looking.kUp)
                            {
                                Opened = true;
                            }
                        }
                    }
                }
                if (Opened == true)
                {
                    if (ItemGet == false)
                    {
                        ItemGet = true;
                        SetCurrentAnimation(FrontOpenAnimation);
                        RAM.Add_Item(Item);
                    }
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (ItemGet == true)
            {
                if (time.GetTimeFlag() == true)
                {
                    TimePassedFlag = true;
                }
                else
                {
                    if (TimePassedFlag == false)
                    {
                        spriteBatch.DrawString(RAM.GetFont(0), Item.name + " x " + Item.count, new Vector2(GetPosition().X, (GetPosition().Y) - (float)(time.GetTime() / 35)), Color.White, 0,
                                               RAM.GetFont(0).MeasureString(Item.name) / 2, 1.0f, SpriteEffects.None, 0.5f);
                    }
                }
            }
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    class Door : BaseEnitiy
    {
        bool SteppedOnFlag = false;
        bool flag = false;
        Animation CloseAnimation = new Animation(@"Closedoor-1");
        Animation OpenAnimation = new Animation(@"OpenDoor-1");
        public Door(Vector2 position)
            : base(position, new Vector2(0,0))
        {
            SetCurrentAnimation(CloseAnimation);
            SetCollision(false);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                {
                    if (obj is AvatarSprite)
                    {
                        if (GetRec().GetCollisionRectangle().Intersects(obj.GetRec().GetCollisionRectangle()))
                        {
                            if (flag == false)
                            {
                                flag = true;
                                if (SteppedOnFlag == false)
                                {
                                    SteppedOnFlag = true;
                                }
                                else
                                {
                                    SteppedOnFlag = false;
                                }
                                SetCurrentAnimation(OpenAnimation);
                                RAM.MapArea.SeeTopLayer = false;
                            }
                        }
                        else
                        {
                            flag = false;
                            SetCurrentAnimation(CloseAnimation);
                        }
                        if (SteppedOnFlag == true)
                        {
                            RAM.MapArea.SeeTopLayer = false;
                        }
                        else
                        {
                            RAM.MapArea.SeeTopLayer = true;
                        }
                    }
                }
            }
        }
    }
    class LayerChange : BaseEnitiy
    {
        Animation animation = new Animation(@"stairs-1");
        bool SteppedOnFlag = true;
        string UpDown;
        public LayerChange(Vector2 position, Vector2 Size, string updown)
            : base(position, new Vector2(-32, -32))
        {
        SetCollision(false);
        SetCurrentAnimation(animation);
        UpDown = updown;
        GetRec().SetRectangle((int)GetPositionX() - 32, (int)GetPositionY() - 32, (int)Size.X, (int)Size.Y);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);
            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                {
                    if (obj is AvatarSprite)
                    {
                        AvatarSprite ava = ((AvatarSprite)obj);
                        if (GetRec().GetCollisionRectangle().Intersects(obj.GetRec().GetCollisionRectangle()))
                        {
                            if (SteppedOnFlag == false)
                            {
                                SteppedOnFlag = true;
                                RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel].Remove(ava);
                                if (UpDown == "+")
                                {
                                    RAM.MapArea.MAPLAYER += 2;
                                    RAM.VRAM.LayerLevel += 1;
                                }
                                else
                                {
                                    RAM.MapArea.MAPLAYER -= 2;
                                    RAM.VRAM.LayerLevel -= 1;
                                }
                                RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel].Add(ava);
                            }
                        }
                        else
                        {
                            SteppedOnFlag = false;
                        }
                    }
                }
            }
        }
    }
    class Encounter_Area : BaseEnitiy
    {
        Vector2 PlayerPos;
        Random rand = new Random(100);
        Animation animation = new Animation(@"Tiles/blanktile-1");
        public Encounter_Area(Vector2 position, Vector2 Size)
            : base(position, Size)
        {
            SetCollision(false);
            SetCurrentAnimation(animation);
            GetRec().SetRectangle((int)GetPositionX() - 32, (int)GetPositionY() - 32, (int)Size.X, (int)Size.Y);
        }
        public void Update(GameTime gametime)
        {
            base.Update(gametime);

            if (GetLayerLevel() == RAM.VRAM.LayerLevel)
            {
                foreach (BaseEnitiy obj in RAM.VRAM.ObjectList[RAM.VRAM.LayerLevel])
                {
                    if (obj is AvatarSprite)
                    {
                        if (GetRec().GetCollisionRectangle().Intersects(obj.GetRec().GetCollisionRectangle()))
                        {
                            if(PlayerPos != obj.GetPosition())
                            {
                                int ds = rand.Next(0, 10000);
                                if (ds >= 9900)
                                {
                                    RAM.BattleFlag = true;
                                    
                                }
                            }
                        }
                        PlayerPos = obj.GetPosition();
                    }
                }
            }
        }
    }
}

