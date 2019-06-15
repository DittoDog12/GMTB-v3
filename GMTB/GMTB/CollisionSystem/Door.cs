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
    /// <summary>
    /// Door Object
    /// </summary>
    public class Door : RectangleShape, IDoor, IisTrigger
    {
        #region Data Members
        /// AABB for Door
        protected Rectangle mDoor;
        /// Target Level to switch to
        protected string mTargetLevel;
        /// Reference to the Level manager
        protected ILevel_Manager mLevelManager;
        /// Check if colliding with object
        protected bool mColliding = false;
        /// Need to suspend previous level?
        /// Stops the Level Transition from erasing all previous entities
        protected bool mSuspendPrevLvl;
        /// Override to stop double triggering
        protected bool mTriggered;
        #endregion

        #region Constructor
        public Door()
        {
            mAxes = 2;
            mRotation = 0f;
        }

        #endregion

        #region Methods
        /// <summary>
        /// SetVars Override
        /// Creates AABB Rectangle
        /// </summary>
        /// <param name="_path">Texture Path</param>
        /// <param name="_cm">Content Manager Reference</param>
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            mDoor = new Rectangle((int)mPosition.X, (int)mPosition.Y, mTexture.Width, mTexture.Height);
        }
        /// <summary>
        /// SetVars Override
        /// Sets up Manager References
        /// </summary>
        /// <param name="_uid">Unique Entity Identifier</param>
        /// <param name="_sl">Reference to Service Locator</param>
        public override void setVars(int _uid, IServiceLocator _sl)
        {
            base.setVars(_uid, _sl);
            mInputManager = _sl.GetService<IInput_Manager>();
            mLevelManager = _sl.GetService<ILevel_Manager>();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            // Reset Colliding Switch
            mColliding = false;
            base.Update(_gameTime);
            // Unsubscribe from keyboards
            mInputManager.Un_Use(OnUse);

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
        /// <summary>
        /// Sets up Door Specific Variables
        /// </summary>
        /// <param name="_target">Target level to open</param>
        /// <param name="_suspend">Need to suspend previous level?</param>
        public void Initialize(string _target, bool _suspend)
        {
            mTargetLevel = _target;
            mSuspendPrevLvl = _suspend;
            //Subscribe();
        }
        /// <summary>
        /// Subscribe to Keyboard Events
        /// </summary>
        public virtual void Subscribe()
        {
            mInputManager.Sub_Use(OnUse);
        }
        /// <summary>
        /// Collision Event
        /// </summary>
        /// <param name="_obj">Object Collided with</param>
        public override void Collision(ICollidable _obj)
        {
            base.Collision(_obj);
        }
        /// <summary>
        /// Trigger Collision Event
        /// </summary>
        /// <param name="_obj">Object Triggered with</param>
        public void OnTrigger(ICollidable _obj)
        {
            // VALIDATION: Cast the object to an IPlayer, if it casts succesfully, allow level switching
            var asInterface = _obj as IPlayer;
            if (asInterface != null)
            {
                mColliding = true;
                // Only subscribe to keyboard events if colliding with player
                Subscribe();
            }
        }
        /// <summary>
        /// Keyboard Event Listener
        /// </summary>
        /// <param name="source">Event source</param>
        /// <param name="args">Event arguments</param>
        public virtual void OnUse(object source, InputEvent args)
        {
            if (mColliding && args.currentKey == Keybindings.Use && !mTriggered)
            {
                mTriggered = true;
                mLevelManager.LoadLevel(mTargetLevel, mSuspendPrevLvl);
                mInputManager.Un_Use(OnUse);
            }
        }
        /// <summary>
        /// Physical Collision Response
        /// Empty Override
        /// </summary>
        /// <param name="_mtv">Minimum Translation Vector</param>
        /// <param name="_cNormal">Collision normal</param>
        /// <param name="_otherObj">Other Object Collided with</param>
        public override void Collision(Vector2 _mtv, Vector2 _cNormal, ICollidable _otherObj)
        {
            // Empty override
        }
        /// <summary>
        /// Main Physics Update
        /// Empty Override
        /// </summary>
        protected override void UpdatePhysics()
        {
            // Empty override
        }
        /// <summary>
        /// Entity Suspend Override
        /// Sets Colliding flag to false
        /// </summary>
        public override void Suspend()
        {
            base.Suspend();
            mColliding = false;
        }
        /// <summary>
        /// Entity Resume Override
        /// Forces Triggered flag to false
        /// </summary>
        public override void Resume()
        {
            base.Resume();
            mTriggered = false;
        }
        /// <summary>
        /// Cleans up the entity before destruction
        /// </summary>
        public override void Cleanup()
        {
            base.Cleanup();
            mInputManager.Un_Use(OnUse);
        }
        #endregion
    }
}
