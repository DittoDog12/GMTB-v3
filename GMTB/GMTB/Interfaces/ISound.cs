using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface ISound
    {
        void setVars(string _sound, float _interval, bool _oneshot);
    }
}
