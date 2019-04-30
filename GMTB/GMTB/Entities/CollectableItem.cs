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
    /// <summary>
    /// Collectable Item
    /// Unlocks a specified door when collided with
    /// </summary>
    public class CollectableItem : RectangleShape, IisTrigger, ICollectableItem
    {
        #region Data Members
        /// Door to unlock when collected
        private ILockedDoor mTargetDoor;
        #endregion
        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public CollectableItem()
        {

        }
        #endregion
        #region Methods
        /// <summary>
        /// Set the door to unlock
        /// </summary>
        /// <param name="_target">Target Door</param>
        public void SetTarget(ILockedDoor _target)
        {
            mTargetDoor = _target;
        }
        /// <summary>
        /// Trigger Collision
        /// Unlocks the target door and removes this item from the game world on collision
        /// </summary>
        /// <param name="_obj">Other Object Collided with</param>
        public void OnTrigger(ICollidable _obj)
        {
            // Check the other object is the Player via casting
            IPlayer asInterface = _obj as IPlayer;
            if (asInterface != null)
            {
                // Unlock other door
                mTargetDoor.Unlock();
                // Remove self from world
                Destroy();
            }
        }
        /// <summary>
        /// Physical Collision Override
        /// Blank Override
        /// </summary>
        /// <param name="_mtv">Minimum Translation Vector</param>
        /// <param name="_cNormal">Collision Normal</param>
        /// <param name="_otherObj">Other Object Collided with</param>
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Blank override
        }
        #endregion
    }
}
