using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace CME_XNA_Tutorial
{
    /// <summary>
    /// Class that manages game screens
    /// </summary>
    public class ScreenManager
    {

        #region Variables

        // Create custom content manager
        ContentManager content;

        GameScreen currentScreen;       // screen currently being displayed
        GameScreen newScreen;           // screen overlapping


        // Screen Manager instance
        private static ScreenManager instance;

        // Screen Stack
        Stack<GameScreen> screenStack = new Stack<GameScreen>();


        // Screens width and height
        Vector2 dimensions;

        #endregion



        #region Properties

        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        #endregion



        #region Main Methods

        // Load and unload screens. If added, add to screen stack
        public void AddScreen(GameScreen screen)
        {
            // Example: transitioning from the splash screen to the title screen
            newScreen = screen;         // Not really needed since we're adding screen to the stack
            screenStack.Push(screen);   // Push new screen to stack
            currentScreen.UnloadContent();
            currentScreen = newScreen;
            currentScreen.LoadContent(content);
        }

        // We can call this as many times as we like as opposed to a constructor
        public void Initialize()
        {
            currentScreen = new SplashScreen();
        }  
        // Load content onto the current screen of the stack
        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }
        // Update game using a gameTime object: snapshot of the game timing state 
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        // Draw spritebatch onto the screen
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }

        #endregion

    }
}
