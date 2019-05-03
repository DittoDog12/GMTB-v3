using GMTB.Entities.AI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Doctor
{
    /// <summary>
    /// Class for the Doctor
    /// </summary>
    public class Doctor : BasicAI
    {
        /// <summary>
        /// Main Constructor
        /// Creates Doctors Mind
        /// </summary>
        public Doctor()
        {
            mMind = new DoctorMind(this);
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
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            if (mVelocity.X > 0)
                mTexturename = "Characters/Doctor/walkLR";
            else if (mVelocity.X < 0)
                mTexturename = "Characters/Doctor/walkL";
        }
    }
}
