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
    public class AnimatingEntity : RectangleShape
    {
        #region Data Members
        // Sets frame information for the Draw Method to read the spritesheets
        protected int mFrames;
        protected int mCurrentFrame;
        protected int mRows;
        protected int mColumns;

        // Row and Column sizes for Hitbox
        private int mWidth;
        private int mHeight;

        // Timers for frame transistions
        protected float mTimer;
        protected float mInterval;

        // Boolean to control if the entity is moving or not
        protected bool mMoving;
        #endregion

        #region Constructor
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
        // Override hitbox with alternate texture size values
        public override void setDefaultPos(Vector2 _pos)
        {
            base.setDefaultPos(_pos);
            mHitbox = new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight);
        }
        public virtual void FrameReset()
        {
            // Used to reset the animation when it reaches the end of the spritesheet
            if (mCurrentFrame == mFrames)
               mCurrentFrame = 0;
        }
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
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {

            // Override normal draw method with specialised animating one

            // Calculate size of each animation frame
            mWidth = mTexture.Width / mColumns;
            mHeight = mTexture.Height / mRows;
            int _row = (int)((float)mCurrentFrame / (float)mColumns);
            int _column = mCurrentFrame % mColumns;

            // Position selection around frame of spritesheet
            Rectangle _sourceRectangle = new Rectangle(mWidth * _column, mHeight * _row, mWidth, mHeight);
            Rectangle _destinationRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mWidth, mHeight);

            // Run spritebatch update with each frame of the animation
            _spriteBatch.Draw(mTexture, _destinationRectangle, _sourceRectangle, Color.AntiqueWhite);
        }
        #endregion
    }
}
