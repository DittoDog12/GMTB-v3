using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Override Class for non Moving obect
    /// </summary>
    public class StaticObject : RectangleShape, IStaticObject
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
        /// Empty Override
        /// </summary>
        /// <param name="_mtv">Minimum Translation Vector</param>
        /// <param name="_cNormal">Collision normal</param>
        /// <param name="_otherObj">Other Object Collided with</param>
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Empty override
        }
        /// <summary>
        /// Main Physics Update
        /// Empty Override
        /// </summary>
        protected override void UpdatePhysics()
        {
            // Empty override
        }

    }
}
