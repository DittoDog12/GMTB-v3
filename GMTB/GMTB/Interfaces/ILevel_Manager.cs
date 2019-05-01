using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Level manager
    /// </summary>
    public interface ILevel_Manager
    {
        /// <summary>
        /// Restarts the current level
        /// Clears the Entity Manager and reloads eveything
        /// </summary>
        void RestartLevel();
        /// <summary>
        /// Main Routine for changing Level
        /// </summary>
        /// <param name="_target">New Level to open</param>
        /// <param name="_suspend">Default suspend option</param>
        void LoadLevel(string _target, bool _suspend);
    }
}
