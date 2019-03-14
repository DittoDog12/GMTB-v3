using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace GMTB.Entities.AI
{
    public abstract class Mind : IMind
    {
        #region Data Members
        protected IState mCurrentState;
        protected IDictionary<string, IState> mStates;
        protected IPhysicalEntity mSelf;
        #endregion

        #region Accessors
        public IPhysicalEntity MySelf
        {
            get { return mSelf; }
            set { mSelf = value; }
        }
        #endregion

        #region Constructor
        public Mind(IPhysicalEntity _self)
        {
            mStates = new Dictionary<string, IState>();
            mSelf = _self;
        }
        #endregion

        #region Methods
        public virtual void Update(GameTime _gameTime)
        {
            mCurrentState.Update(_gameTime);
        }
        public virtual void ChangeState(string _newState)
        {
            mCurrentState = mStates[_newState];
        }
        #endregion
    }
}
