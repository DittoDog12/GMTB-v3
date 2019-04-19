using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface ILevel_Manager
    {
        void RestartLevel();
        void LoadLevel(string _target, bool _suspend);
    }
}
