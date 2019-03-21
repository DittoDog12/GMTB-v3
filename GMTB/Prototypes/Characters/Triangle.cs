using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.CollisionSystem;
using Microsoft.Xna.Framework;

namespace Prototypes.Characters.Triangle
{
    class Triangle : TriangleShape
    {
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ApplyForce(new Vector2(-1, 0));
        }
    }
}