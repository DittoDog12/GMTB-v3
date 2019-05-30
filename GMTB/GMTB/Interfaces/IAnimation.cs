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
        /// Allows states to change amount of frames
        int Frames { set; }
        /// Allows States to change number of columns
        int Columns { set; }
        /// Allows states to tell the physical entity if it's moving or not
        bool Moving { get; set; }
    }
}
