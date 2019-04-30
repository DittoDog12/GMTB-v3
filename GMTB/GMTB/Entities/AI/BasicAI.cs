﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;

namespace GMTB.Entities.AI
{
    public class BasicAI : AnimatingEntity, IBasicAI, IisTrigger
    {
        #region Data Members
        protected IAIMind mMind;
        protected AITarget mTarget;
        #endregion

        #region Accessors
        public IServiceLocator ServiceLocator
        {
            get { return mServiceLocator; }
        }
        public AITarget Target
        {
            get { return mTarget; }
        }
        public bool Moving
        {
            set { mMoving = value; }
        }
        #endregion

        #region Constructor
        public BasicAI()
        {
           
        }
        #endregion

        #region Methods
        public override void setVars(int _uid, IServiceLocator _sl)
        {
            base.setVars(_uid, _sl);
            mMind.Initialize();
        }
        public override void Update(GameTime _gameTime)
        {
            mMind.Update(_gameTime);
            base.Update(_gameTime);
            mTarget = null;
        }
        public virtual void LocateTarget(AITarget _target)
        {
            mTarget = _target;
        }
        public virtual void OnTrigger(ICollidable _obj)
        {
            mMind.OnTrigger(_obj);
        }
        #endregion
    }
}
