using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Abstracts
{
    public abstract class Level : ILevel
    {
        #region Data Members
        protected string lvlID;
        protected string bg;
        protected IEntity createdEntity;
        protected IDictionary<int, IEntity> Removables;
        protected bool firstRun = true;

        protected IEntity_Manager mEntityManager;
        protected IScene_Manager mSceneManager;
        protected IBackground_Manager mBackgroundManager;
        protected IServiceLocator mServiceLocator;
        #endregion

        #region Accessors
        public string Background
        {
            get { return bg; }
        }
        public string LvlID
        {
            get { return lvlID; }
        }
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
        public virtual void Initialise(IServiceLocator _sl)
        {
            mServiceLocator = _sl;
            mEntityManager = mServiceLocator.GetService<IEntity_Manager>();
            mSceneManager = mServiceLocator.GetService<IScene_Manager>();
            mBackgroundManager = mServiceLocator.GetService<IBackground_Manager>();

            if (!firstRun)
                Resume();
        }
        public virtual void Initialise(IServiceLocator _sl, bool _overrideResume)
        {
            firstRun = _overrideResume;
            Initialise(_sl);
        }
        public virtual void Suspend()
        {
            foreach (KeyValuePair<int, IEntity> _keypair in Removables)
            {
                _keypair.Value.Active = false;
            }
        }
        public virtual void Resume()
        {
            foreach (KeyValuePair<int, IEntity> _keypair in Removables)
            {
                _keypair.Value.Active = true;
                // Cast all entities to IDoor and resubscribe them to the Input Manager when resuming a level
                IDoor asInterface = _keypair.Value as IDoor;
                if (asInterface != null)
                    asInterface.Subscribe();
            }
        }
        #endregion
    }
}
