using GMTB.Entities;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    public class UtilityEntity : Entity, IUtility_Entity
    {
        #region Data Members
        protected IEntity_Manager mEntityManager;
        protected IScene_Manager mSceneManager;
        #endregion

        #region Constructor
        public UtilityEntity()
        {

        }
        #endregion

        #region Methods
        public virtual void Initialize()
        {

        }
        public void setVars(IServiceLocator _sl)
        {
            mEntityManager = _sl.GetService<IEntity_Manager>();
            mSceneManager = _sl.GetService<IScene_Manager>();
        }

        #endregion
    }
}
