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
        void setVars(IEntity_Manager _em, IInput_Manager _im);
        void setVars(IScene_Manager _sm);
        void Initialize();
    }
}
