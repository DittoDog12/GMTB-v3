using GMTB.Interfaces;
using GMTB.Pathfinding;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GMTB.Entities.AI
{
    public abstract class AIMind : IMind
    {
        #region Data Members
        protected IState mCurrentState;
        protected IDictionary<string, IState> mStates;
        protected IBasicAI mSelf;
        protected IPathfinder mPathfinder;
        protected byte[,] mMap =     {{ 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 0, 0, 0},
                                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 1, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1},
                                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1},
                                    { 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1},
                                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1}};
        #endregion

        #region Accessors
        public IBasicAI MySelf
        {
            get { return mSelf; }
            set { mSelf = value; }
        }
        public IPathfinder Pathfinder
        {
            get { return mPathfinder; }
            set { mPathfinder = value; }
        }
        public AITarget Target
        {
            get { return mSelf.Target; }
        }
        #endregion

        #region Constructor
        public AIMind(IBasicAI _self)
        {
            mStates = new Dictionary<string, IState>();
            mSelf = _self;
            mPathfinder = new Pathfinder(800, 600, mMap);
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
