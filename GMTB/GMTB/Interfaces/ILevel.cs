using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Levels
    /// </summary>
    public interface ILevel
    {
        /// Current Background for level
        string Background { get; }
        /// Level Identifier
        string LvlID { get; }
        /// Level first run or not
        bool FirstRun { set; }

        /// <summary>
        /// Main Initialize Routine
        /// </summary>
        /// <param name="_sl">Reference to the Service Locator</param>
        void Initialise(IServiceLocator _sl);
        /// <summary>
        /// Main Initialize Routine Override resume
        /// </summary>
        /// <param name="_sl">Reference to the Service Locator</param>
        /// <param name="_overrideResume">Set how to Override the Resume setting</param>
        void Initialise(IServiceLocator _sl, bool _overrideResume);
        /// <summary>
        /// Suspends the level and all entities.
        /// </summary>
        void Suspend();
    }
}
