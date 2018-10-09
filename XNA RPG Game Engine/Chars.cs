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
        Animation WalkForwardAnimation = new Animation(@"Zero\Zero-1");
        Animation WalkLeftAnimation = new Animation(@"ZeroHurt\ZeroHurt-1");
        Animation WalkRightAnimation = new Animation(@"ZeroJump\ZeroJump-1");
        Animation WalkBackwardAnimation = new Animation(@"ZeroStand\ZeroStand-1");

        public AvatarSprite(Vector2 Position, Vector2 Offset)
            : base(Position, Offset, 0)
        {
            base.SetCurrentAnimation(WalkForwardAnimation);
        }
        public void Update(GameTime gametime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyUp(Keys.Up) &&
                keyboardState.IsKeyUp(Keys.Down) &&
                keyboardState.IsKeyUp(Keys.Left) &&
                keyboardState.IsKeyUp(Keys.Right))
            {
                switch (GetLookDirection())
                {
                    case (int)Looking.kUp:
                        {
                            SetCurrentAnimation(WalkForwardAnimation);
                            break;
                        }
                    case (int)Looking.kDown:
                        {
                            SetCurrentAnimation(WalkBackwardAnimation);
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
                }

            }
           
            else if (keyboardState.IsKeyDown(Keys.Up))
            {
                SetLookDirection((int)Looking.kUp);
                SetCurrentAnimation(WalkForwardAnimation);
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                SetLookDirection((int)Looking.kDown);
                SetCurrentAnimation(WalkBackwardAnimation);
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
    /// <summary>
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        public List<string> Talk = new List<string>();
        StoryText Storytext;
        string text = "";

        public NPC(Vector2 Position, Vector2 Offset)
            : base(Position, Offset, 20)
        {
            SetCurrentAnimation(ForwardStandAnimation);
            Talk.Add("Fans of Rock Lee, get ready. According to the inaugural monthly issue of Shueisha's Saikyou Jump magazine, Kenji Taira's Naruto spin-off comedy manga, Rock Lee no Seishun Full-Power Ninden is being adapted into an anime.");
            Talk.Add("Do not store up for yourselves treasures on earth, where moth and rust destroy, and where thieves break in and steal. But store up for yourselves treasures in heaven, where moth and rust do not destroy, and where thieves do not break in and steal. For where your treasure is, there your heart will be also. Matthew 6:19-21 NIV");
            Talk.Add("Fuka_Move_RightFuka_Walk_Right-1");
            Talk.Add("Fuka_Move_BackwardFuka_Walk_Backrward-1");
            Talk.Add("Fuka_Standing_ForwardFuka_Standing_Forward-1");
            Talk.Add("Fuka_Standing_BackwardFuka_Standing_Backward-1");
            Talk.Add("Fuka_Standing_LeftFuka_Standing_Left-1");
            Talk.Add("Fuka_Standing_RightFuka_Standing_Right-1");
            Storytext = new StoryText();
        }
        public void Update(GameTime gametime)
        {
            Storytext.Update(gametime);
            KeyboardState keyboardState = Keyboard.GetState();
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
        public void Talking()
        {
            Storytext.TextBatch = Talk;
            Storytext.AddText();
        }
        public void Draw(SpriteBatch spritebatch)
        {
            Storytext.Draw(spritebatch);
        }
    }

}