using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    public interface IQuadtree
    {
        /// <summary>
        /// Clears the Quadtree and all subquadtrees
        /// </summary>
        void Clear();
        /// <summary>
        /// Main process for inserting objects to the quad trees
        /// Splits the tree if the maximum objects is exceeded
        /// </summary>
        /// <param name="_obj"> Collidable object to add to the tree </param>
        void Insert(ICollidable _obj);
        /// <summary>
        /// Main Method for accessing the quadtree process
        /// </summary>
        /// <param name="_objects"> List of objects, either from the Collision Manager as new, or from the previous layer </param>
        /// <param name="_target"> Target object to check against </param>
        /// <returns> List of all objects in the same tree as the specified target object </returns>
        List<ICollidable> Retrieve(List<ICollidable> _objects, ICollidable _target);
    }
}
