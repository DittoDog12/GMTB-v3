using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using GMTB.InputSystem;
using GMTB.Interfaces;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Triangular Shape
    /// </summary>
    public class TriangleShape : ConvexShape
    {
        #region Data Members
        /// Indicates the location of the rightangle, 1 = right angle on left, -1 = right angle on right
        private int mFacingDirection;
        /// Rectangle for Vector position calculation
        protected Rectangle mRectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Collidable class for Triangluar objects
        /// </summary>
        public TriangleShape()
        {
            mAxes = 3;
            mFacingDirection = 1;
            mRotation = 0f;
            mSpeed = 0f;
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Variables override
        /// </summary>
        /// <param name="_path">Texture Path</param>
        /// <param name="_cm">Content Manager Refence</param>
        public override void setVars(string _path, IContent_Manager cm)
        {
            base.setVars(_path, cm);
            mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
        }
        /// <summary>
        /// Configures Input
        /// </summary>
        public override void ConfigureInput()
        {
            base.ConfigureInput();
            mInputManager.Sub_Space(SwapDirection);
        }
        /// <summary>
        /// Calculate the location of each vertex
        /// </summary>
        /// <returns>List of vertices</returns>
        protected override List<Vector2> GetPointsVertices()
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

        private void SwapDirection(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump)
                mFacingDirection *= -1;

            if (mFacingDirection == 1)
                mTexture = mContentManager.ApplyTexture("trianglel");
            else if (mFacingDirection == -1)
                mTexture = mContentManager.ApplyTexture("triangler");

        }
        #endregion        
    }
}
