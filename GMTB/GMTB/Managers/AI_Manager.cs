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
    /// AI Manager
    /// Locates AI Targets and informs the AIs of the targets existance
    /// </summary>
    public class AI_Manager : IAI_Manager
    {
        #region Data Members
        /// List of all AIs
        private IDictionary<int, IBasicAI> mAllAI;
        /// Reference to the Entity Manager
        private IEntity_Manager mEntityManager;
        /// Reference to the AI Target
        private AITarget mTarget;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_em">Reference to the Entity Manager</param>
        public AI_Manager(IEntity_Manager _em)
        {
            mEntityManager = _em;
            mAllAI = new Dictionary<int, IBasicAI>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main Update Loop
        /// Finds all the AIs from the Entity Managers master list and informs them of the current AT target
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Update(GameTime _gameTime)
        {
            mAllAI.Clear();
            foreach (KeyValuePair<int, IEntity> _keyPair in mEntityManager.AllEntities)
            {
                var asInterface = _keyPair.Value as IBasicAI;
                if (asInterface != null)
                    mAllAI.Add(_keyPair.Key, asInterface);

                var _target = _keyPair.Value as AITarget;
                if (_target != null)
                    mTarget = _target;
               
            }
            foreach (KeyValuePair<int, IBasicAI> _keyPair in mAllAI)
            {
                if (mTarget != null)
                    _keyPair.Value.LocateTarget(mTarget);
            }
            mTarget = null;
        }
        #endregion
    }
}
