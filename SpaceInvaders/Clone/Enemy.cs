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

namespace GameName2
{
    public class Enemy
    {
        static ContentManager content;

        public int rightSide = 1200, leftSide = 0;

        public Vector2 invaderPosition;
        public bool invaderDirection = true;
        public float invaderSpeed = 1.0f;
        public float addedSpeed = 0.5f;
        public bool alive = true;
        public bool invaderDrop = false;
        public float timer = 200f;

        //Enemy shoot stuff
        public static Texture2D EnemyBulletSprite;
        public static float EnemyBulletSpeed = 7f;
        public Vector2 EnemyBulletLocation;
        public Vector2 EnemyBulletVelocity;

        public Enemy(int startPosition)
        {
            switch (startPosition)
            {
                case 0:
                    invaderPosition = new Vector2(1.0f, 1.0f);
                    break;

                case 1:
                    invaderPosition = new Vector2(101.0f, 1.0f);
                    break;

                case 2:
                    invaderPosition = new Vector2(201.0f, 1.0f);
                    break;

                case 3:
                    invaderPosition = new Vector2(301.0f, 1.0f);
                    break;

                case 4:
                    invaderPosition = new Vector2(401.0f, 1.0f);
                    break;

                case 5:
                    invaderPosition = new Vector2(1.0f, 101.0f);
                    break;

                case 6:
                    invaderPosition = new Vector2(101.0f, 101.0f);
                    break;

                case 7:
                    invaderPosition = new Vector2(201.0f, 101.0f);
                    break;

                case 8:
                    invaderPosition = new Vector2(301.0f, 101.0f);
                    break;

                case 9:
                    invaderPosition = new Vector2(401.0f, 101.0f);
                    break;

                case 10:
                    invaderPosition = new Vector2(1.0f, 201.0f);
                    break;

                case 11:
                    invaderPosition = new Vector2(101.0f, 201.0f);
                    break;

                case 12:
                    invaderPosition = new Vector2(201.0f, 201.0f);
                    break;

                case 13:
                    invaderPosition = new Vector2(301.0f, 201.0f);
                    break;

                case 14:
                    invaderPosition = new Vector2(401.0f, 201.0f);
                    break;

                case 15:
                    invaderPosition = new Vector2(1.0f, 301.0f);
                    break;

                case 16:
                    invaderPosition = new Vector2(101.0f, 301.0f);
                    break;

                case 17:
                    invaderPosition = new Vector2(201.0f, 301.0f);
                    break;

                case 18:
                    invaderPosition = new Vector2(301.0f, 301.0f);
                    break;

                case 19:
                    invaderPosition = new Vector2(401.0f, 301.0f);
                    break;
            }
        }

        public virtual void Initalise()
        {
            
        }
        public virtual void LoadContent(ContentManager Content)
        {
            
        }
        public virtual void UnloadContent()
        {
            content.Unload();
        }
        public void EnemyShoot()
        { 
            
        }
        
        public virtual void Update(GameTime gameTime)
        {
            //increase space invaders speed based on time
            timer--;
            if (timer == 0)
            {
                invaderSpeed = invaderSpeed + addedSpeed;
                timer = 200;
            }
            //Which way the invaders should move
            if (invaderDirection == true)
            {
                invaderPosition += new Vector2 (invaderSpeed, 0.0f);
            }
            if (invaderDirection == false)
            {
                invaderPosition -= new Vector2 (invaderSpeed, 0.0f);
            }
            //Invaders dropping
            if (invaderDrop == true)
            {
                invaderPosition += new Vector2 (0.0f, 50.0f);
            }

            //Make invaders change direction and drop
            if (invaderPosition.X < leftSide)
            {;
                invaderDrop = true;
                invaderDirection = true;
                invaderPosition.X = 0;
                invaderPosition += new Vector2(0.0f, 100.0f);
                invaderDrop = false;
            }
            if (invaderPosition.X > rightSide - 85)
            {
                invaderDrop = true;
                invaderDirection = false;
                invaderPosition.X = 1115;
                invaderPosition += new Vector2(0.0f, 100.0f);
                invaderDrop = false;
            }
            //Game over state
            if (invaderPosition.Y > 700)
            {
                Environment.Exit(0);
            }

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(PlatformShooter.instance.enemyTexture, invaderPosition, Color.White);
        }
    }
}