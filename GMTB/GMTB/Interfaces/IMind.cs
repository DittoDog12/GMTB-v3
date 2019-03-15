using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    public interface IMind
    {
        IPhysicalEntity MySelf { get; set; }
        IPathfinder Pathfinder { get; set; }
        void Update(GameTime _gameTime);
        void ChangeState(string _newState);
    }
}
