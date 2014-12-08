using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter
{
    class Enemy : Drawing
    {
        #region Constants
        const string TEXTURE_NAME = "16x16 SH test";
        const int START_POSITION_X = 800;
        const int START_POSITION_Y = 400;
        const int SPEED = 100;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        const float PLAYER_SIZE = 1.5f;
        const int ENEMY_DISTANCE = 800;
        #endregion

        #region Generic Variables
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        static Random rnd = new Random();
        int rndStart = rnd.Next(10, 590);
        #endregion

        #region Animation Variables
        float mTime;
        float mFrameTime = 0.2f;
        int mFrameIndex;
        const int mTotalFrames = 3;
        int mFrameHeight = 16;
        int mFrameWidth = 16;
        #endregion

        List<Enemy> enemyList = new List<Enemy>();

        public Rectangle EnemyHitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Source.Width, Source.Height); }
        }

        public void LoadContent(ContentManager theContentManager)
        {
            Scale = PLAYER_SIZE;
            Position = new Vector2(START_POSITION_X, rndStart);
            base.LoadContent(theContentManager, TEXTURE_NAME);
            Source = new Rectangle(0, 0, 16, Source.Height);
        }

        public void Update(GameTime theGameTime)
        {
            Walking(theGameTime);
            base.Update(theGameTime, mSpeed, mDirection);
        }

        private void Walking(GameTime theGameTime)
        {
                mSpeed.X = SPEED;
                mDirection.X = MOVE_LEFT;
                WalkAnimation(theGameTime);
        }

        private void WalkAnimation(GameTime theGameTime)
        {
            mTime += (float)theGameTime.ElapsedGameTime.TotalSeconds;

            while (mTime > mFrameTime)
            {
                mFrameIndex++;

                mTime = 0f;
            }

            if (mFrameIndex > mTotalFrames)
            {
                mFrameIndex = 1;
            }

            Source = new Rectangle(mFrameIndex * mFrameWidth, 0, mFrameWidth, mFrameHeight);
        }
    }
}
