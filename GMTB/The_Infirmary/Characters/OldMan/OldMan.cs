using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities.AI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace The_Infirmary.Characters.OldMan
{
    /// <summary>
    /// Old Man Burt AI
    /// </summary>
    class OldMan : BasicAI
    {
        /// <summary>
        /// Main Constructor
        /// </summary>
        public OldMan()
        {
            mMind = new OldManMind(this);
            mFrames = 8;
            mColumns = 8;
            mInterval = 75f;
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mMoving)
                IncrementFrame(_gameTime);
            base.Draw(_spriteBatch, _gameTime);

            if (mTexturename != mTexture.Name)
                mTexture = mContentManager.ApplyTexture(mTexturename);

        }

        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
        }
    }
}
