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
        protected IContent_Manager mContentManager;
        
        //--Movement
        protected float mSpeed;    
        protected Vector2 mVelocity;

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;

        //--Position
        protected Vector2 mPosition;
        protected Vector2 mDefaultPos;
        protected Vector2 mOrigin;
        protected float mRotation;
        #endregion

        #region Accessors
        public int UID
        {
            get { return mUID; }
        }
        public string Texturename
        {
            get { return mTexturename; }
        }
        public Texture2D Texture
        {
            set { mTexture = value; }
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
        public virtual void setVars(int _uid, IContent_Manager cm)
        {
            mUID = _uid;
            mContentManager = cm;
        }
        /// <summary>
        /// Set Texture path
        /// </summary>
        /// <param name="_path"> Texture Path</param>
        public virtual void setVars(string _path)
        {
            mTexturename = _path;
        }
        /// <summary>
        /// Force change position
        /// </summary>
        /// <param name="_pos"> Vector2 new position </param>
        public virtual void setPos(Vector2 _pos)
        {
            mPosition = _pos;
        }
        /// <summary>
        /// Set Default Position, also calls setPos
        /// </summary>
        /// <param name="_pos"> Vector2 default position</param>
        public virtual void setDefaultPos(Vector2 _pos)
        {
            setPos(_pos);
            mDefaultPos = _pos;
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

        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
        }
        public virtual void Collision()
        {

        }
        #endregion
    }
}
