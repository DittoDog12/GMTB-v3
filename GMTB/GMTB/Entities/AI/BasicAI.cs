﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Entities.AI
{
    /// <summary>
    /// Class for simple AI
    /// </summary>
    public class BasicAI : AnimatingEntity, IBasicAI
    {
        #region Data Members
        /// Reference to Mind
        protected IAIMind mMind;
        /// Reference to Target
        protected AITarget mTarget;
        /// Target Destination
        protected Vector2 mDestination;
        #endregion

        #region Accessors
        /// Reference to Service locator (For minds and Behaviours)
        public IServiceLocator ServiceLocator
        {
            get { return mServiceLocator; }
        }
        /// Reference to Target (For minds and Behaviours)
        public AITarget Target
        {
            get { return mTarget; }
        }
        /// Lets Behaviours change Texture
        string IBasicAI.Texturename
        {
            set { mTexturename = value; }
        }
        /// Lets behaviours see current direction
        public FacingDirection CurrentDirection
        {
            get { return mCurrDir; }
        }
        /// Let's Behaviours set a target destination
        public Vector2 Destination
        {
            set { mDestination = value; }
        }
        /// Let's behaviours set active state
        public bool Active
        {
            set { mActive = value; }
        }
        #endregion

        #region Constructor
        public BasicAI()
        {
           
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Variable Override
        /// Initializes the mind
        /// </summary>
        /// <param name="_uid">Entitiy Unique Identifier</param>
        /// <param name="_sl">Reference to Service Locator</param>
        public override void setVars(int _uid, IServiceLocator _sl)
        {
            base.setVars(_uid, _sl);
            mMind.Initialize();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.Update(_gameTime);
            base.Update(_gameTime);
            mTarget = null;
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            mMind.Draw(_spriteBatch, _gameTime);
            base.Draw(_spriteBatch, _gameTime);

            if (mTexture.Name != mTexturename)
                mTexture = mContentManager.ApplyTexture(mTexturename);
        }
        /// <summary>
        /// Locate the specified AI target
        /// </summary>
        /// <param name="_target">Target to locate</param>
        public virtual void LocateTarget(AITarget _target)
        {
            mTarget = _target;
        }
        /// <summary>
        /// Trigger Collision 
        /// Passes to Mind
        /// </summary>
        /// <param name="_obj">Other object collided with</param>
        public override void Collision(ICollidable _obj)
        {
            mMind.Collision(_obj);
        }
        #endregion
    }
}
