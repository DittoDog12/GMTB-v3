using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Sound entites
    /// </summary>
    public interface ISound
    {
        /// <summary>
        /// Set main variables
        /// </summary>
        /// <param name="_sound">Path to sound</param>
        /// <param name="_interval">Interval that sound should trigger</param>
        /// <param name="_oneshot">Set if sound is a oneshot or not</param>
        void setVars(string _sound, float _interval, bool _oneshot);
    }
}
