using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Interfaces;
using GMTB.Managers;
using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.CollisionSystem
{
    public class Door : RectangleShape, IDoor, IisTrigger
    {
        #region Data Members

        protected Rectangle mDoor;
        protected string mTargetLevel;
        protected ILevel_Manager mLevelManager;
        protected bool mColliding = false;
        protected bool mSuspendPrevLvl;
        protected bool mTriggered;
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
            mColliding = false;
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
        public override void setVars(int _uid, IServiceLocator _sl)
        {
            base.setVars(_uid, _sl);
            mInputManager = _sl.GetService<IInput_Manager>();
            mLevelManager = _sl.GetService<ILevel_Manager>();
        }

        public void Initialize(string _target, bool _suspend)
        {
            mTargetLevel = _target;
            mSuspendPrevLvl = _suspend;
            Subscribe();
        }
        // Depreciated - Use the Level suspension system instead of trying to move the player
        public void Initialize(string _target, Vector2 _playerPos, bool _suspend)
        {
            Initialize(_target, _suspend);            
            // Figure out where / how to move player pos
        }

        public virtual void Subscribe()
        {
            mInputManager.Sub_Use(OnUse);
        }

        public override void Collision(ICollidable _obj)
        {
            base.Collision(_obj);
        }
        public void OnTrigger(ICollidable _obj)
        {
            // VALIDATION: Cast the object to an IPlayer, if it casts succesfully, allow level switching
            var asInterface = _obj as IPlayer;
            if (asInterface != null)
                mColliding = true;
        }
        public virtual void OnUse(object source, InputEvent args)
        {
            if (mColliding && args.currentKey == Keybindings.Use && !mTriggered)
            {
                mTriggered = true;
                mLevelManager.LoadLevel(mTargetLevel, mSuspendPrevLvl);
                mInputManager.Un_Use(OnUse);
            }
        }
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Empty override
        }

        protected override void UpdatePhysics()
        {
            // Empty override
        }
        public override void Suspend()
        {
            base.Suspend();
            mColliding = false;
        }
        public override void Resume()
        {
            base.Resume();
            mTriggered = false;
        }
        #endregion
    }
}
