using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IBasicAI
    {
        Texture2D Texture { get; }
        Vector2 Position { get; }
        Vector2 Acceleration { set; }
        AITarget Target { get; }
        void LocateTarget(AITarget _target);
        void ApplyForce(Vector2 _force);
    }
}
