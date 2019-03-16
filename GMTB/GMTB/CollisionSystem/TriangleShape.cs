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
    public class TriangleShape : ConvexShape
    {
        #region Data Members
        // Indicates the location of the rightangle, 1 = right angle on left, -1 = right angle on right
        private int mFacingDirection;
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
            mSpeed = 0f;
            
        }
        #endregion

        #region Methods
        public override void setVars(string _path, IContent_Manager cm)
        {
            base.setVars(_path, cm);
            mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
        }
        public override void ConfigureInput(IInput_Manager im)
        {
            base.ConfigureInput(im);
            mInputManager.Sub_Space(SwapDirection);
        }
        public override void Update(GameTime gameTime)
        {
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

        private void SwapDirection(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump)
                mFacingDirection *= -1;

            if (mFacingDirection == 1)
                mContentManager.ApplyTexture("trianglel", this);
            else if (mFacingDirection == -1)
                mContentManager.ApplyTexture("triangler", this);

        }
        #endregion        
    }
}
