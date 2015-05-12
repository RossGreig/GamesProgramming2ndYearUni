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
    class Shoot
    {
        public static Texture2D BulletSprite;
        public static float BulletSpeed = 9f;
        public Vector2 BulletLocation;
        public Vector2 BulletVelocity;
        public double BulletAngle;
        public Character character;
        public int CharCentre = 32;
        public bool IsActive = true;


        public void Shooting(Vector2 shootFrom, Vector2 shootTo)
        {          
            BulletLocation = shootFrom;
            BulletAngle = Math.Atan2((shootTo.Y - shootFrom.Y), (shootTo.X - shootFrom.X)); //use a vector instead of an angle
        }

        public void Update(GameTime GameTime)
        {
            BulletVelocity = new Vector2((float)Math.Cos(BulletAngle) * BulletSpeed, (float)Math.Sin(BulletAngle) * BulletSpeed);
            BulletLocation += BulletVelocity;
        }

        public bool HitBoundingBox(Vector2 Min, Vector2 Max)
        {
            if ((BulletLocation.X >= Min.X && BulletLocation.X <= Max.X) && (BulletLocation.Y >= Min.Y && BulletLocation.Y <= Max.Y)) 
                return true;
            
            else 
                return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BulletSprite, BulletLocation, Color.White);
        }

        public void ByeByeBullet()
        {
            IsActive = false;
        }
    }
}
