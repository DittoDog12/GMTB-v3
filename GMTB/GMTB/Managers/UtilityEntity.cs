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
    /// <summary>
    /// Utility Entity
    /// Utility Entites are entites that need to run in the background but do not warrent using a full manager
    /// </summary>
    public class UtilityEntity : Entity, IUtility_Entity
    {
        #region Data Members
        /// Reference to the Entity Manager
        protected IEntity_Manager mEntityManager;
        /// Reference to the Scene Manager
        protected IScene_Manager mSceneManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public UtilityEntity()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize Routine
        /// </summary>
        public virtual void Initialize()
        {

        }
        /// <summary>
        /// Set core variables
        /// </summary>
        /// <param name="_sl">Reference to Service Locator</param>
        public void setVars(IServiceLocator _sl)
        {
            mEntityManager = _sl.GetService<IEntity_Manager>();
            mSceneManager = _sl.GetService<IScene_Manager>();
        }

        #endregion
    }
}
