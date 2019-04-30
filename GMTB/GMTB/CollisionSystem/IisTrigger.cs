using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Allows Objects to inform the Collision manager they are a trigger rather than a physical object
    /// </summary>
    public interface IisTrigger
    {
        /// <summary>
        /// Trigger Collision Event
        /// </summary>
        /// <param name="_obj">Object Triggered with</param>
        void OnTrigger(ICollidable _obj);
    }
}
