using GMTB.Interfaces;
using GMTB.CollisionSystem;
using GMTB.Pathfinding;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Entities.AI
{
    /// <summary>
    /// Abstract class for AI minds
    /// </summary>
    public abstract class AIMind : IAIMind
    {
        #region Data Members
        /// Current Behaviour State
        protected IState mCurrentState;
        /// Dictionary of Behaviour States
        protected IDictionary<string, IState> mStates;
        /// Reference to Body
        protected IBasicAI mSelf;
        /// Reference to Pathfinder
        protected IPathfinder mPathfinder;
        /// Pathfinder Map
                                     // 0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28  
        protected byte[,] mMap =     {{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 0
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 1
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 2
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 3
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 4
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 5
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}, // 6
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0}, // 7
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 8
                                      { 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 9
                                      { 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1}, // 10
                                      { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1}, // 11
                                      { 1, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 12
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 13
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 14
                                      { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 15
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, // 16
                                      { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}}; // 17
        #endregion

        #region Accessors
        /// Reference to Body
        public IBasicAI MySelf
        {
            get { return mSelf; }
            set { mSelf = value; }
        }
        /// Reference to Pathfinder
        public IPathfinder Pathfinder
        {
            get { return mPathfinder; }
            set { mPathfinder = value; }
        }
        /// Reference to AI Target
        public AITarget Target
        {
            get { return mSelf.Target; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_self">Reference to AI Body</param>
        public AIMind(IBasicAI _self)
        {
            mStates = new Dictionary<string, IState>();
            mSelf = _self;
            mPathfinder = new Pathfinder(Global.ScreenWidth, Global.ScreenHeight, mMap);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Pathfinding map
        /// </summary>
        /// <param name="_map">New Map</param>
        protected void SetMap(byte[,] _map)
        {
            mMap = _map;
        }
        /// <summary>
        /// Initialize Method
        /// Calls initialize for each state
        /// </summary>
        public virtual void Initialize()
        {
            foreach (KeyValuePair<string, IState> _keypair in mStates)
            {
                _keypair.Value.Initialize();
            }

        }
        /// <summary>
        /// Main Update Loop
        /// Calls Update loop on current state
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public virtual void Update(GameTime _gameTime)
        {
            mCurrentState.Update(_gameTime);
        }
        public virtual void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            mCurrentState.Draw(_spriteBatch, _gameTime);
        }
        /// <summary>
        /// Change State Trigger
        /// </summary>
        /// <param name="_newState">New State to switch to</param>
        public virtual void ChangeState(string _newState)
        {
            mCurrentState = mStates[_newState];
            mCurrentState.Reactivate();
        }
        /// <summary>
        /// Trigger Collision 
        /// </summary>
        /// <param name="_obj">Object Collided with</param>
        public virtual void Collision(ICollidable _obj)
        {

        }
        #endregion
    }
}
