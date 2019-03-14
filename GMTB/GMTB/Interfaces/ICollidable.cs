using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    interface ICollidable
    {
        List<Vector2> RectangleNormalize { get; }
        List<Vector2> RectangleVertices { get; }

        int UID { get; }

        void Collision(Vector2 mtv);
    }
}
