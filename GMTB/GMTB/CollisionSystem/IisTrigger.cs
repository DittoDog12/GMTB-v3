using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    public interface IisTrigger
    {
        void OnTrigger(ICollidable _obj);
    }
}
