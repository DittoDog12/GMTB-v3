using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Interface for collidable entities
    /// </summary>
    public interface ICollidable
    {
        //List<Vector2> RectangleNormalize { get; }
        /// List of Vertices
        List<Vector2> RectangleVertices { get; }
        /// Vector Position
        Vector2 Position { get; set; }
        /// Vector Velocity
        Vector2 Velocity { get; }
        /// AABB Hitbox
        Rectangle Hitbox { get; }

        /// Entitiy Unique Idendifier
        int UID { get; }

        /// Update all variables for Collision Detection
        List<Vector2> UpdateCollisionMesh();
        /// Non Physical Collision Trigger
        void Collision(ICollidable _obj);
        /// Physical Collision Trigger
        void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj);
    }
}
