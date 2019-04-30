using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.CollisionSystem;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    public interface IState
    {
        void Initialize();
        void Update(GameTime _gameTime);
        void Collision(ICollidable _obj);
    }
}
