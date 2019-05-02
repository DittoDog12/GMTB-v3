using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    /// <summary>
    /// Level Manager, Controls creating, suspending and resuming levels
    /// </summary>
    public class Level_Manager : ILevel_Manager
    {
        #region Data Members
        /// List of all Levels
        private IDictionary<string, ILevel> mLevels;
        /// Reference to the Service Locator
        private IServiceLocator mServiceLocator;
        /// Reference to the Entity Manager
        private IEntity_Manager mEntityManager;
        /// Current Loaded level
        private ILevel mCurrentLevel;
        #endregion

        #region Accessors
        /// Accessor for current Level
        public string CurrentLevel
        {
            get { return mCurrentLevel.LvlID; }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_sl">Reference to the Service Locator</param>
        /// <param name="_em">Reference to the Entity Manager</param>
        /// <param name="_levels">Pass all Loaded levels here</param>
        public Level_Manager(IServiceLocator _sl, IEntity_Manager _em, IDictionary<string, ILevel> _levels)
        {
            mServiceLocator = _sl;
            mEntityManager = _em;
            mLevels = _levels;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main Routine for changing Level
        /// </summary>
        /// <param name="_target">New Level to open</param>
        /// <param name="_suspend">Default suspend option</param>
        public void LoadLevel(string _target, bool _suspend)
        {
            // If _suspend, then assume player may revisit previous level, set all entities on that level to not active, resume them later.
            if (_suspend)
                mCurrentLevel.Suspend();
            else
                mEntityManager.ClearAll();

            mCurrentLevel = mLevels[_target];
            mLevels[_target].Initialise(mServiceLocator);           
        }
        /// <summary>
        /// Restarts the current level
        /// Clears the Entity Manager and reloads eveything
        /// </summary>
        public void RestartLevel()
        {
            mEntityManager.ClearAll();

            mCurrentLevel = mLevels[mCurrentLevel.LvlID];
            mLevels[mCurrentLevel.LvlID].Initialise(mServiceLocator, true);
        }
        #endregion
    }
}
