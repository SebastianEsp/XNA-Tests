#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace TopDownShooter
{
    class Player : Drawing
    {
        #region Constants
        const string TEXTURE_NAME = "16x16 SH test";
        const int START_POSITION_X = 125;
        const int START_POSITION_Y = 245;
        const int SPEED = 100;
        const int MOVE_UP = -1;
        const int MOVE_DOWN = 1;
        const int MOVE_LEFT = -1;
        const int MOVE_RIGHT = 1;
        const float PLAYER_SIZE = 1.5f;
        const int RIGHT_SCREEN_BOUNDS = 775;
        const int BOTTON_SCREEN_BOUNDS = 575;
        #endregion

        #region Generic Variables
        Vector2 mDirection = Vector2.Zero;
        Vector2 mSpeed = Vector2.Zero;
        #endregion

        #region Animation Variables
        float mTime;
        float mFrameTime = 0.2f;
        int mFrameIndex;
        const int mTotalFrames = 3;
        int mFrameHeight = 16;
        int mFrameWidth = 16;
        #endregion

        public Rectangle PlayerHitbox
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, Source.Width, Source.Height); }
        }

        #region GameStates
        enum GameState
        {
            walking
        }

        GameState mCurrentState = GameState.walking;
        #endregion

        public void LoadContent(ContentManager theContentManager)
        {
            Scale = PLAYER_SIZE;
            Position = new Vector2(START_POSITION_X, START_POSITION_Y);
            base.LoadContent(theContentManager, TEXTURE_NAME);
            Source = new Rectangle(0, 0, 16, Source.Height);
        }

        public void Update(GameTime theGameTime)
        {
            KeyboardState mCurrentKeyState = Keyboard.GetState();

            Walking(mCurrentKeyState, theGameTime);

            CollisionDetection();

            base.Update(theGameTime, mSpeed, mDirection);
        }

        #region Walking
        private void Walking(KeyboardState mCurrentKeyState, GameTime theGameTime)
        {

            if (mCurrentState == GameState.walking)
            {
                mSpeed = Vector2.Zero;
                mDirection = Vector2.Zero;

                if (mCurrentKeyState.IsKeyDown(Keys.W) == true)
                {
                    mSpeed.Y = SPEED;
                    mDirection.Y = MOVE_UP;
                    WalkAnimation(mCurrentKeyState, theGameTime);
                }
                if (mCurrentKeyState.IsKeyDown(Keys.S) == true)
                {
                    mSpeed.Y = SPEED;
                    mDirection.Y = MOVE_DOWN;
                    WalkAnimation(mCurrentKeyState, theGameTime);
                }
                if (mCurrentKeyState.IsKeyDown(Keys.A) == true)
                {
                    mSpeed.X = SPEED;
                    mDirection.X = MOVE_LEFT;
                    WalkAnimation(mCurrentKeyState, theGameTime);
                }
                if (mCurrentKeyState.IsKeyDown(Keys.D) == true)
                {
                    mSpeed.X = SPEED;
                    mDirection.X = MOVE_RIGHT;
                    WalkAnimation(mCurrentKeyState, theGameTime);
                }
            }
        }

        private void WalkAnimation(KeyboardState mCurrentKeyState, GameTime theGameTime)
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
        #endregion

        private void CollisionDetection()
        {
            if (Position.X < 0)
            {
                Position = new Vector2(0, Position.Y);
            }

            if (Position.X > RIGHT_SCREEN_BOUNDS)
            {
                Position = new Vector2(RIGHT_SCREEN_BOUNDS, Position.Y);
            }

            if (Position.Y < 0)
            {
                Position = new Vector2(Position.X, 0);
            }

            if (Position.Y > BOTTON_SCREEN_BOUNDS)
            {
                Position = new Vector2(Position.X, BOTTON_SCREEN_BOUNDS);
            }
        }
    }
}
