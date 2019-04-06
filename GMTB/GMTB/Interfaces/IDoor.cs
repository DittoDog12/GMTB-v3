using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    public interface IDoor
    {
        void setVars(IServiceLocator _sl);
        void Initialize(string _target);
        void InitializeWithPlayerPos(string _target, Vector2 _playerPos);
    }
}
