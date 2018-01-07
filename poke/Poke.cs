using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using poke.GameTools;
using poke.Models;
using poke.Managers;

namespace poke
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Poke : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Hashtable spaceShipsList = new Hashtable();
        Hashtable spaceShipsDescList = new Hashtable();
        List<Shoot> shootList = new List<Shoot>();
        DrawManager drawManager = new DrawManager();
        UpdateManager updateManager = new UpdateManager();
        float scale = 1F;
        MouseState previousMouseState;
        Texture2D fireLaserRed;



        public Poke()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";            
            this.IsMouseVisible = true;
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
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ToggleFullScreen();
            previousMouseState = Mouse.GetState();

            Vector2[] positionTurretList = new Vector2[10];
            positionTurretList[1] = new Vector2(40, 40);
            positionTurretList[2] = new Vector2(25, 40);
            positionTurretList[3] = new Vector2(-30, 40);
            positionTurretList[4] = new Vector2(-15, 40);
            spaceShipsDescList.Add("test", new SpaceShipDesc("test", 10, 5, 10, 10, positionTurretList));

            FixeTurret[] fixeTurrets = new FixeTurret[10];
            fixeTurrets[1] = new FixeTurret("Canon Cat 1", "un canon", 10, 10, 0.1, 0);
            fixeTurrets[2] = new FixeTurret("Canon Cat 1", "un canon", 10, 10, 1, 0);
            fixeTurrets[3] = new FixeTurret("Canon Cat 1", "un canon", 10, 10, 1, 0);
            fixeTurrets[4] = new FixeTurret("Canon Cat 1", "un canon", 10, 10, 1, 0);

            spaceShipsList.Add("test", new SpaceShip(1, 1, (SpaceShipDesc)spaceShipsDescList["test"], null, fixeTurrets, 5000, 0, 0, 0, 0, new Vector2(700, 700)));
            spaceShipsList.Add("opium", new SpaceShip(1, 1, (SpaceShipDesc)spaceShipsDescList["test"], null, null, 500, 0, 0, 0, 0, new Vector2(500, 500)));

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
            drawManager.spriteBatch = spriteBatch;

            foreach (String spaceShipDescKey in spaceShipsDescList.Keys)
            {
                SpaceShipDesc spaceShipsDesc = (SpaceShipDesc)spaceShipsDescList[spaceShipDescKey];
                spaceShipsDesc.texture = Content.Load<Texture2D>(spaceShipsDesc.spaceShipName);
            }

            fireLaserRed = Content.Load<Texture2D>("fireLaserRed");

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

            SpaceShip spaceShip = (SpaceShip)spaceShipsList["test"];
            updateManager.updateSpaceShip(spaceShip, gameTime.ElapsedGameTime.Milliseconds);

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                {
                    updateManager.addShoot(spaceShip, shootList, fireLaserRed);
                }

            updateManager.updateShoot(shootList, gameTime.ElapsedGameTime.Milliseconds);

            //save the current mouse state for the next frame
            previousMouseState = Mouse.GetState();         

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            foreach (String spaceShipKey in spaceShipsList.Keys)
            {
                SpaceShip spaceShip = (SpaceShip)spaceShipsList[spaceShipKey];
                drawManager.drawSpaceShip(spaceShip, scale);
            }

            foreach (Shoot shoot in shootList)
            {             
                drawManager.drawShoot(shoot, scale);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
