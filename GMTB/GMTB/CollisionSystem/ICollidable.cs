﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    public interface ICollidable
    {
        List<Vector2> RectangleNormalize { get; }
        List<Vector2> RectangleVertices { get; }
        Vector2 Velocity { get; }

        int UID { get; }

        void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj);
    }
}