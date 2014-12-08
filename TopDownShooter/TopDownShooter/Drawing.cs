#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace TopDownShooter
{
    class Drawing
    {
        #region variables
        //Default draw position
        public Vector2 Position = new Vector2(0, 0);

        //Texture object used when drawing
        private Texture2D mTexture;

        //Determines texture size
        public Rectangle mSize;

        //Determines scaling
        public float mScale = 1.0f;

        //Placeholder for the textures name
        public string mTextureName;

        //A rectangle used when drawing from a SpriteSheet
        Rectangle mSource;
        #endregion

        //Returns a rectangle with the size for a given source. Useful when using SpriteSheets as it only takes a specific part of the SpriteSheet, not the whole thing
        public Rectangle Source
        {
            get { return mSource; }
            set
            {
                mSource = value;
                mSize = new Rectangle(0, 0, (int)(mSource.Width * mScale), (int)(mSource.Height * mScale));
            }
        }

        //Returns a float that defines the scaling of the texture
        public float Scale
        {
            get { return mScale; }
            set 
            {
                mScale = value;
                mSize = new Rectangle(0, 0, (int)(mSource.Width * Scale), (int)(mSource.Height * Scale));
            }
        }

        //Loads gamecontent
        public void LoadContent(ContentManager theContentManager, string theTextureName)
        {
            mTexture = theContentManager.Load<Texture2D>(theTextureName);
            mTextureName = theTextureName;
            Source = new Rectangle(0, 0, mTexture.Width, mTexture.Height);
            mSize = new Rectangle(0, 0, (int)(mTexture.Width * Scale), (int)(mTexture.Height * Scale));
        }

        public void Update(GameTime theGameTime, Vector2 theSpeed, Vector2 theDirection)
        {
            Position += theDirection * theSpeed * (float)theGameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(SpriteBatch theSpriteBatch)
        {
            theSpriteBatch.Draw(mTexture, Position, Source, Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }
    }
}
