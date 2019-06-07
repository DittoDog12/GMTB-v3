using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Rectangular Shape
    /// </summary>
    public class RectangleShape : ConvexShape
    {
        #region Data Members
        /// Rectangle for Vector position calculation
        protected Rectangle mRectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Collidable class for rectangular objects
        /// </summary>
        public RectangleShape()
        { 
            mAxes = 4;
            mRotation = 0f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Variables override
        /// </summary>
        /// <param name="_path">Texture Path</param>
        /// <param name="_cm">Content Manager Refence</param>
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mCurrentTextureWidth, mCurrentTextureHeight);
        }
        /// <summary>
        /// Get the points of each vertices of the rectangle
        /// </summary>
        /// <returns>List of Points</returns>
        protected override List<Vector2> GetPointsVertices()
        {
            List<Vector2> rtnLst = new List<Vector2>
            {
                new Vector2(mPosition.X, mPosition.Y),
                new Vector2(mPosition.X + mRectangle.Width, mPosition.Y),
                new Vector2(mPosition.X + mRectangle.Width, mPosition.Y + mRectangle.Height),
                new Vector2(mPosition.X, mPosition.Y + mRectangle.Height)
            };
            Console.WriteLine(mTexture.Name + ": " + mCurrentTextureWidth + ", " + mCurrentTextureHeight);
            return rtnLst;
        }

        #endregion
    }
}
