using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.CollisionSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Entities
{
    /// <summary>
    /// Animating Entity
    /// </summary>
    public class AnimatingEntity : RectangleShape, IAnimation
    {
        #region Data Members
        // Sets frame information for the Draw Method to read the spritesheets
        /// Number of Frames in SpriteSheet
        protected int mFrames;
        /// Current Frame
        protected int mCurrentFrame;
        /// Number of Rows in SpriteSheet
        protected int mRows;
        /// Number of Collumns in SpiteSheet
        protected int mColumns;

        // Row and Column sizes for Hitbox
        /// Width of AABB Hitbox
        private int mWidth;
        /// Height of AABB Hitbox
        private int mHeight;

        // Timers for frame transistions
        /// Timer to change frame
        protected float mTimer;
        /// Interval to change frame at
        protected float mInterval;

        /// Boolean to control if the entity is moving or not
        protected bool mMoving;
        #endregion

        #region Accessors
        /// lets behaviours control animation frame
        public int Frame
        {
            get { return mCurrentFrame; }
            set { mCurrentFrame = value; }
        }
        /// Allows states to change amount of frames
        public int Frames
        {
            set { mFrames = value; }
        }
        /// Allows States to change number of columns
        public int Columns
        {
            set { mColumns = value; }
        }
        /// Allows states to tell the physical entity if it's moving or not
        public bool Moving
        {
            get { return mMoving; }
            set { mMoving = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// Sets default SpriteSheet settings
        /// 4 Frames, 1 Row, 4 Collumns
        /// </summary>
        public AnimatingEntity()
        {
            // Initialise Frame information
            mFrames = 4;
            mCurrentFrame = 0;
            mRows = 1;
            mColumns = 4;

            // Initialise timer
            mTimer = 0;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Set Default Position
        /// Override SAT shape with alternate texture size
        /// Override hitbox with alternate texture size values
        /// </summary>
        /// <param name="_pos">Vector Coordinates of default position</param>
        public override void setDefaultPos(Vector2 _pos)
        {
            base.setDefaultPos(_pos);
            mWidth = mTexture.Width / mColumns;
            mHeight = mTexture.Height / mRows;
            mHitbox = new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight);
            mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight);
        }
        /// <summary>
        /// Reset Frame when reached end of animation cycle
        /// </summary>
        public virtual void FrameReset()
        {
            // Used to reset the animation when it reaches the end of the spritesheet
            if (mCurrentFrame == mFrames)
               mCurrentFrame = 0;
        }
        /// <summary>
        /// Incremente frame based on animation timer
        /// </summary>
        /// <param name="_gameTime"></param>
        public virtual void IncrementFrame(GameTime _gameTime)
        {
            mTimer += (float)_gameTime.ElapsedGameTime.TotalMilliseconds;
            if (mTimer >= mInterval)
            {
                mCurrentFrame++;
                mTimer = 0;
            }
            FrameReset();
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to Main SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            // Override normal draw method with specialised animating one

            // Calculate size of each animation frame
            mWidth = mTexture.Width / mColumns;
            mHeight = mTexture.Height / mRows;
            int _row = (int)((float)mCurrentFrame / (float)mColumns);
            int _column = mCurrentFrame % mColumns;

            // Update Current Texture width and height
            mCurrentTextureHeight = mHeight;
            mCurrentTextureWidth = mWidth;

            // Position selection around frame of spritesheet
            Rectangle _sourceRectangle = new Rectangle(mWidth * _column, mHeight * _row, mWidth, mHeight);
            Rectangle _destinationRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight);

            // Run spritebatch update with each frame of the animation
            _spriteBatch.Draw(mTexture, _destinationRectangle, _sourceRectangle, Color.AntiqueWhite);
        }
        #endregion
    }
}
