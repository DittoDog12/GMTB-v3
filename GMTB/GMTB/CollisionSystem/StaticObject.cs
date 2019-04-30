﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    public class StaticObject : RectangleShape, IStaticObject
    {
        public string TextureName
        {
            get { return mTexturename; }
        }
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
