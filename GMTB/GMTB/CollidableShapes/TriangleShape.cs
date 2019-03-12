using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GMTB.CollidableShapes
{
    public class TriangleShape : ConvexShape
    {
        #region Data Members
        // Indicates the location of the rightangle, 1 = right angle on left, -1 = right angle on right
        private int mFacingDirection;
        KeyboardState oldState;
        private Rectangle mRectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Collidable class for Triangluar objects
        /// </summary>
        /// <param name="startPos">Starting position vector</param>
        /// <param name="tex">Texture</param>
        /// <param name="content">Reference to the Content Manager</param>
        public TriangleShape()
        {
            mAxes = 3;
            mFacingDirection = 1;
            mRotation = 0f;
        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            SwapDirection();
            pointsVertices = GetPointsVertices();
            base.Update(gameTime);

        }
        /// <summary>
        /// Calculate the location of each vertex
        /// </summary>
        /// <returns>List of vertices</returns>
        private List<Vector2> GetPointsVertices()
        {
            Vector2 hypotenuse = new Vector2(0);
            if (mFacingDirection == 1)
                hypotenuse = new Vector2(mPosition.X, mPosition.Y);
            else if (mFacingDirection == -1)
                hypotenuse = new Vector2(mPosition.X + mRectangle.Width, mPosition.Y);
            List<Vector2> rtnLst = new List<Vector2>
            {
                hypotenuse,
                new Vector2(mPosition.X + mRectangle.Width, mPosition.Y + mRectangle.Height),
                new Vector2(mPosition.X, mPosition.Y + mRectangle.Height)
            };

            return rtnLst;
        }

        private void SwapDirection()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyUp(Keys.Space) == true && oldState.IsKeyDown(Keys.Space) == true)
                mFacingDirection *= -1;

            if (mFacingDirection == 1)
                mTexturename = "trianglel";
            else if (mFacingDirection == -1)
                mTexturename = "triangler";


            oldState = newState;
        }
        #endregion
    }
}
