#region Using Statements
using System;
using System.Diagnostics;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
#endregion

namespace GameName2
{
    public class ScreenManager
    {
        static Stack<Screen> allScreens = new Stack<Screen>();
        static ContentManager content;
        //screens
        static Screen currentScreen { get; set; }
        static Screen newScreen { get; set; }


        public static void AddScreen(Screen screen)
        {
            newScreen = screen;
            allScreens.Push(screen);
            if (currentScreen != null)
            {
                currentScreen.UnloadContent();
            }
            currentScreen = newScreen;
            if (content != null)
            {
                currentScreen.LoadContent(content);
            }
            currentScreen.Initalise();
        }
        public static void RemoveScreen()
        {
            currentScreen.UnloadContent();
            //allScreens.Pop();
        }


        public static void Initialise()
        {
            if (currentScreen != null)
            {
                currentScreen.Initalise();
            }
        }
        public static void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(content);
        }
        //public static void UnloadContent()
        //{
        //    Debug.WriteLine(currentScreen.ToString() + "Content Unloaded");
        //    currentScreen.UnloadContent();
        //}
        public static void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
