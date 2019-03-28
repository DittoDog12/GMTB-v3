using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    public interface IUtility_Entity
    {
        void setVars(IServiceLocator _sl);
        void Initialize();
    }
}
