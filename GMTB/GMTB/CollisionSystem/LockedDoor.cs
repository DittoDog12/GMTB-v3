using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using GMTB.Managers;
using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Locked Door Object
    /// </summary>
    public class LockedDoor : Door, ILockedDoor, IisTrigger
    {
        #region Data Members
        /// Door locked flag
        protected bool mLocked;
        #endregion

        #region Constructor
        public LockedDoor() 
        {
            mLocked = true;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Trigger to Unlock door
        /// </summary>
        public void Unlock()
        {
            mLocked = false;
            mTexture = mContentManager.ApplyTexture("Objects/lock_open");
        }
        /// <summary>
        /// Door Activate Override
        /// Checks for door locked before using parent door object
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        public override void OnUse(object source, InputEvent args)
        {
            if (!mLocked)
                base.OnUse(source, args);
        }
        #endregion
    }
}
