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
    public class Floor : RectangleShape, IFloor
    {
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Empty override
        }

        protected override void UpdatePhysics()
        {
            // Empty override
        }

    }
}
