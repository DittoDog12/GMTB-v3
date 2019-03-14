using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;
using GMTB.InputSystem;

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
        
        
        
        #endregion

        #region Accessors
        public int UID
        {
            get { return mUID; }
        }
        
        #endregion

        #region Constructor
        public Entity()
        {
            //mOrigin = new Vector2((mPosition.X + (mTexture.Width / 2)), (mPosition.Y + (mTexture.Height / 2)));
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set UID
        /// </summary>
        /// <param name="_uid"> Unique ID </param>
        public virtual void setVars(int _uid, )
        {
            mUID = _uid;
            
        }
        
        
        /// <summary>
        /// Method to configure if an entity requires input detection
        /// Override and specify which events to listen for.
        /// </summary>
        /// <param name="im"> Input Manager </param>
        public virtual void ConfigureInput(IInput_Manager im)
        {
            mInputManager = im;
        }
        public virtual void Update(GameTime _gameTime)
        {

        }

        
        
        #endregion
    }
}
