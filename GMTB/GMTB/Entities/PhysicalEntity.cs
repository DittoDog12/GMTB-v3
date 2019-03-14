using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Entities
{
    public class PhysicalEntity : Entity, IPhysicalEntity
    {
        #region Data Members
        protected IContent_Manager mContentManager;
        //--Movement
        protected float mSpeed;
        protected Vector2 mVelocity;
        protected Vector2 mAcceleration;

        // Entity Physic Modifier Properties
        protected float mRestitution = 0.6f;
        protected float mDamping = 0.5f;
        protected float mInverseMass = 1f;
        protected Vector2 mGravity = new Vector2(0, 0);

        //--Texture
        protected Texture2D mTexture;
        protected string mTexturename;

        //--Position
        protected Vector2 mPosition;
        protected Vector2 mDefaultPos;
        protected Vector2 mOrigin;
        protected float mRotation;
        #endregion

        public string Texturename
        {
            get { return mTexturename; }
        }
        public Texture2D Texture
        {
            set { mTexture = value; }
        }

        public PhysicalEntity()
        {

        }

        /// <summary>
        /// Set Texture path
        /// </summary>
        /// <param name="_path"> Texture Path</param>
        public virtual void setVars(string _path, IContent_Manager cm)
        {
            mTexturename = _path;
            mContentManager = cm;
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

        public override void Update(GameTime _gameTime)
        {
            UpdatePhysics();
            //mPosition += mVelocity;
            mVelocity = Vector2.Zero;
        }
        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
        }
        public virtual void Collision()
        {

        }

        private void UpdatePhysics()
        {
            // Scale velocity with Damping
            mVelocity *= mDamping;
            // Apply acceleration
            mVelocity += mAcceleration;
            // Update position
            mPosition += mVelocity;
            // Reset Acceleration
            mAcceleration = mGravity;
        }

        public void ApplyImpulse(Vector2 _closingVelocity)
        {
            // Provide a closing velocity to the entity when a collision occurs
            mVelocity += _closingVelocity * mRestitution;
        }
    }
}
