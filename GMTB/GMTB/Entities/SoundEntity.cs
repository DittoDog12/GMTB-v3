using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Entities
{
    public class SoundEntity : Entity, ISound
    {
        #region Data Members
        private SoundEffect mSound;
        private float mInterval;
        private float mTimer;
        private bool mOneShot;
        private bool mOneShotFired;
        #endregion

        #region Constructor
        public SoundEntity()
        {
            
        }
        #endregion

        #region Methods
        public void setVars(string _sound, float _interval, bool _oneshot)
        {
            mSound = mServiceLocator.GetService<IContent_Manager>().LoadSound(_sound);
            mInterval = _interval;
            mOneShot = _oneshot;
        }
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            mTimer += (float)_gameTime.ElapsedGameTime.TotalSeconds;
            // Play sound every interval, unless it is a one shot sound that has fired.
            if (mTimer >= mInterval && !mOneShotFired)
            {
                mSound.Play();
                // If not a oneshot, reset timer
                if (!mOneShot)
                    mTimer = 0;
                // If a oneshot, set oneshot fired to prevent retriggering, and destroy object.
                else
                {
                    mOneShotFired = true;
                    mServiceLocator.GetService<IEntity_Manager>().DestroyEntity(UID);
                }
                    

            }
        }
        #endregion
    }
}
