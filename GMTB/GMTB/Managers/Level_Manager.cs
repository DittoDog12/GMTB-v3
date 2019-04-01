using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;

namespace GMTB.Managers
{
    public class Level_Manager : ILevel_Manager
    {
        #region Data Members
        private IDictionary<string, ILevel> mLevels;
        private IServiceLocator mServiceLocator;
        private IEntity_Manager mEntityManager;
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
        public void LoadLevel(string _target)
        {
            mEntityManager.ClearAll();
            mLevels[_target].Initialise(mServiceLocator);
        }
        #endregion
    }
}
