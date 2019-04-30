using GMTB.CollisionSystem;
using GMTB.Entities.AI;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Abstracts
{
    public abstract class State : IState
    {
        #region Data Members
        protected IAIMind mMind;
        protected IPlayerMind mPMind;
        protected Queue<Point> mPath;
        protected Vector2 mCurrentDest;
        #endregion

        #region Constructor
        public State(IAIMind _mind)
        {
            mMind = _mind;
        }
        public State(IPlayerMind _mind)
        {
            mPMind = _mind;
        }
        #endregion

        #region Methods
        public virtual void Initialize() { }
        public abstract void Update(GameTime _gameTime);
        public virtual void ChangeState(string _nextState)
        {
            if (mPMind == null)
                mMind.ChangeState(_nextState);
            else if (mMind == null)
                mPMind.ChangeState(_nextState);
        }
        public virtual void Reactivate(){ }
        public virtual void Collision(ICollidable _obj) { }
        #endregion
    }

}
