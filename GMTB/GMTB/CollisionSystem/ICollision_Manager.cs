using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Collision Manager Interface
    /// </summary>
    interface ICollision_Manager
    {
        /// <summary>
        /// Collision Detection - Setup subroutine
        /// First compile a list of all normalized Normals of each object to test
        /// Runs through all entities in the list
        /// </summary>
        void CollisionDetec();
    }
}
