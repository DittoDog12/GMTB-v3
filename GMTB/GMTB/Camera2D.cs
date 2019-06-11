using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Using http://www.paradeofrain.com/tutorials/xna-camera-2d/
// Using https://stackoverflow.com/questions/712296/xna-2d-camera-engine-that-follows-sprite

namespace GMTB
{
    /// <summary>
    /// 2D Platformer Camera that follows the player
    /// </summary>
    public class Camera2D
    {
        #region Data Members
        /// Current Position
        private Vector2 mPosition;
        /// Current Zoom
        protected float mZoom;
        /// Current Rotation
        protected float mRotatation;
        /// Transform Matrix
        public Matrix mTransform;
        /// Current Velocity
        public Vector2 mVelocity;
        /// Transform Speed
        public float mSpeed = 2.5f;

        /// Reference to the Screen Height
        private int ScreenHeight;
        /// Reference to the Screen Width
        private int ScreenWidth;
        /// Reference to the Viewport Height
        private int mViewPortHeight;
        /// Reference to the Viewport Width
        private int mViewPortWidth;

        // Follow Player Varaibles, Based on AI system
        //private Vector2 mDistanceToDest;
        /// Reference to the Player
        private IPlayer mPlayer;
        /// Reference to the Player Position
        private Vector2 mPlayerPos;
        /// Reference to the Service Locator
        private IServiceLocator mServiceLocator;

        // Part of Broken Ideas
        //private float mSpeedModifier = 7.5f;
        //private bool mMove = true;
        #endregion

        #region Accessors
        /// Accessor for current Center Position
        public Vector2 Position
        {
            get { return mPosition; }
            set { mPosition = value; }
        }
        /// Accessor for current top left Position
        public Vector2 TLPosition
        {
            get { return new Vector2(mPosition.X - mViewPortHeight / 2, mPosition.Y - mViewPortWidth / 2); }
        }
        /// <summary>
        /// Accessor for current zoom
        /// Does not allow zoom to go less than 0.1
        /// </summary>
        public float Zoom
        {
            get { return mZoom; }
            set
            {
                mZoom = value; if (mZoom < 0.1f)
                    mZoom = 0.1f;
            }
        }
        /// Accessor for current rotation
        public float Rotation
        {
            get { return mRotatation; }
            set { mRotatation = value; }
        }
        public int ViewPortHeight
        {
            get { return mViewPortHeight; }
        }
        public int ViewPortWidth
        {
            get { return mViewPortWidth; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="sh">Screen Height</param>
        /// <param name="sw">Screen Width</param>
        public Camera2D(int sh, int sw)
        {
            ScreenHeight = sh;
            ScreenWidth = sw;
            mZoom = 1f;
            mRotatation = 0.0f;
            mPosition = Vector2.Zero;

            // Reveal self to the Global
            Global.Camera = this;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Initialize Routine
        /// </summary>
        /// <param name="_sl">reference to the Service Locator</param>
        public void Intialize(IServiceLocator _sl)
        {
            mServiceLocator = _sl;

        }
        //public void Move(Vector2 vector)
        //{
        //    if (vector.X > 0)
        //        vector.X -= mSpeedModifier;
        //    if (vector.X < 0)
        //        vector.X += mSpeedModifier;
        //    if (mMove)
        //        mPosition += vector;
        //    mMove = true;
        //}
        //public void MoveControl(bool move)
        //{
        //    mMove = move;
        //}
        /// <summary>
        /// Specify an X coordinate
        /// </summary>
        /// <param name="x">New X coordinate</param>
        public void UpdateX(float x)
        {
            mPosition.X = x;
        }
        /// <summary>
        /// Specify a Y coordinate
        /// </summary>
        /// <param name="y">New Y coordinate</param>
        public void UpdateY(float y)
        {
            mPosition.Y = y;
        }
        /// <summary>
        /// Calculate the transform matrix
        /// </summary>
        /// <param name="graphicsDevice">Reference to the Monogame Graphics Device</param>
        /// <returns>Transformation Matrix</returns>
        public Matrix GetTransform(GraphicsDevice graphicsDevice)
        {
            mTransform = Matrix.CreateTranslation(new Vector3(-mPosition.X, -mPosition.Y, 0)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(new Vector3(mZoom, mZoom, 1)) *
                Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, graphicsDevice.Viewport.Height * 0.5f, 0));
            //Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.5f, 150, 0));

            mViewPortWidth = graphicsDevice.Viewport.Width;
            mViewPortHeight = graphicsDevice.Viewport.Height;
            return mTransform;
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Update(GameTime _gameTime)
        {
            // Use the service Locator to access the Entity Manager to identify the player via casting
            // Also check if the player is active
            foreach (KeyValuePair<int, IEntity> _keyPair in mServiceLocator.GetService<IEntity_Manager>().AllEntities)
            {
                IPlayer asInterface = _keyPair.Value as IPlayer;
                if (asInterface != null)
                    if (_keyPair.Value.GetState())
                        mPlayer = asInterface;
            }

            mPlayerPos = mPlayer.GetPos();
            var delta = (float)_gameTime.ElapsedGameTime.TotalSeconds;

            mPosition.X += (mPlayerPos.X - mPosition.X) * mSpeed * delta;
            mPosition.Y += (mPlayerPos.Y - mPosition.Y) * mSpeed * delta;

            // Based on AI tracking system - Kinda Janky also glitches out
            //mDistanceToDest = mPlayerPos - mPosition;
            //mDistanceToDest.Normalize();
            //mVelocity = mDistanceToDest * mSpeed;
            //if (mVelocity.X == null)
            //    mVelocity.X = 0;
            //if (mVelocity.Y == null)
            //    mVelocity.Y = 0;

            //mPosition += mVelocity;

            Console.WriteLine("Camera Position: " + mPosition);
            Console.WriteLine("Camera Top Left Position: " + TLPosition);
        }
        #endregion
    }
}
