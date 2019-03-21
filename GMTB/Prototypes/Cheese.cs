using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes
{
    public class Cheese : RectangleShape, AITarget
    {
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
        }
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            //base.Collision(_mtv, _cNormal, _otherObj);
            Destroy();
        }
    }
}
