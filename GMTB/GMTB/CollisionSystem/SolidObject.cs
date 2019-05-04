using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Object that needs gravity but not move when collided with
    /// </summary>
    public class SolidObject : RectangleShape, IStaticObject
    {
        /// <summary>
        /// Access for object identification
        /// </summary>
        public string TextureName
        {
            get { return mTexturename; }
        }
        /// <summary>
        /// Physical Collision Response
        /// Checks if object is antoher static object
        /// Shouldnt move when collided with player but shouldnt fall through floor or overlap with another object either
        /// </summary>
        /// <param name="_mtv">Minimum Translation Vector</param>
        /// <param name="_cNormal">Collision normal</param>
        /// <param name="_otherObj">Other Object Collided with</param>
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Cast to IStaticObject
            // if cast successful
            // Continue collision
            var asInterface = _otherObj as IStaticObject;
            if (asInterface != null)
                base.Collision(_mtv, _cNormal, _otherObj);
        }
    }
}
