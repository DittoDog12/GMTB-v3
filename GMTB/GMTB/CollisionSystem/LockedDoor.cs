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
    public class LockedDoor : Door, ILockedDoor, IisTrigger
    {
        #region Data Members
        protected bool mLocked;
        #endregion

        #region Constructor
        public LockedDoor() 
        {
            mLocked = true;
        }

        #endregion

        #region Methods
        public void Unlock()
        {
            mLocked = true;
            mTexture = mContentManager.ApplyTexture("Objects/lock_open");
        }
        public override void OnUse(object source, InputEvent args)
        {
            if (!mLocked)
                base.OnUse(source, args);
        }
        #endregion
    }
}
