using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// Abstract class for a Convex Shape
    /// </summary>
    public abstract class ConvexShape : PhysicalEntity, ICollidable
    {
        #region Data Members
        //private Rectangle mRectangle;
        /// List of vectors to hold the points
        protected List<Vector2> pointsVertices;
        /// List of Normals
        protected List<Vector2> perpRec;
        /// Number of Axes in shape
        protected int mAxes;
        /// Rectangle for AABB midphase Collision Detection
        protected Rectangle mHitbox;
        /// Detect if collidable is floor or wall
        protected bool isFloorOrWall;
        #endregion

        #region Accessors
        /// Normalized Normals for this shape
        public List<Vector2> RectangleNormalize { get; protected set; } = new List<Vector2>();
        /// Vertices of this shape
        public List<Vector2> RectangleVertices { get; protected set; } = new List<Vector2>();
        /// Velocity of this shape
        public Vector2 Velocity { get { return mVelocity; } }
        /// AABB for this shape
        public Rectangle Hitbox { get { return mHitbox; } }

        /// Shape Position
        Vector2 ICollidable.Position
        {
            get => mPosition;
            set => mPosition = value;
        }
        #endregion

        #region Constructor
        public ConvexShape()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets the initial position of this shape and creates it's hitbox
        /// </summary>
        /// <param name="_pos">Vector Coordinates of default position</param>
        public override void setDefaultPos(Vector2 _pos)
        {
            base.setDefaultPos(_pos);
            mHitbox = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
        }
        /// <summary>
        /// Main Update loop
        /// Keeps Hitbox alligned with position
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            mHitbox.Location = mPosition.ToPoint();
        }
        /// <summary>
        /// Updates the variables requried for collision detection
        /// </summary>
        /// <returns> List of Normals </returns>
        public virtual List<Vector2> UpdateCollisionMesh()
        {
            RectangleNormalize = new List<Vector2>();
            RectangleVertices = new List<Vector2>();

            pointsVertices = GetPointsVertices();
            UpdateVertices(pointsVertices);
            List<Vector2> _subtractedVectors = SubtractVectors();
            perpRec = GetNormals(_subtractedVectors);
            Normalize(perpRec);
            //List<Vector2> perpendicularRectangles = GetPerpendicularRectangles(subtractedVectors);
            //Normalize(perpendicularRectangles);
            return RectangleNormalize;
        }
        /// <summary>
        /// Get the points of each vertices of the shape
        /// Overriden by actual shape
        /// </summary>
        /// <returns>List of Points</returns>
        protected abstract List<Vector2> GetPointsVertices();
        /// <summary>
        /// Add the current location of the vertices to the main list
        /// Correct for rotation
        /// </summary>
        /// <param name="_pointsVertices">List of Vertices</param>
        private void UpdateVertices(List<Vector2> _pointsVertices)
        {
            foreach (Vector2 _vec2 in _pointsVertices)
            {
                float _originX = mPosition.X + mOrigin.X;
                float _originY = mPosition.Y + mOrigin.Y;
                RectangleVertices.Add(RotatePoint(_vec2, new Vector2(_originX, _originY), mRotation));
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
        private List<Vector2> GetNormals(List<Vector2> _subtractedVectors)
        {
            List<Vector2> _rtnLst = new List<Vector2>();

            for (int i = 0; i < mAxes; i++)
            {
                _rtnLst.Add(new Vector2(_subtractedVectors[i].Y,
                                        _subtractedVectors[i].X * -1));
            }

            return _rtnLst;
        }
        /// <summary>
        /// Normalize the normals
        /// </summary>
        /// <param name="perpendicularRectangles">List of normals</param>
        private void Normalize(List<Vector2> _perpendicularRectangles)
        {
            for (int i = 0; i < mAxes; i++)
            {
                RectangleNormalize.Add(Vector2.Normalize(_perpendicularRectangles[i]));
            }
        }
        /// <summary>
        /// Correct for rotations
        /// </summary>
        /// <param name="Point">Point to correct</param>
        /// <param name="Origin">Original position of point</param>
        /// <param name="rotation">Rotation to account for</param>
        /// <returns>Vector accounting for rotations</returns>
        private Vector2 RotatePoint(Vector2 _Point, Vector2 _Origin, float _Rotation)
        {
            Vector2 _rtnVal = new Vector2()
            {
                X = (float)(_Origin.X + (_Point.X - _Origin.X)
                * Math.Cos(_Rotation) - (_Point.Y - _Origin.Y)
                * Math.Sin(_Rotation)),

                Y = (float)(_Origin.Y + (_Point.Y - _Origin.Y)
                * Math.Cos(_Rotation) + (_Point.X - _Origin.X)
                * Math.Sin(_Rotation))
            };
            return _rtnVal;
        }
        /// <summary>
        /// Collision Response
        /// </summary>
        /// <param name="_mtv">Minimum Translation Vector</param>
        /// <param name="_cNormal">Collision Normal</param>
        /// <param name="_otherObj">Other Object Collided with</param>
        public virtual void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            isFloorOrWall = false;

            //if (_cNormal == new Vector2(0, 1))
            //{
            //    isFloorOrWall = true;
            //}
            //else if (_cNormal == new Vector2(1, 0) || _cNormal == new Vector2(-1, 0))
            //{
            //    mPosition += 0.07f * _mtv;
            //    isFloorOrWall = true;
            //}
            //else
            //{
            //    mPosition += 0.02f * _mtv;
            //}

            mPosition += 1f * _mtv;

            IStaticObject asInterface = _otherObj as IStaticObject;
            
            if (asInterface != null)
            {
                if (asInterface.TextureName == "wall" || asInterface.TextureName == "floor")
                    isFloorOrWall = true;
            }
            //else
            //{
            //    mPosition += 0.05f * _mtv;
            //}

            CalculateBounce(_cNormal, _otherObj, isFloorOrWall);
            mVelocity = Vector2.Zero;

        }
        /// <summary>
        /// Physics response
        /// </summary>
        /// <param name="_cNormal">Collision Normal</param>
        /// <param name="_otherObj">Other object Collided with</param>
        public virtual void CalculateBounce(Vector2 _cNormal, ICollidable _otherObj, bool isFloorOrWall)
        {
            Vector2 _difference = mVelocity - _otherObj.Velocity;
            float _dot = Vector2.Dot(_cNormal, _difference);
            Vector2 _ClosingVelocity = _dot * _cNormal;
            ApplyImpulse(_ClosingVelocity, isFloorOrWall);
        }
    }
    #endregion
}

