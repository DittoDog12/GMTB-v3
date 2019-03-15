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
        public abstract void Initialise(IScene_Manager _sm, IEntity_Manager _em, IBackground_Manager _bm);
        #endregion
    }
}
