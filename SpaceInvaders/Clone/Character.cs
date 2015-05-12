#region Using Statements
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
#endregion

namespace GameName2
{
    class Character
    {
        Texture2D texture;
        public Vector2 Position;
        Vector2 Velocity;
        public Vector2 CursorPosition;
        public Vector2 CharacterCentre;
        public int ShotTimer = 0;
        public int TimeBetweenShots = 50;
        bool HasShot;
        bool hasJumped;
        Shoot Bullet;
        //int rightSide = 1200, leftSide = PlatformShooter.SpriteWidth;
        Rectangle screen = new Rectangle(0, 0, 1200, 900);


        public List<Shoot> Bullets = new List<Shoot>();

        public Character(Texture2D newTexture, Vector2 newposition)
        {
            texture = newTexture;
            Position = newposition; //TODO also update CharacterCentre //also update whenever Position changes
            updateCharacterCentre();
            hasJumped = true;
        }

        private void updateCharacterCentre()
        {
            CharacterCentre = Position + new Vector2(32, 64);
        }

        //Load Bullet
        public List<Shoot> Load()
        {
            return Bullets;
        }

        public void Reload(List<Shoot> Bull)
        {
            Bullets = Bull;
        }

        public void Update(GameTime gameTime)
        {
            
            //Player movement
            Position += Velocity;
            updateCharacterCentre();
            KeyboardState state = Keyboard.GetState();
            
                if (state.IsKeyDown(Keys.A))
                {
                    Velocity.X = -6f;
                }
                else
                {
                    Velocity.X = 0f;
                }
                if (state.IsKeyDown(Keys.D))
                {
                    Velocity.X = +6f;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.W) && hasJumped == false)
                {
                    Position.Y -= 10f;
                    updateCharacterCentre();
                    Velocity.Y = -12f;
                    hasJumped = true;
                }

                if (hasJumped == true)
                {
                    float i = 2;
                    Velocity.Y += 0.19f * i;
                }

                if (Position.Y + texture.Height >= 890)
                {
                    hasJumped = false;
                }

                if (hasJumped == false)
                {
                    Velocity.Y = 0f;
                }

            //Shooting
            CursorPosition = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            if (ShotTimer >= TimeBetweenShots)
            {
                ShotTimer = 0;
                HasShot = false;
            }

            MouseState mouse = Mouse.GetState();

            if (mouse.LeftButton == ButtonState.Pressed) //if left mouse button is pressed
            {
                if (ShotTimer == 0)
                { 
                
                    //Create Bullet
                    Bullet = new Shoot();
                    Bullet.Shooting(CharacterCentre, CursorPosition);
                    Bullets.Add(Bullet);
                    HasShot = true;
                }
            }

            if (HasShot)
            {
                ShotTimer++;
            }

            //update each bullet that this class handles
            foreach (Shoot BulletItem in Bullets)
            {
                BulletItem.Update(gameTime);
            }

            //Remove useless bullets
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (!Bullets[i].IsActive)
                {
                    Bullets.Remove(Bullets[i]);
                }
            }
        }
        
        public bool Hit(Vector2 Min, Vector2 Max)
        {
            if ((CharacterCentre.X >= Min.X && CharacterCentre.X <= Max.X) && (CharacterCentre.Y >= Min.Y && CharacterCentre.Y <= Max.Y))
            {
                return true;
            }
            else
                return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw self
            spriteBatch.Draw(texture, Position, Color.White);

            //draw bullets
            foreach (Shoot Bullet in Bullets)
            {
                Bullet.Draw(spriteBatch);
            }
        }
    }
}
