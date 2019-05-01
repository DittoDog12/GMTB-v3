using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for door
    /// </summary>
    public interface IDoor
    {
        /// <summary>
        /// Subscribe to Use Input Events
        /// </summary>
        void Subscribe();
        /// <summary>
        /// Main Initalizer
        /// </summary>
        /// <param name="_target">LevelID to switch to</param>
        /// <param name="_suspend">Set whether or not to suspend the exiting level</param>
        void Initialize(string _target, bool _suspend);
    }
}
