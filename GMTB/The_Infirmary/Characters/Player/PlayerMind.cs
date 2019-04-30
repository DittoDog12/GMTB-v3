using GMTB;
using GMTB.CollisionSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    public class PlayerMind : IPlayerMind
    {
        #region Data Members
        protected IState mCurrentState;
        protected IDictionary<string, IState> mStates;
        protected IPlayer mSelf;
        protected IServiceLocator mServiceLocator;
        #endregion

        #region Accessors
        public IPlayer MySelf
        {
            get { return mSelf; }
            set { mSelf = value; }
        }
        #endregion

        #region Constructor
        public PlayerMind(IPlayer _self, IServiceLocator _sl)
        {
            mSelf = _self;
            mStates = new Dictionary<string, IState>();
            mServiceLocator = _sl;
        }
        #endregion

        #region Methods
        public void Collision(ICollidable _otherObj)
        {
            IStaticObject asInterface = _otherObj as IStaticObject;
            if (asInterface != null)
            {
                mCurrentState.Collision(_otherObj);
            }
        }

        public void Update(GameTime _gameTime)
        {
            mCurrentState.Update(_gameTime);
        }
        
        public void ChangeState(string _newState)
        {
            mCurrentState = mStates[_newState];
        }

        public void Initialize()
        {
            foreach (KeyValuePair<string, IState> _keypair in mStates)
            {
                _keypair.Value.Initialize();
            }
        }
        #endregion
    }
}
