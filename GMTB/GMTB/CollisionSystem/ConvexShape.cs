using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    public class ConvexShape : PhysicalEntity, ICollidable
    {
        #region Data Members
        //private Rectangle mRectangle;
        protected List<Vector2> pointsVertices; // List of vectors to hold the points
        protected List<Vector2> perpRec; // List of Normals
        protected int mAxes;
        #endregion

        #region Accessors
        public List<Vector2> RectangleNormalize { get; protected set; } = new List<Vector2>();
        public List<Vector2> RectangleVertices { get; protected set; } = new List<Vector2>();
        public Vector2 Velocity{ get { return mVelocity; } }
        #endregion

        #region Constructor
        public ConvexShape()
        {

        }
        #endregion

        #region Methods
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            RectangleNormalize = new List<Vector2>();
            RectangleVertices = new List<Vector2>();

            UpdateVertices(pointsVertices);
            List<Vector2> subtractedVectors = SubtractVectors();
            perpRec = GetNormals(subtractedVectors);
            Normalize(perpRec);
            //List<Vector2> perpendicularRectangles = GetPerpendicularRectangles(subtractedVectors);
            //Normalize(perpendicularRectangles);
        }

        /// <summary>
        /// Add the current location of the vertices to the main list
        /// Correct for rotation
        /// </summary>
        /// <param name="pointsVertices">List of Vertices</param>
        private void UpdateVertices(List<Vector2> pointsVertices)
        {
            foreach (Vector2 vec2 in pointsVertices)
            {
                float originX = mPosition.X + mOrigin.X;
                float originY = mPosition.Y + mOrigin.Y;
                RectangleVertices.Add(RotatePoint(vec2, new Vector2(originX, originY), mRotation));
            }
        }
        /// <summary>
        /// Calculate the length of each face by subtracting the points of each vertices from each other
        /// </summary>
        /// <returns>List of faces as vectors</returns>
        private List<Vector2> SubtractVectors()
        {
            List<Vector2> _rtnLst = new List<Vector2>();

            for (int i = 0; i < mAxes; i++)
            {
                if (i == mAxes - 1)
                {
                    _rtnLst.Add(
                        Vector2.Subtract(RectangleVertices[0], RectangleVertices[i]));
                }
                else
                {
                    _rtnLst.Add(
                        Vector2.Subtract(RectangleVertices[i + 1], RectangleVertices[i]));
                }
            }

            return _rtnLst;
        }
        /// <summary>
        /// Get normals of each vertices
        /// </summary>
        /// <param name="subtractedVectors">List faces</param>
        /// <returns>List of normals for each face</returns>
        private List<Vector2> GetNormals(List<Vector2> subtractedVectors)
        {
            List<Vector2> _rtnLst = new List<Vector2>();

            for (int i = 0; i < mAxes; i++)
            {
                _rtnLst.Add(new Vector2(subtractedVectors[i].Y,
                                        subtractedVectors[i].X * -1));
            }

            return _rtnLst;
        }
        /// <summary>
        /// Normalize the normals
        /// </summary>
        /// <param name="perpendicularRectangles">List of normals</param>
        private void Normalize(List<Vector2> perpendicularRectangles)
        {
            for (int i = 0; i < mAxes; i++)
            {
                RectangleNormalize.Add(Vector2.Normalize(perpendicularRectangles[i]));
            }
        }
        /// <summary>
        /// Correct for rotations
        /// </summary>
        /// <param name="Point">Point to correct</param>
        /// <param name="Origin">Original position of point</param>
        /// <param name="rotation">Rotation to account for</param>
        /// <returns>Vector accounting for rotations</returns>
        private Vector2 RotatePoint(Vector2 Point, Vector2 Origin, float rotation)
        {
            Vector2 _rtnVal = new Vector2()
            {
                X = (float)(Origin.X + (Point.X - Origin.X)
                * Math.Cos(rotation) - (Point.Y - Origin.Y)
                * Math.Sin(rotation)),

                Y = (float)(Origin.Y + (Point.Y - Origin.Y)
                * Math.Cos(rotation) + (Point.X - Origin.X)
                * Math.Sin(rotation))
            };
            return _rtnVal;
        }
        public virtual void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            mPosition += 0.02f * _mtv;
            CalculateBounce(_cNormal, _otherObj);
            
        }
        public virtual void CalculateBounce(Vector2 _cNormal, ICollidable _otherObj)
        {
            Vector2 _difference = mVelocity - _otherObj.Velocity;
            float _dot = Vector2.Dot(_cNormal, _difference);
            Vector2 _ClosingVelocity = _dot * _cNormal;
            ApplyImpulse(_ClosingVelocity);
        }
    }
    #endregion
}

