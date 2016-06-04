using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace JoeRoganAndFriends.Characters
{
    class JoeRogan
    {

        GraphicsDeviceManager graphicsDevice;
        SpriteBatch spriteBatch;
        KeyboardState keyboardState;
        ContentManager content;

        // Head sprite parameters
        Texture2D roganHead;
        Vector2 roganHeadPos;
        Color roganHeadTint;
        SpriteEffects effect = SpriteEffects.FlipHorizontally;

        // Body sprite parameters
        Texture2D roganBody;
        Vector2 roganBodyPos;
        Color roganBodyTint;
        int frameCount;
        TimeSpan runningTimer = new TimeSpan(0,0,0, 0, 100);
        TimeSpan elapsedGameTime;
        SpriteEffects movementFlip = SpriteEffects.FlipHorizontally;

        // Physics parameters
        float velocity = 0;
        float gravity = 0.5f;
        bool onGround = false;

        // Position and movement parae
        int speedX = 5;
        int maxX;
        int maxY;


        // Frames 
        List<Rectangle> movingFrames;


        //ctor
        public JoeRogan(ContentManager content, SpriteBatch spriteBatch, GraphicsDeviceManager graphics, KeyboardState ks)
        {

            // The ContentManager, SpriteBatch, Graphics, and KeyboardState are passed in from the GameScreen parent
            this.spriteBatch = spriteBatch;
            this.graphicsDevice = graphics;
            this.content = content;


            maxX = graphics.GraphicsDevice.Viewport.Width;
            maxY = graphics.GraphicsDevice.Viewport.Height;

            keyboardState = ks;

            movingFrames = new List<Rectangle>();
            frameCount = 0;

        }

        public void LoadAssets()
        {

            roganHead = content.Load<Texture2D>("roganhead");
            roganHeadPos = new Vector2(40, 500);
            roganHeadTint = Color.White;

            roganBody = content.Load<Texture2D>("joeroganmovement");
            roganBodyPos = new Vector2(28, 550);
            roganBodyTint = Color.ForestGreen;

            movingFrames.AddRange
            (
                new Rectangle[]
                {
                    new Rectangle(16, 18, 85, 108),
                    new Rectangle(139, 18, 89, 108),
                    new Rectangle(268, 17, 73, 109),
                    new Rectangle(398, 17, 71, 109),
                    new Rectangle(17, 143, 85, 107),
                    new Rectangle(138, 143, 90, 107),
                    new Rectangle(267, 143, 74, 108),
                    new Rectangle(400, 142, 69, 108)
                }
            );

        }

        public void Update(GameTime gametime)
        {

            keyboardState = Keyboard.GetState();

            


            // move logic
            if (keyboardState.IsKeyDown(Keys.D))
            {
                elapsedGameTime += gametime.ElapsedGameTime;

                roganHeadPos.X += speedX;
                effect = SpriteEffects.FlipHorizontally;
                movementFlip = SpriteEffects.None;
                roganBodyPos.X += speedX;

                if (elapsedGameTime >= runningTimer)
                {
                    elapsedGameTime = TimeSpan.Zero;
                    frameCount++;
                }
                


            }
            else if (keyboardState.IsKeyDown(Keys.A))
            {

                elapsedGameTime += gametime.ElapsedGameTime;

                roganHeadPos.X -= speedX;
                roganBodyPos.X -= speedX;
                effect = SpriteEffects.None;

                if (elapsedGameTime >= runningTimer)
                {
                    elapsedGameTime = TimeSpan.Zero;
                    frameCount++;
                }

                movementFlip = SpriteEffects.FlipHorizontally;
            }

            if (frameCount > movingFrames.Count - 1)
            {
                frameCount = 0;
            }


            // jump logic
            if (keyboardState.IsKeyDown(Keys.Space) && onGround)
            {
                velocity = -15f;
                onGround = false;
            }

            velocity += gravity;
            roganHeadPos.Y += velocity;
            roganBodyPos.Y += velocity;

            if(roganHeadPos.Y >= 500 && roganBodyPos.Y >= 550)
            {
                onGround = true;
                roganHeadPos.Y = 500;
                roganBodyPos.Y = 550;
            }

        }

        public void Draw()
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.NonPremultiplied);
            spriteBatch.Draw(roganHead, roganHeadPos, null, roganHeadTint, 0f, Vector2.Zero, 1f, effect, 0f);
            spriteBatch.Draw(roganBody, roganBodyPos, movingFrames[frameCount], roganBodyTint, 0f, Vector2.Zero, 1.6f,movementFlip, 0f);
            spriteBatch.End();
        }

    }
}
