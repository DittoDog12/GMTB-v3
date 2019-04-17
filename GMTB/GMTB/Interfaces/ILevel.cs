using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface ILevel
    {
        string Background { get; }
        string LvlID { get; }
        bool FirstRun { set; }

        void Initialise(IServiceLocator _sl);
        void Suspend();
    }
}
