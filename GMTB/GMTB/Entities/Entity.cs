using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;
using GMTB.InputSystem;
using GMTB.Managers;

namespace GMTB.Entities
{
    /// <summary>
    /// Main Entity public class, everything that exists inherits from this public class 
    /// </summary>
    public abstract class Entity : IEntity
    {
        #region Data Members
        //--Key Variables
        /// Entities Unique Identifier
        protected int mUID;
        /// Reference to Input Manager
        protected IInput_Manager mInputManager;
        /// Reference to Entity Manager
        private IEntity_Manager mEntityManger;
        /// Reference to Service Locator
        protected IServiceLocator mServiceLocator;
        /// Active Overrider, allows entities to be paused while not needed without removing them
        protected bool mActive;
        /// Unique name for idenfication
        protected string mUName;
       
        #endregion

        #region Accessors
        /// Unique Identifier Accessor
        public int UID
        {
            get { return mUID; }
        }
        /// Unique Name Accessor
        public string Name
        {
            get { return mUName; }
        }
        #endregion

        #region Constructor
        public Entity()
        {
            //mOrigin = new Vector2((mPosition.X + (mTexture.Width / 2)), (mPosition.Y + (mTexture.Height / 2)));
            mActive = true;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set UID
        /// </summary>
        /// <param name="_uid"> Unique ID </param>
        public virtual void setVars(int _uid, IServiceLocator _sl)
        {
            mUID = _uid;
            mServiceLocator = _sl;
            mEntityManger = mServiceLocator.GetService<IEntity_Manager>();
        }
        /// <summary>
        /// Set Unique name
        /// </summary>
        /// <param name="_name">Entities name</param>
        public virtual void setVars(string _name) 
        {
            mUName = _name;
        }
        
        /// <summary>
        /// Method to configure if an entity requires input detection.
        /// Uses Service Locator to access Input Manager.
        /// Override and specify which events to listen for.
        /// </summary>
        public virtual void ConfigureInput()
        {
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public virtual void Update(GameTime _gameTime)
        {

        }
        /// <summary>
        /// Destroy Self
        /// </summary>
        public virtual void Destroy()
        {
            mEntityManger.DestroyEntity(UID);
        }
        /// <summary>
        /// Cleans up the entitity before destruction
        /// </summary>
        public virtual void Cleanup()
        {

        }
        /// <summary>
        /// Suspend self when not needed
        /// </summary>
        public virtual void Suspend()
        {
            mActive = false;
        }
        /// <summary>
        /// Resume self when needed again
        /// </summary>
        public virtual void Resume()
        {
            mActive = true;
        }
        /// <summary>
        /// Get the current suspension state
        /// </summary>
        /// <returns>Current Suspension state</returns>
        public virtual bool GetState()
        {
            return mActive;
        }
        #endregion
    }
}
