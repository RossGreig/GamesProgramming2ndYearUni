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

    public class PlatformShooter : Screen
    {
        public static PlatformShooter instance;


        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        public static readonly int MapWidth = 50;
        public static readonly int MapHeight = 30;
        public static readonly int SpriteWidth = 64;
        public static readonly int SpriteHeight = 64;

        public Texture2D enemyTexture;

        Character player;

        List<Enemy> enemyList;

        Rectangle screen = new Rectangle(0, 0, 1200, 900);
        private Texture2D cursor;
        private Texture2D background;
        private Texture2D earth;
        private Texture2D powerUp;
        private SpriteFont font;
        public int PlayerX;
        public int PlayerY;
        MouseState mouseState;
        Point mousePosition;
        public int rightSide = 1200, leftSide = 0;
        public int score = 0;
        public bool dead = true;
        Random random = new Random();
        //public int timer = random.Next(300, 600);

        public PlatformShooter()
        {
            instance = this;
            enemyList = new List<Enemy>();

            if (dead == true)
            {
                dead = false;
                for (int i = 0; i < 20; i++)
                {
                    enemyList.Add(new Enemy(i));
                }
            }
        }

        public override void Initalise()
        {
            
            mouseState = Mouse.GetState();
            Mouse.SetPosition(screen.Width / 2, screen.Height / 2);
            base.Initalise();
        }

        public override void LoadContent(ContentManager Content)
        {
            //load sprites in
            background = Content.Load<Texture2D>("stars");
            cursor = Content.Load<Texture2D>("cross");
            player = new Character(Content.Load<Texture2D>("TempSprite"), new Vector2(50, 650));
            earth = Content.Load<Texture2D>("earth");
            Shoot.BulletSprite = Content.Load<Texture2D>("Bullet");
            enemyTexture = Content.Load<Texture2D>("black");
            powerUp = Content.Load<Texture2D>("SmallPlus");

            //load in text
            //font = Content.Load<SpriteFont>("Text");

            

            //spriteBatch = new SpriteBatch(GraphicsDevice);

        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //setting escape to exit the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Environment.Exit(0);
            }
            player.Update(gameTime);
            //enemy.Update(gameTime);

            foreach (Enemy item in enemyList)
            {
                item.Update(gameTime);
            }

            //stopping character going out of the screen
            if (player.Position.X < leftSide)
            {
                player.Position.X = 0;
            }
            if (player.Position.X > rightSide - 85)
            {
                player.Position.X = 1115;
            }
            
            //Pressing ESC exits game
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Environment.Exit(0);

            mouseState = Mouse.GetState();
            mousePosition = mouseState.Position;

            //If a bullet hits an enemy remove enemy, bullet and add's score
            for (int i = 0; i < player.Bullets.Count; i++)
            {
                foreach (Enemy enemy in enemyList)
                {
                    if (player.Bullets[i].HitBoundingBox(enemy.invaderPosition, new Vector2(enemy.invaderPosition.X + enemyTexture.Width, enemy.invaderPosition.Y + enemyTexture.Height)))
                    {
                        enemyList.Remove(enemy);
                        player.Bullets.Remove(player.Bullets[i]);
                        score += 100;
                        break;
                    }
                }
            }
            base.Update(gameTime);
        }
       
        //PowerUp
        //public override void PowerUp()
        //{ 
        // timer--;
        //    if (timer == 0)
        //    {
        
        //    } 
        //}

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, 1200, 900), Color.White);
            spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);

            //spriteBatch.DrawString(font, "Score", new Vector2(100, 100), Color.White);

            foreach (Enemy item in enemyList)
            {
                item.Draw(spriteBatch);
            }
            
            player.Draw(spriteBatch);
            spriteBatch.Draw(cursor, new Rectangle(mousePosition.X, mousePosition.Y, 40, 40), Color.White);
            spriteBatch.Draw(powerUp, new Vector2(1300, 700), Color.White);
            base.Draw(spriteBatch);
        }
    }
}
