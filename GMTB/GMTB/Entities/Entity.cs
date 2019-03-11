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
        protected Vector2 mDefaultPos;
        //--Movement
        protected float mSpeed;
        protected Vector2 mPosition;
        protected Vector2 mVelocity;
        protected Vector2 mPrevPos;

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;
        #endregion

        #region Constructor
        public Entity()
        {
            
        }
        #endregion

        #region Methods
        public virtual void setVars(int uid)
        {
            mUID = uid;
        }
        public virtual void setVars(int uid, string path)
        {
            mTexturename = path;
            setVars(uid);
        }
        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
        }
        public virtual void Collision()
        {

        }
        #endregion
    }
}
