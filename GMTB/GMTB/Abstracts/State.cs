using GMTB.CollisionSystem;
using GMTB.Entities.AI;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Abstracts
{
    /// <summary>
    /// Abstract Class for Behaviour States to inherit from
    /// </summary>
    public abstract class State : IState
    {
        #region Data Members
        /// Reference to the AI Mind
        protected IAIMind mMind;
        /// Reference to the Player Mind
        protected IPlayerMind mPMind;
        /// Path Queue
        protected Queue<Point> mPath;
        /// Vector position of current Destination
        protected Vector2 mCurrentDest;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for AI minds
        /// </summary>
        /// <param name="_mind">Reference to the AI Mind</param>
        public State(IAIMind _mind)
        {
            mMind = _mind;
        }
        /// <summary>
        /// Constructor for Player Minds
        /// </summary>
        /// <param name="_mind">Reference to the Player Mind</param>
        public State(IPlayerMind _mind)
        {
            mPMind = _mind;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Main State Initializer
        /// </summary>
        public virtual void Initialize() { }
        /// <summary>
        /// States main Update loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public abstract void Update(GameTime _gameTime);
        /// <summary>
        /// States Draw Update loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public abstract void Draw(SpriteBatch _spriteBatch, GameTime _gameTime);
        /// <summary>
        /// Change State method
        /// </summary>
        /// <param name="_nextState">String with new state to trigger</param>
        public virtual void ChangeState(string _nextState)
        {
            if (mPMind == null)
                mMind.ChangeState(_nextState);
            else if (mMind == null)
                mPMind.ChangeState(_nextState);
        }
        /// <summary>
        /// Optional Method for reactivating a state after change
        /// </summary>
        public virtual void Reactivate(){ }
        /// <summary>
        /// Virtual Method for Collision reaction
        /// </summary>
        /// <param name="_obj">Reference to the other object collided with</param>
        public virtual void Collision(ICollidable _obj) { }
        #endregion
    }

}
