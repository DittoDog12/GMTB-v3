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
    public class RectangleShape : ConvexShape
    {
        #region Data Members
        protected Rectangle mRectangle;
        #endregion

        #region Constructor
        /// <summary>
        /// Collidable class for rectangular objects
        /// </summary>
        /// <param name="startPos">Starting position vector</param>
        /// <param name="tex">Texture</param>
        /// <param name="content">Reference to the Content Manager</param>
        public RectangleShape()
        { 
            mAxes = 4;
            mRotation = 0f;
        }
        #endregion

        #region Methods
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            mRectangle = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
        }

        public override void Update(GameTime _gameTime)
        {
            
            base.Update(_gameTime);
            //List<Vector2> perpendicularRectangles = GetPerpendicularRectangles(subtractedVectors);
            //Normalize(perpendicularRectangles);
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

            return rtnLst;
        }

        #endregion
    }
}
