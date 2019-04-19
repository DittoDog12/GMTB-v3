using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    public class Level_Manager : ILevel_Manager
    {
        #region Data Members
        private IDictionary<string, ILevel> mLevels;
        private IServiceLocator mServiceLocator;
        private IEntity_Manager mEntityManager;
        private ILevel mCurrentLevel;
        #endregion

        #region Accessors
        public string CurrentLevel
        {
            get { return mCurrentLevel.LvlID; }
        }
        #endregion
        #region Constructor
        public Level_Manager(IServiceLocator _sl, IEntity_Manager _em, IDictionary<string, ILevel> _levels)
        {
            mServiceLocator = _sl;
            mEntityManager = _em;
            mLevels = _levels;
        }
        #endregion

        #region Methods
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
        public void RestartLevel()
        {
            mEntityManager.ClearAll();

            mCurrentLevel = mLevels[mCurrentLevel.LvlID];
            mLevels[mCurrentLevel.LvlID].Initialise(mServiceLocator, true);
        }
        #endregion
    }
}
