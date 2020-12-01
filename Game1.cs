﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Template
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D bg;
        Texture2D playertex;
        Vector2 playerPos = new Vector2(40, 100);
        Player player;
        List<Bullet> bulletList = new List<Bullet>();
        Timer timer;
        public static int ScreenWidth
        {
            get;
            private set;
        }
        public static int ScreenHeight
        {
            get;
            private set;
        }
        //KOmentar
        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            

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
            IsMouseVisible = true;

            base.Initialize();
             
            graphics.PreferredBackBufferWidth = ScreenWidth = GraphicsDevice.DisplayMode.Width;
            graphics.PreferredBackBufferHeight = ScreenHeight = GraphicsDevice.DisplayMode.Height;
            graphics.ApplyChanges();

            timer = new Timer(this, 90.0f);
            timer.Font = Content.Load<SpriteFont>("Font");
            timer.Position = new Vector2(this.Window.ClientBounds.Width / 2 - timer.Font.MeasureString(timer.Text).X/2,0);
            Components.Add(timer);
        }//https://www.youtube.com/watch?v=-2FeSrYT1KE

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            bg = Content.Load<Texture2D>("Stars");
            playertex = Content.Load<Texture2D>("Player");
            player = new Player(playertex, playerPos, bulletList);
            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
            timer.Update(gameTime);
            player.Update();

            foreach (var item in bulletList)
            {
                item.Update();
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);
            spriteBatch.Begin();
            spriteBatch.Draw(bg,new Rectangle (0,0, ScreenWidth, ScreenHeight),Color.White);
            player.Draw(spriteBatch);
            foreach (var item in bulletList)
            {
                item.Draw(spriteBatch);
            }
            timer.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
