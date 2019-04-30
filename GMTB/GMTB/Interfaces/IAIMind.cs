using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;

namespace GMTB.Interfaces
{
    public interface IAIMind
    {
        IBasicAI MySelf { get; set; }
        IPathfinder Pathfinder { get; set; }
        AITarget Target { get; }
        void Update(GameTime _gameTime);
        void ChangeState(string _newState);
        void Initialize();
        void OnTrigger(ICollidable _obj);
    }
}
