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

namespace Breakout
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // 1. Need a tecture for each sprite
        Texture2D paddle;
        Texture2D soccerball;

        // 2. Need a position for each sprite (vector)
        Vector2 paddlePosition;
        Vector2 soccerballPosition;

        // Screen width & height
        int screenWidth;
        int screenHeight;

        // Hitboxes
        Rectangle hitboxPaddle;
        Rectangle hitboxBall;
        int ballSpeedX = 3;
        int ballSpeedY = 3;

        KeyboardState keyState;

        public Game1()
        {

            graphics = new GraphicsDeviceManager(this); //Initialize graphics object
            Content.RootDirectory = "Content";          //Specify content directory

            // Instantiate vectors
            paddlePosition = new Vector2();
            soccerballPosition = new Vector2();

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

        // Loads content at the start of the game
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load paddle from content pipeline and specify the type of content
            paddle = Content.Load<Texture2D>("paddle");
            soccerball = Content.Load<Texture2D>("soccerball");

            // Access screen width and height
            screenWidth = graphics.GraphicsDevice.Viewport.Width;
            screenHeight = graphics.GraphicsDevice.Viewport.Height;

            // Set vector coordinates
            paddlePosition.X = screenWidth / 3;
            paddlePosition.Y = screenHeight / 3;
            soccerballPosition.X = 30;
            soccerballPosition.Y = 30;

            hitboxPaddle = new Rectangle((int)paddlePosition.X, (int)paddlePosition.Y, paddle.Width, paddle.Height);
            hitboxBall = new Rectangle((int)soccerballPosition.X, (int)soccerballPosition.Y, soccerball.Width, soccerball.Height);

        }

        // Unloads content at the end of the game
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        // Called continuously (60 fps)
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Use KeyboardState class to detect key presses
            keyState = Keyboard.GetState();

            // Handle key press - if any
            HandleKeyState();



            // Move soccer ball
            soccerballPosition.X += ballSpeedX;
            soccerballPosition.Y += ballSpeedY;
            
            if(soccerballPosition.X < 0 || soccerballPosition.X + soccerball.Width > screenWidth)
            {
                ballSpeedX = -ballSpeedX;
            }
            if(soccerballPosition.Y < 0 || soccerballPosition.Y + soccerball.Height > screenHeight)
            {
                ballSpeedY = -ballSpeedY;
            }

            // Update hitboxes
            hitboxBall.X = (int)soccerballPosition.X;
            hitboxBall.Y = (int)soccerballPosition.Y;
            hitboxPaddle.X = (int)paddlePosition.X;
            hitboxPaddle.Y = (int)paddlePosition.Y;

            // if ball intersects with paddle
            if (hitboxBall.Intersects(hitboxPaddle))
            {
                if()
                {
                    ballSpeedX = -ballSpeedX;
                }
                else
                {
                    ballSpeedY = -ballSpeedY;
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        // Called continuously (60 fps)
        protected override void Draw(GameTime gameTime)
        {
            // background color
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            // Draw sprites; Parameters: tecture, vector, tint
            spriteBatch.Draw(paddle, paddlePosition, Color.White);
            spriteBatch.Draw(soccerball, soccerballPosition, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }



        public void HandleKeyState()
        {
            if (keyState.IsKeyDown(Keys.A) && paddlePosition.X > 0)
            {
                paddlePosition.X -= 4;
            }

            if (keyState.IsKeyDown(Keys.D) && paddlePosition.X + paddle.Width < screenWidth)
            {
                paddlePosition.X += 4;
            }

            if (keyState.IsKeyDown(Keys.W) && paddlePosition.Y > 0)
            {
                paddlePosition.Y -= 4;
            }

            if (keyState.IsKeyDown(Keys.S) && paddlePosition.Y + paddle.Height < screenHeight)
            {
                paddlePosition.Y += 4;
            }
        }

    }
}
