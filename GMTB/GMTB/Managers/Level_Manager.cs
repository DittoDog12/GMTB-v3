using GMTB.CollisionSystem;
using GMTB.InputSystem;
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
        /// List of Loaded Levels
        private IDictionary<string, ILevel> mLoadedLevels;
        #endregion

        #region Accessors
        /// Accessor for current Level ID
        public string CurrentLevelID
        {
            get { return mCurrentLevel.LvlID; }
        }
        /// Accessor for current level
        public ILevel CurrentLevel
        {
            get { return mCurrentLevel; }
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
            mLoadedLevels = new Dictionary<string, ILevel>();
            mServiceLocator.GetService<IInput_Manager>().SubCheats(LevelSkip);
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
                ExitLevel();

            mCurrentLevel = mLevels[_target];
            if (mCurrentLevel.FirstRun)
                mLoadedLevels.Add(mCurrentLevel.LvlID, mCurrentLevel);
            mLevels[_target].Initialise(mServiceLocator);

        }
        /// <summary>
        /// Restarts the current level
        /// Clears the Entity Manager and reloads eveything
        /// </summary>
        public void RestartLevel()
        {
            mServiceLocator.GetService<ICollision_Manager>().AbortCollisionDetection();
            ExitLevel();

            mCurrentLevel = mLevels[mCurrentLevel.LvlID];
            mLoadedLevels.Add(mCurrentLevel.LvlID, mCurrentLevel);
            mLevels[mCurrentLevel.LvlID].Initialise(mServiceLocator, true);
        }
        /// <summary>
        /// Destory all Entities in all loaded levels
        /// </summary>
        public void ExitLevel()
        {
            foreach (KeyValuePair<string, ILevel> _Level in mLoadedLevels)
                _Level.Value.Exit();

            mLoadedLevels.Clear();
            mServiceLocator.GetService<IInput_Manager>().Clear();
            // mServiceLocator.ResetInput();
            mEntityManager.ClearAll();
        }
        /// <summary>
        /// Allows the player to skip levels using F1-4
        /// </summary>
        /// <param name="_source">Event Source</param>
        /// <param name="_args">Event Arguments</param>
        public void LevelSkip(object _source, InputEvent _args)
        {
            switch (_args.currentKey)
            {
                case Keybindings.Cheat1:
                    LoadLevel("L1", false);
                    break;
                case Keybindings.Cheat2:
                    LoadLevel("L4", false);
                    break;
                case Keybindings.Cheat3:
                    LoadLevel("L6", false);
                    break;
                case Keybindings.Cheat4:
                    LoadLevel("L9", false);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
