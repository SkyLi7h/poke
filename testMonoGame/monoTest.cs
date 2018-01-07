using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace testMonoGame
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class monoTest : Game
	{

		private static readonly DateTime Jan1st1970 = new DateTime
		(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static long CurrentTimeMillis()
		{
			return (long)(DateTime.UtcNow - Jan1st1970).TotalMilliseconds;
		}

		Texture2D textureBall;
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Vector2 positionA = new Vector2(50, 50);
		double maxSpeed = 5;
		double speed = 0;
		double accelaration = 10;
		double deceleration = 5;
		double speedRotation = 1;
		double rotation = 0;
		double angle;
		double dX;
		double dY;
		float scale = 0.7F;

		int xMap = 8000;
		int yMap = 8000;

		public monoTest()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
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
            this.IsMouseVisible = true;
        	graphics.PreferredBackBufferWidth = 1920;
        	graphics.PreferredBackBufferHeight = 1080;
			graphics.ToggleFullScreen();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here
			textureBall = Content.Load<Texture2D>("test");
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// TODO: Add your update logic here

			if (Keyboard.GetState().IsKeyDown(Keys.Up))
			{
				speed += accelaration * (((double)(gameTime.ElapsedGameTime.Milliseconds))/1000);

				if (speed > maxSpeed)
					speed = maxSpeed;

			}

			if (Keyboard.GetState().IsKeyDown(Keys.Down))
			{
				speed -= deceleration * (((double)(gameTime.ElapsedGameTime.Milliseconds))/1000);

				if (speed < 0)
					speed = 0;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Left))
			{
				rotation -= speedRotation;
			}

			if (Keyboard.GetState().IsKeyDown(Keys.Right))
			{
				rotation += speedRotation;
			}

			angle = (float)(2 * Math.PI*(rotation/360));

			dX = (float)(speed * Math.Sin(angle) * -1);
			dY = (float)(speed * Math.Cos(angle));

			positionA.X -= (float)dX;
			positionA.Y -= (float)dY;

			Console.WriteLine(" speed: " + speed);
			Console.WriteLine(" positionA.X: " + positionA.X);
			Console.WriteLine(" positionA.Y: " + positionA.Y);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.Black);

			float taileX = textureBall.Width;
			float taileY = textureBall.Height;

			//TODO: Add your drawing code here
			spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, null);
			spriteBatch.Draw(textureBall , positionA, null, Color.White, (float)angle, new Vector2(taileX/2, taileY/2), scale, SpriteEffects.None, 0);
			spriteBatch.End();

			Console.WriteLine("---------------------");
			Console.WriteLine(" taileX: " + taileX);
			Console.WriteLine(" taileY: " + taileY);
			Console.WriteLine(" taileX/2: " + taileX/2);
			Console.WriteLine(" taileY/2: " + taileY/2);
			Console.WriteLine("---------------------");

			base.Draw(gameTime);
		}
	}
}
