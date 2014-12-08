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
    class Life : Drawing
    {
        #region Constants
        const string TEXTURE_NAME= "HeartContainersSH";
        const float TEXTURE_SIZE = 0.5f;
        const int POSITION_X = 10;
        const int POSITION_Y = 10;
        #endregion

        Player player;
        Enemy enemy;

        public int mHealth = 10;

        public void LoadContent(ContentManager theContentManager)
        {
            Scale = TEXTURE_SIZE;
            Position = new Vector2(POSITION_X, POSITION_Y);
            base.LoadContent(theContentManager, TEXTURE_NAME);
            Source = new Rectangle(0, 0, 336, Source.Height);
        }
         // Alt herfra og ned virker ikke
        public void Update(GameTime theGameTime)
        {
            EnemyCollision();

        }

        private void EnemyCollision()
        {
            player = new Player();
            enemy = new Enemy();

            if (player.PlayerHitbox.Intersects(enemy.EnemyHitbox))
            {
                mHealth = 0;
                Console.WriteLine("Life: {0}", mHealth);
            }
        }
    }
}
