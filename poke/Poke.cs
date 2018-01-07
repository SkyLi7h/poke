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
        DrawManager drawManager = new DrawManager();
        float scale = 1F;

        double angle;
        double dX;
        double dY;



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


            spaceShipsDescList.Add("test", new SpaceShipDesc("test", 5, 5, 10, 10));

            spaceShipsList.Add("test", new SpaceShip(1, 1, (SpaceShipDesc)spaceShipsDescList["test"], 500, 0, 0, 0, 0, new Vector2(250, 50)));
            spaceShipsList.Add("opium", new SpaceShip(1, 1, (SpaceShipDesc)spaceShipsDescList["test"], 500, 0, 0, 0, 0, new Vector2(500, 500)));

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

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                spaceShip.speed += spaceShip.spaceShipDesc.accelaration * (((double)(gameTime.ElapsedGameTime.Milliseconds)) / 1000);

                if (spaceShip.speed > spaceShip.spaceShipDesc.maxSpeed)
                    spaceShip.speed = spaceShip.spaceShipDesc.maxSpeed;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                spaceShip.speed -= spaceShip.spaceShipDesc.deceleration * (((double)(gameTime.ElapsedGameTime.Milliseconds)) / 1000);

                if (spaceShip.speed < 0)
                    spaceShip.speed = 0;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                spaceShip.rotation -= spaceShip.spaceShipDesc.speedRotation;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                spaceShip.rotation += spaceShip.spaceShipDesc.speedRotation;
            }

            angle = (float)(2 * Math.PI * (spaceShip.rotation / 360));

            dX = (float)(spaceShip.speed * Math.Sin(angle) * -1);
            dY = (float)(spaceShip.speed * Math.Cos(angle));

            Vector2 positionActual = spaceShip.positionActual;

            positionActual.X -= (float)dX;
            positionActual.Y -= (float)dY;

            spaceShip.angle = angle;
            spaceShip.positionActual = positionActual;

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
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
