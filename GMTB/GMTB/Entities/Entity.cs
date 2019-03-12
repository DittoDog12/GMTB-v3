using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

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
            
        }
        #endregion

        #region Methods
        public virtual void setVars(int _uid)
        {
            mUID = _uid;
        }
        public virtual void setVars(string _path)
        {
            mTexturename = _path;
        }
        public virtual void setPos(Vector2 _pos)
        {
            mPosition = _pos;
        }
        public virtual void setDefaultPos(Vector2 _pos)
        {
            setPos(_pos);
            mDefaultPos = _pos;
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
