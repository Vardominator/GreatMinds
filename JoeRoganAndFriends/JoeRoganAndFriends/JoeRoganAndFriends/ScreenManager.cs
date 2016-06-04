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
using JoeRoganAndFriends.Screens;

namespace JoeRoganAndFriends
{
    class ScreenManager : Game
    {


        public static GraphicsDeviceManager Graphics;           // Graphics manager to set screen size and draw
        public static SpriteBatch Sprites;                      // Sprites to be put on the screen
        public static List<GameScreen> ScreenList;              // List of Screens
        public static ContentManager ContentMgr;                // Content manager to load all content to be used

        public static KeyboardState ks;                         // Keyboard state for key presses

        public static GameScreen currentScreen;                 // The current screen to be shown


        // Loads the game and runs
        public static void Main()
        {
            using (ScreenManager manager = new ScreenManager())
            {
                manager.Run();
            }
        }
        

        // Screen manager constructor 
        public ScreenManager()
        {
            // Create graphics manager object
            Graphics = new GraphicsDeviceManager(this);

            // Set screen params
            Graphics.PreferredBackBufferWidth = 1200;
            Graphics.PreferredBackBufferHeight = 800;

            // Set content directory
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {

            base.Initialize();
        }

        // Ran once when game starts
        protected override void LoadContent()
        {
            ContentMgr = Content;
            Sprites = new SpriteBatch(GraphicsDevice);

            AddScreen(new StartScreen());
            AddScreen(new TutorialScreen());
           
            currentScreen = ScreenList[0];          

            base.LoadContent();
        }

        protected override void UnloadContent()
        {

            foreach(GameScreen screen in ScreenList)
            {
                screen.UnloadAssets();
            }

            ScreenList.Clear();
            Content.Unload();

            base.UnloadContent();
        }


        // Where all game logic is update and any necessary calculations are performed
        protected override void Update(GameTime gameTime)
        {
            // Exit screen if escape key is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            int startIndex = ScreenList.Count - 1;

            currentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            int startIndex = ScreenList.Count - 1;

            Graphics.GraphicsDevice.Clear(currentScreen.BackgroundColor);
            currentScreen.Draw(gameTime);

            base.Draw(gameTime);
        }

        public static void AddScreen(GameScreen gameScreen)
        {
            gameScreen.LoadAssets();

            if(ScreenList == null)
            {
                ScreenList = new List<GameScreen>();
            }
            ScreenList.Add(gameScreen);

            gameScreen.LoadAssets();
        }

        public static void RemoveScreen(GameScreen gameScreen)
        {
            gameScreen.UnloadAssets();
            ScreenList.Remove(gameScreen);

            if(ScreenList.Count < 1)
            {
                AddScreen(new TutorialScreen());
            }
        }

        public static void ChangeScreens(GameScreen currentScreen, GameScreen targetScreen)
        {
            RemoveScreen(currentScreen);
            AddScreen(targetScreen);
        }

    }
}



















