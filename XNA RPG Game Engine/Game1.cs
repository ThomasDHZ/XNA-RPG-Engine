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



    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        bool MainGameFlag = true;
        bool MenuFlag = false;
     
        Map map;
        BattleSystem battle;
        MainMenu menu;
        float time = 0;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            //graphics.ToggleFullScreen();
            
            Content.RootDirectory = "Content";
            RAM.LoadContentMgr(Content);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            
            base.Initialize();
            
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
           spriteBatch = new SpriteBatch(GraphicsDevice);

           RAM.camera = new Camera();

           RAM.Add_Font(Content.Load<SpriteFont>("SpriteFont1"));
           RAM.Add_Font(Content.Load<SpriteFont>("SpriteFont2"));
           RAM.Add_Font(Content.Load<SpriteFont>("SpriteFont3"));
           RAM.Add_Font(Content.Load<SpriteFont>("SpriteFont4"));
           RAM.Add_Font(Content.Load<SpriteFont>("SpriteFont5"));




           RAM.Add_Player(new TestPlayer(0, new Vector2(486, 543), new Vector2(-20, -130)));
           RAM.Add_Player(new TestPlayer2(1, new Vector2(1054, 445), Vector2.Zero));
           RAM.Add_Player(new TestPlayer3(2, new Vector2(164, 634), Vector2.Zero));
           RAM.Add_Player(new TestPlayer4(3, new Vector2(534, 543), Vector2.Zero));
           RAM.Add_Player(new TestPlayer5(4, new Vector2(16 * 60, 8 * 60), Vector2.Zero));

           //RAM.Add_Item(new ItemPotion());

           RAM.Add_Item(new EquipmentItems("Rusty Armor", "It's old", 1));
           RAM.Add_Item(new EquipmentItems("Paring Knife", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Semispathae", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Cutlass", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Main Gauche", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Claymore", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Gurkha", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Night Saber", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Heavy Sword", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Dragon Blade", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Plant Saber", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Sigh", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Bloody Dagger", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Ninja Sword", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Rock Buster", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Berserk Stinger", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Passing Showers", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Exorcist", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Quaking Blade", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Ancient Hero", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Blood Shark", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Crystal Blade", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Hero Blade", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Super Flashlight", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Dragon Slayer", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Ridill", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Regal Darkness", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Edmon Ninja", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Ogre Knife", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Titan's Treasure", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Heavenly Wings", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Hades Blade", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Hrunting", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Durandal", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("RFragarach", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Dainsleif", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Eckesachs", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Claiomh Solais", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Aroundight", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Yoshisuna", "It's a key... to a door", 1));
           RAM.Add_Item(new EquipmentItems("Baal Sword", "It's a key... to a door", 1));

           RAM.Add_Item(new BattleItems("Poison Pill", "It's a key... to a door", 1));
           RAM.Add_Item(new BattleItems("Freeze Pill", "It's a key... to a door", 1));

           RAM.Add_Item(new Synthesizing("Iron", "It's a key... to a door", 1));
           RAM.Add_Item(new Synthesizing("Steel", "It's a key... to a door", 1));
           RAM.Add_Item(new Synthesizing("Bronze", "It's a key... to a door", 1));
           RAM.Add_Item(new Synthesizing("Sliver", "It's a key... to a door", 1));
           RAM.Add_Item(new Synthesizing("Gold", "It's a key... to a door", 1));

           RAM.Add_Item(new StoryItems("Blood", "It's old", 1));
           RAM.Add_Item(new StoryItems("Key", "It's old", 1));

           

           map = new Map();
           

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            RAM.camera.Update(gameTime);


            if (MainGameFlag == true)
            {
                map.Update(gameTime);
                if (RAM.TalkFlag == true)
                {
                    RAM.Storytext.Update(gameTime);
                }
            }
            else
            {
                if (RAM.BattleFlag == false)
                {
                    MainGameFlag = true;
                }
            }
            if (RAM.BattleFlag == true)
            {
                MainGameFlag = false;
                if (battle != null)
                {
                    battle.Update(gameTime);
                }
                else
                {
                    List<BaseEnitiy> chars = new List<BaseEnitiy>();
                    foreach(Player player in RAM.PlayerList)
                    {
                        chars.Add(player);
                    }
                    chars.Add(new Reaper(0, new Vector2(0, 0), Vector2.Zero, 0, 32));
                    battle = new BattleSystem(chars);
                }
            }
            if (MenuFlag == true)
            {
                menu.Update(gameTime);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (MenuFlag == true)
            {
                time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (menu.GetMainMenuFlag() == false)
                {
                    time = 0;
                }
                if (keyboardState.IsKeyDown(Keys.Escape))
                {
                    if (menu.GetMainMenuFlag() == true)
                    {
                        if (time >= 150)
                        {
                            menu = null;
                            MenuFlag = false;
                            MainGameFlag = true;
                        }
                    }
                }
            }
            if (keyboardState.IsKeyDown(Keys.Tab))
            {
                if (RAM.BattleFlag == false)
                {
                    //battle = new BattleSystem(camera, graphics,  Content);
                   // battle.SetCameraPos(Vector2.Zero);
                }
                MainGameFlag = false;
                RAM.BattleFlag = true;
            }
            if (keyboardState.IsKeyDown(Keys.Z))
            {
                MenuFlag = true;
                MainGameFlag = false;
                menu = new MainMenu();
            }

            base.Update(gameTime);
        }
 
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        RAM.camera.GetTransformMatrix(graphics.GraphicsDevice));
            if (MainGameFlag == true)
            {
                map.Draw(spriteBatch);
                if (RAM.TalkFlag == true)
                {
                    RAM.Storytext.Draw(spriteBatch);
                }
                else
                {
                    RAM.Storytext = new StoryText();
                }
            }
            else if (RAM.BattleFlag == true)
            {
                battle.Draw(spriteBatch);
            }
            else if (MenuFlag == true)
            {
                menu.Draw(spriteBatch,gameTime);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
