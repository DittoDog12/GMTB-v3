using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;

namespace GMTB.Entities.AI
{
    public class BasicAI : RectangleShape, IBasicAI
    {
        #region Data Members
        protected IMind mMind;
        protected AITarget mTarget;

        public AITarget Target
        {
            get { return mTarget; }
        }
        #endregion

        #region Constructor
        public BasicAI()
        {
           
        }
        #endregion

        #region Methods
        public override void Update(GameTime _gameTime)
        {
            mMind.Update(_gameTime);
            base.Update(_gameTime);
        }
        public virtual void LocateTarget(AITarget _target)
        {
            mTarget = _target;
        }
        #endregion
    }
}
