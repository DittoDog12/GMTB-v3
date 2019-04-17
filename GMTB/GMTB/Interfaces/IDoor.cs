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
        void Subscribe();
        void Initialize(string _target, bool _suspend);
        void Initialize(string _target, Vector2 _playerPos, bool _suspend);
    }
}
