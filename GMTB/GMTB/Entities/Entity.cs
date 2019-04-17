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
    /// Main Entity public class, everything that has a physical presence in the world inherits from this public class 
    /// </summary>
    /// 
    public abstract class Entity : IEntity
    {
        #region Data Members
        //--Key Variables
        protected int mUID;
        protected IInput_Manager mInputManager;
        private IEntity_Manager mEntityManger;
        protected IServiceLocator mServiceLocator;
        protected bool mActive;
        #endregion

        #region Accessors
        public int UID
        {
            get { return mUID; }
        }
        public bool Active
        {
            get { return mActive; }
            set { mActive = value; }
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
        /// Method to configure if an entity requires input detection
        /// Override and specify which events to listen for.
        /// </summary>
        /// <param name="im"> Input Manager </param>
        public virtual void ConfigureInput()
        {
            mInputManager = mServiceLocator.GetService<IInput_Manager>();
        }
        public virtual void Update(GameTime _gameTime)
        {

        }
        public virtual void Destroy()
        {
            mEntityManger.DestroyEntity(UID);
        }
        
        
        #endregion
    }
}
