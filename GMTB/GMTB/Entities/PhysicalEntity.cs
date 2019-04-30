using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.CollisionSystem;

namespace GMTB.Entities
{
    /// <summary>
    /// Main physical Entity public class, everything that has a physical presence in the world inherits from this public class 
    /// </summary>
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

        #region Accessors
        public string Texturename
        {
            get { return mTexturename; }
        }
        public Texture2D Texture
        {
            get { return mTexture; }
            set { mTexture = value; }
        }
        public Vector2 Position
        {
            get { return mPosition; }
        }
        public Vector2 Acceleration
        {
            set { mAcceleration = value; }
        }

        #endregion

        #region Constructor
        public PhysicalEntity()
        {
            mGravity = new Vector2(0, 1);
        }
        #endregion

        #region Methods
        public override void ConfigureInput()
        {
            base.ConfigureInput();
            //mInputManager.Sub_Space(OnSpaceInput);
        }
        /// <summary>
        /// Set Texture path
        /// </summary>
        /// <param name="_path"> Texture Path</param>
        public virtual void setVars(string _path, IContent_Manager _cm)
        {
            mTexturename = _path;
            mContentManager = _cm;
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
        public virtual void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mTexture != null && mActive)
                _spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
        }
        public virtual void Collision(ICollidable _obj)
        {

        }

        protected virtual void UpdatePhysics()
        {
            // Scale velocity with Damp
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
        public void ApplyForce(Vector2 _force)
        {
            // Calculation for acceleration using force
            mAcceleration += _force * mInverseMass;
        }

        private void OnSpaceInput(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump)
            {
                ToggleGravity();
            }
        }

        public void ToggleGravity()
        {
            if (mGravity == new Vector2(0, 1))
                mGravity = new Vector2(0, 0);
            else
                mGravity = new Vector2(0, 1);
        }
        #endregion
    }
}
