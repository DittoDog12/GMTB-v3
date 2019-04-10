using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using GMTB.Managers;
using Microsoft.Xna.Framework;

namespace GMTB.CollisionSystem
{
    public class Door : RectangleShape, IDoor
    {
        #region Data Members

        protected Rectangle mDoor;
        protected string mTargetLevel;
        protected ILevel_Manager mLevelManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Collidable class for rectangular objects
        /// </summary>
        /// <param name="startPos">Starting position vector</param>
        /// <param name="tex">Texture</param>
        /// <param name="content">Reference to the Content Manager</param>
        public Door()
        {
            mAxes = 4;
            mRotation = 0f;
        }

        #endregion

        #region Methods
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            mDoor = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
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
                new Vector2(mPosition.X + mDoor.Width, mPosition.Y),
                new Vector2(mPosition.X + mDoor.Width, mPosition.Y + mDoor.Height),
                new Vector2(mPosition.X, mPosition.Y + mDoor.Height)
            };

            return rtnLst;
        }

        public void setVars(IServiceLocator _sl)
        {
            mLevelManager = _sl.GetService<ILevel_Manager>();
        }

        public void Initialize(string _target)
        {
            mTargetLevel = _target;
        }

        public void Initialize(string _target, Vector2 _playerPos)
        {
            Initialize(_target);
            // Figure out where / how to move player pos
        }

        public override void Collision()
        {
            base.Collision();

            // VALIDATION: Include validation which ensures the next level is only loaded if a player collides with the door

            mLevelManager.LoadLevel(mTargetLevel);
        }
        #endregion
    }
}
