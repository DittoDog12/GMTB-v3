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
        protected IMind mMind;

        protected Queue<Point> mPath;
        protected Vector2 mCurrentDest;
        #endregion

        #region Constructor
        public State(IMind _mind)
        {
            mMind = _mind;
        }
        #endregion

        #region Methods
        public abstract void Update(GameTime _gameTime);
        public virtual void ChangeState(string _nextState)
        {
            mMind.ChangeState(_nextState);
        }
        #endregion
    }

}
