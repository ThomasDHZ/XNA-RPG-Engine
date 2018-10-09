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
    class FileMenu : Menu
    {
        Pointer pointer = new Pointer(RAM.LoadContent(@"arrow"), Vector2.Zero);
        public FileMenu()
            : base()
        {
        }
        public void Update(GameTime gameTime)
        {
        }
        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
