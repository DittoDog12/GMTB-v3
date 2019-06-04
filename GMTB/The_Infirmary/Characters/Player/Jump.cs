using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Player
{
    /// <summary>
    /// Player Jump Behaviour
    /// </summary>
    public class Jump : State
    {
        /// Vector to jump along
        private Vector2 mJumpVector;
        /// Force of the jump
        private float mJumpForce;
        /// Jumping or not, used to stop the collision detection triggering too early
        private bool mJumping = true;
        /// Max height reached
        private bool mMaxReached = false;
        /// Max Height of jump
        private float mJumpHeight = 160f;
        /// Max Height of current Jump
        private float mJumpMax;
        /// Horizontal move speed
        private float mSpeed;

        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Jump(IPlayerMind _mind) : base(_mind)
        {
            mJumpForce = -6f;
            mJumping = true;
            mSpeed = 3f;
        }
        /// <summary>
        /// Reactivate the Behaviour
        /// </summary>
        public override void Reactivate()
        {
            base.Reactivate();
            // Set animation settings
            mAnimation.Frames = 5;
            mAnimation.Columns = 5;
            // Reset Jump Velocity
            mJumpVector = Vector2.Zero;
            // Stop collision detection running right away
            mJumping = true;
            // Reset max jump reached
            mMaxReached = false;
            // Calculate the coordinates of the current jump max
            mJumpMax = mPMind.MySelf.GetPos().Y - mJumpHeight;
            // Set Texture
            if (mPMind.MySelf.FacingDirection == "right" || mPMind.MySelf.FacingDirection == "standR")
                mPMind.MySelf.Texturename = "Characters/Player/jumpR";
            else if (mPMind.MySelf.FacingDirection == "left" || mPMind.MySelf.FacingDirection == "standL")
                mPMind.MySelf.Texturename = "Characters/Player/jumpL";
            // Subscribe the movement
            mPMind.ServiceLocator.GetService<IInput_Manager>().Sub_Move(OnMoveInput);
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            // If not at top of jump, continue jumping
            if (!mMaxReached)
                mJumpVector.Y = mJumpForce;
            // If at top of jump, stop jumping
            if (mPMind.MySelf.GetPos().Y <= mJumpMax)
            {
                mMaxReached = true;
                mJumpVector.Y = 0;
            }

            if (mAnimation != null)
            {
                if (mAnimation.Frame >= 2 && !mMaxReached)
                {
                    mAnimation.Frame = 2;
                    mAnimation.Moving = false;
                }
                else if (mAnimation.Frame <= 2 && mMaxReached)
                {
                    mAnimation.Frame = 4;
                }
            }

            mPMind.MySelf.ApplyForce(mJumpVector);
            // Set toggle to allow collision detection to resume
            mJumping = false;
        }
        /// <summary>
        /// Non physical Collision Detection
        /// Used to see if the player has landed
        /// </summary>
        /// <param name="_obj">Other Object Collided with</param>
        public override void Collision(ICollidable _obj)
        {
            //IStaticObject asInterface = _obj as IStaticObject;
            //if (asInterface.TextureName == "floor" && !mJumping)
            mPMind.ChangeState("walk");
            mPMind.ServiceLocator.GetService<IInput_Manager>().Un_Move(OnMoveInput);

        }
        /// <summary>
        /// Move input trigger
        /// </summary>
        /// <param name="_source">Event Source</param>
        /// <param name="_args">Event Arguments</param>
        public void OnMoveInput(object _source, InputEvent _args)
        {
            switch (_args.currentKey)
            {
                // Right Movement
                case Keybindings.Right:
                    if (mPMind.MySelf.FacingDirection != "right")
                    {
                        mPMind.MySelf.FacingDirection = "right";
                        mPMind.MySelf.Texturename = "Characters/Player/jumpR";
                    }
                    mJumpVector.X = mSpeed;
                    break;
                //Left Movement
                case Keybindings.Left:
                    if (mPMind.MySelf.FacingDirection != "left")
                    {
                        mPMind.MySelf.FacingDirection = "left";
                        mPMind.MySelf.Texturename = "Characters/Player/jumpL";
                    }
                    mJumpVector.X = -mSpeed;
                    break;
                // Override up and down, if using gamepad and the stick is slightly mvoed on the Y axis it confuses the input detection
                case Keybindings.Up:
                case Keybindings.Down:
                    break;
                // Reset if not moving, or input not recognised
                case Keybindings.Released:
                default:
                    if (mPMind.MySelf.FacingDirection == "right")
                        mPMind.MySelf.FacingDirection = "standR";
                    else if (mPMind.MySelf.FacingDirection == "left")
                        mPMind.MySelf.FacingDirection = "standL";
                    mJumpVector.X = 0;
                    break;
            }
        }
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {

        }
    }
}
