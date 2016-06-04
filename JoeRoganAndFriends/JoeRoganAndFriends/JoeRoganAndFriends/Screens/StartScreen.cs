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
using JoeRoganAndFriends.Screens;

namespace JoeRoganAndFriends.Screens
{
    class StartScreen : GameScreen
    {

        /*
         * TODO:
         *      1. Add "Hello, freak bitches" as intro audio
        */

        SpriteFont testFont;
        Vector2 FontPos;

        ContentManager content;
        GraphicsDeviceManager graphics;
        SpriteBatch sprites;
        KeyboardState ks;

        Texture2D jreLogo;
        Vector2 jreLogPos;

        public StartScreen()
        {
            content = ScreenManager.ContentMgr;
            graphics = ScreenManager.Graphics;
            sprites = ScreenManager.Sprites;
            ks = ScreenManager.ks;
            
        }

        public override void LoadAssets()
        {
            testFont = content.Load<SpriteFont>("testFont");
            FontPos = new Vector2(470, 700);


            jreLogo = content.Load<Texture2D>("jre");
            jreLogPos = new Vector2(335, 150);

        }

        public override void Update(GameTime gameTime)
        {

            ks = Keyboard.GetState();

            if (ks.IsKeyDown(Keys.Enter))
            {
                ScreenManager.currentScreen = ScreenManager.ScreenList[1];
            }

        }

        public override void Draw(GameTime gameTime)
        {
            sprites.Begin();
            sprites.DrawString(testFont, "Joe Rogan & Friends", FontPos, Color.Black);
            sprites.Draw(jreLogo, jreLogPos, Color.White);
            sprites.End();
        }

        public override void UnloadAssets()
        {

        }

    }
}
