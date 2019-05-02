using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Dialogue
{
    public interface ISpeaker
    {
        /// <summary>
        /// Allows the dialogue system to inform the original behaviour state that the dialogue has finsihed
        /// </summary>
        void DialougeComplete();
    }
}
