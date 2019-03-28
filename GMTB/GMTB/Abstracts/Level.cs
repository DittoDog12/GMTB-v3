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
        protected List<IEntity> Removables;
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
            Removables = new List<IEntity>();
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
    }
        #endregion
    }
}
