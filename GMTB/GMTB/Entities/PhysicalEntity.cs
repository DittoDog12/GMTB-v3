using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Entities
{
    public enum FacingDirection
    {
        Right,
        Left
    }
    /// <summary>
    /// Main physical Entity public class, everything that has a physical presence in the world inherits from this public class 
    /// </summary>
    public class PhysicalEntity : Entity, IPhysicalEntity
    {
        #region Data Members
        /// Reference to Content Manager
        protected IContent_Manager mContentManager;
        //--Movement 
        /// Entity Speed
        protected float mSpeed;
        /// Current Velocity
        protected Vector2 mVelocity;
        /// Current Acceleration
        protected Vector2 mAcceleration;

        // Entity Physic Modifier Properties
        protected float mRestitution = 0.6f;
        protected float mDamping = 0.5f;
        protected float mInverseMass = 1f;
        protected Vector2 mGravity = new Vector2(0, 0);

        /// Hold the facing direction for the animatior to load the correct spritesheet
        protected FacingDirection mCurrDir;

        //--Texture
        /// Texture
        protected Texture2D mTexture;
        /// Texture Path
        protected string mTexturename;
        /// Additional storage variable for texture height
        protected int mCurrentTextureHeight;
        /// Additional storage variable for texture height
        protected int mCurrentTextureWidth;

        //--Position
        /// Current Position
        protected Vector2 mPosition;
        /// Default Position
        protected Vector2 mDefaultPos;
        /// Origin point, for rotation
        protected Vector2 mOrigin;
        /// Current Rotation
        protected float mRotation;
        #endregion

        #region Accessors
        /// Path to texture
        public string Texturename
        {
            get { return mTexturename; }
            set { mTexturename = value; }
        }
        /// Current Texture
        public Texture2D Texture
        {
            get { return mTexture; }
            set { mTexture = value; }
        }
        /// Current Texture Height
        public int CurrentTextureHeight
        {
            get { return mCurrentTextureHeight; }
        }
        /// Current Texture Width
        public int CurrentTextureWidth
        {
            get { return mCurrentTextureWidth; }
        }
        /// Current Position
        public Vector2 Position
        {
            get { return mPosition; }
        }
        /// Current Acceleration
        public Vector2 Acceleration
        {
            set { mAcceleration = value; }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public PhysicalEntity()
        {
            mGravity = new Vector2(0, 3);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Configure Input
        /// </summary>
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
            mTexture = mContentManager.ApplyTexture(mTexturename);
            mCurrentTextureHeight = mTexture.Height;
            mCurrentTextureWidth = mTexture.Width;
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
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            UpdatePhysics();
            if (mVelocity.X > 0)
                mCurrDir = FacingDirection.Right;
            else if (mVelocity.X < 0)
                mCurrDir = FacingDirection.Left;
            //mPosition += mVelocity;
            mVelocity = Vector2.Zero;
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public virtual void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mTexture != null && mActive)
                _spriteBatch.Draw(mTexture, mPosition, Color.AntiqueWhite);
        }
        /// <summary>
        /// Non Physical Collision response
        /// </summary>
        /// <param name="_obj">Object Collided with</param>
        public virtual void Collision(ICollidable _obj)
        {

        }
        /// <summary>
        /// Main Physics Update loop
        /// </summary>
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
        /// <summary>
        /// Apply phyisical Impluse
        /// </summary>
        /// <param name="_closingVelocity">Closing Velocity between this and the other object</param>
        public void ApplyImpulse(Vector2 _closingVelocity, bool _isFloorOrWall)
        {
            // Provide a closing velocity to the entity when a collision occurs
            mVelocity += _closingVelocity * mRestitution;

            if (_isFloorOrWall)
            {
                //mVelocity = Vector2.Zero;
                mAcceleration = Vector2.Zero;
            }

        }
        /// <summary>
        /// Apply a specified force to the Acceleration
        /// </summary>
        /// <param name="_force">New Force to apply</param>
        public void ApplyForce(Vector2 _force)
        {
            // Calculation for acceleration using force
            mAcceleration += _force * mInverseMass;
        }
        /// <summary>
        /// Space input toggle
        /// Currently used for testing gravity
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        private void OnSpaceInput(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump)
            {
                ToggleGravity();
            }
        }
        /// <summary>
        /// Toggle gravity on and off
        /// USed for testing
        /// </summary>
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
