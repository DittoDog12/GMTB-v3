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
    /// <summary>
    /// Player Mind
    /// </summary>
    public class PlayerMind : IPlayerMind
    {
        #region Data Members
        /// Reference to the Current State
        protected IState mCurrentState;
        /// Dictionary of all States
        protected IDictionary<string, IState> mStates;
        /// Reference to the player self
        protected IPlayer mSelf;
        /// Reference to the Service Locator
        protected IServiceLocator mServiceLocator;
        /// Moving bool to control animation when returning to walk state from jump state
        protected bool mMoving;
        #endregion

        #region Accessors
        /// Accessor for states to access Player self
        public IPlayer MySelf
        {
            get { return mSelf; }
            set { mSelf = value; }
        }
        /// Accessor for States to access service Locator
        public IServiceLocator ServiceLocator
        {
            get { return mServiceLocator; }
        }
        /// Moving bool to control animation when returning to walk state from jump state
        public bool Moving
        {
            get { return mMoving; }
            set { mMoving = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_self">Reference to the Player self</param>
        /// <param name="_sl">Reference to the Service Locator</param>
        public PlayerMind(IPlayer _self, IServiceLocator _sl)
        {
            mSelf = _self;
            mStates = new Dictionary<string, IState>();
            mServiceLocator = _sl;

            mStates.Add("walk", new Walk(this));
            mStates.Add("jump", new Jump(this));

            mCurrentState = mStates["walk"];

            foreach (KeyValuePair<string, IState> _keypair in mStates)
            {
                _keypair.Value.Initialize();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Non physical Collision response
        /// Passed to the Behaviour states only if the other object is a static object
        /// </summary>
        /// <param name="_otherObj">Other object collided with</param>
        public void Collision(ICollidable _otherObj)
        {
            IStaticObject asInterface = _otherObj as IStaticObject;
            if (asInterface != null)
            {
                mCurrentState.Collision(_otherObj);
            }
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Update(GameTime _gameTime)
        {
            mCurrentState.Update(_gameTime);
        }
        /// <summary>
        /// Change state to specified state
        /// Calls the reactivate mehtod of the new state
        /// </summary>
        /// <param name="_newState">State to change to</param>
        public void ChangeState(string _newState)
        {
            mCurrentState = mStates[_newState];
            mCurrentState.Reactivate();
        }
        /// <summary>
        /// Initialize all states
        /// </summary>
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
