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
using JoeRoganAndFriends.Characters;



namespace JoeRoganAndFriends.Screens
{
    class TutorialScreen : GameScreen
    {

        /*
         * TODO:
         *      1. Set gym as background
         *      2. 
        */

        JoeRogan joeRogan;

        ContentManager content;
        SpriteBatch sprites;
        GraphicsDeviceManager graphics;
        KeyboardState ks;

        public TutorialScreen()
        {
            content = ScreenManager.ContentMgr;
            sprites = ScreenManager.Sprites;
            graphics = ScreenManager.Graphics;
            ks = ScreenManager.ks;
            joeRogan = new JoeRogan(content, sprites, graphics, ks);
        }

        public override void LoadAssets()
        {
            joeRogan.LoadAssets();
        }

        public override void Update(GameTime gameTime)
        {

            joeRogan.Update(gameTime);

            ks = Keyboard.GetState();

            MouseState m = Mouse.GetState();
            
            //if (m.LeftButton == ButtonState.Pressed && m.X > )
            //{
              
            //}

        }

        public override void Draw(GameTime gameTime)
        {
            joeRogan.Draw();
        }

        public override void UnloadAssets()
        {
            joeRogan = null;
            //base.UnloadAssets(); 
        }


    }
}
