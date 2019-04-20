using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Microsoft.Xna.Framework;

namespace GMTB.Entities
{
    public class CollectableItem : RectangleShape, IisTrigger, ICollectableItem
    {
        #region Data Members
        private ILockedDoor mTargetDoor;
        #endregion
        #region Constructor
        public CollectableItem()
        {

        }
        #endregion
        #region Methods
        public void SetTarget(ILockedDoor _target)
        {
            mTargetDoor = _target;
        }
        public void OnTrigger(ICollidable _obj)
        {
            IPlayer asInterface = _obj as IPlayer;
            if (asInterface != null)
            {
                mTargetDoor.Unlock();
                mServiceLocator.GetService<IEntity_Manager>().DestroyEntity(UID);
            }
        }
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Blank override
        }
        #endregion
    }
}
