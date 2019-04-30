using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Abstracts
{
    /// <summary>
    /// Abstract Class for Level descriptors to inherit from
    /// </summary>
    public abstract class Level : ILevel
    {
        #region Data Members
        /// Level Identifier
        protected string lvlID;
        /// Background Texture path
        protected string bg;
        /// IEntity variable for object creation process
        protected IEntity createdEntity;
        /// All objects in this level
        protected IDictionary<int, IEntity> Removables;
        /// First time the level has run
        protected bool firstRun = true;

        /// Entity Manager Reference
        protected IEntity_Manager mEntityManager;
        /// Scene Manager Reference
        protected IScene_Manager mSceneManager;
        /// Background Manager Reference
        protected IBackground_Manager mBackgroundManager;
        /// Service Locator 
        protected IServiceLocator mServiceLocator; 
        #endregion

        #region Accessors
        /// Background Texture Path
        public string Background
        {
            get { return bg; }
        }
        /// Level Identifier
        public string LvlID
        {
            get { return lvlID; }
        }
        /// First Run control
        public bool FirstRun
        {
            set { firstRun = value; }
        }
        #endregion

        #region Constructor
        public Level()
        {
            Removables = new Dictionary<int, IEntity>();
            lvlID = GetType().Name.ToString();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialises the level, sets up Manager references
        /// Then Resumes the level if not already run
        /// </summary>
        /// <param name="_sl"> Reference to the Service Locator </param>
        public virtual void Initialise(IServiceLocator _sl)
        {
            mServiceLocator = _sl;
            mEntityManager = mServiceLocator.GetService<IEntity_Manager>();
            mSceneManager = mServiceLocator.GetService<IScene_Manager>();
            mBackgroundManager = mServiceLocator.GetService<IBackground_Manager>();

            if (!firstRun)
                Resume();
        }
        /// <summary>
        /// Initialises the level, but overrides the Resume
        /// </summary>
        /// <param name="_sl">Reference to the Service Locator</param>
        /// <param name="_overrideResume">Boolean to override the resume</param>
        public virtual void Initialise(IServiceLocator _sl, bool _overrideResume)
        {
            firstRun = _overrideResume;
            Initialise(_sl);
        }
        /// <summary>
        /// Suspends the level by calling the suspend method of each Entity in the Removables list
        /// </summary>
        public virtual void Suspend()
        {
            foreach (KeyValuePair<int, IEntity> _keypair in Removables)
            {
                _keypair.Value.Suspend();
            }
        }
        /// <summary>
        /// Resumes the level by calling the resume method of each Entity in the Removables list
        /// </summary>
        public virtual void Resume()
        {
            foreach (KeyValuePair<int, IEntity> _keypair in Removables)
            {
                _keypair.Value.Resume();
                // Cast all entities to IDoor and resubscribe them to the Input Manager when resuming a level
                IDoor asInterface = _keypair.Value as IDoor;
                if (asInterface != null)
                    asInterface.Subscribe();
            }
        }
        #endregion
    }
}
