using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    public class AI_Manager : IAI_Manager
    {
        #region Data Members
        private IDictionary<int, IBasicAI> mAllAI;
        private IEntity_Manager mEntityManager;
        private AITarget mTarget;
        #endregion

        #region Constructor
        public AI_Manager(IEntity_Manager _em)
        {
            mEntityManager = _em;
            mAllAI = new Dictionary<int, IBasicAI>();
        }
        #endregion

        #region Methods
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
        }
        #endregion
    }
}
