using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Entities
{
    /// <summary>
    /// Entity to hold a tirggered or repeating sound effect
    /// </summary>
    public class SoundEntity : Entity, ISound
    {
        #region Data Members
        /// Sound to play
        private SoundEffect mSound;
        /// Interval to repeat Sound
        private float mInterval;
        /// Repeat timer
        private float mTimer;
        /// Play sound once?
        private bool mOneShot;
        /// Oneshot sound triggered flag
        private bool mOneShotFired;
        /// Controlable instance for the sound effect
        private SoundEffectInstance mSoundInstance;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public SoundEntity()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Variables override
        /// </summary>
        /// <param name="_sound">Path to sound file</param>
        /// <param name="_interval">Interval to repeat at</param>
        /// <param name="_oneshot">Set if sound should play once or not</param>
        /// <param name="_loop">Set if sound sould loop</param>
        public void setVars(string _sound, float _interval, bool _oneshot, bool _loop, float _vol)
        {
            mSound = mServiceLocator.GetService<IContent_Manager>().LoadSound(_sound);
            mInterval = _interval;
            mOneShot = _oneshot;
            mSoundInstance = mSound.CreateInstance();
            // Set the instance loop control to the loop controller
            mSoundInstance.IsLooped = _loop;
            mSoundInstance.Volume = _vol;
        }
        /// <summary>
        /// Main update loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            mTimer += (float)_gameTime.ElapsedGameTime.TotalSeconds;
            // Play sound every interval, unless it is a one shot sound that has fired.
            if (mTimer >= mInterval && !mOneShotFired)
            {
                
                // Start Playing
                mSoundInstance.Play();
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
        /// <summary>
        /// Pause the sound effect if the entity is suspended
        /// </summary>
        public override void Suspend()
        {
            base.Suspend();
            mSoundInstance.Pause();
        }
        /// <summary>
        /// Resume the sound effect if the entity is resumed
        /// </summary>
        public override void Resume()
        {
            base.Resume();
            mSoundInstance.Play();
        }
        /// <summary>
        /// Cleans up the entitity before destruction
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            mSoundInstance.Pause();
            mSoundInstance.Stop();
            mSoundInstance.Dispose();
        }
        #endregion
    }
}
