using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface IContent_Manager
    {
        void ApplyTexture(string tex, IPhysicalEntity ent);
        void ApplyTexture(string _tex, IBackground_Manager _man);
    }
}
