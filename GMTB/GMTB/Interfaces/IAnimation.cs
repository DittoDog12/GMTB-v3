using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface IAnimation
    {
        /// lets behaviours control animation frame
        int Frame { get; set; }
    }
}
