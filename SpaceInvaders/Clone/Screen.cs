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
using GameName2;
#endregion

namespace GameName2
{
    public class Screen
    {
        static ContentManager content;
        
        private Texture2D cursor;
        private Texture2D background;
        private Texture2D earth;

        public Screen()
        {

        }
        public virtual void Initalise()
        {

        }
        public virtual void LoadContent(ContentManager Content)
        {
            //content = new ContentManager(Content.ServiceProvider, "Content");
            //background = Content.Load<Texture2D>("stars");
            //earth = Content.Load<Texture2D>("earth");
            //cursor = Content.Load<Texture2D>("cross");
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public virtual void Update(GameTime gameTime)
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {


            //spriteBatch.Draw(background, new Rectangle(0, 0, 1200, 900), Color.White);
            //spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);


        }
    }
}
