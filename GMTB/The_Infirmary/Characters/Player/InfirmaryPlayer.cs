using GMTB.Entities;
using GMTB.InputSystem;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.CollisionSystem;

namespace The_Infirmary.Characters.Player
{
    /// <summary>
    /// Infirmary Player
    /// </summary>
    class InfirmaryPlayer : GMTB.Entities.Player, AITarget
    {
        #region Data Members
        /// String to hold the current facing direction
        private string mFacingDirection;
        /// Reference to the Mind
        private IPlayerMind mMind;
        #endregion


        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public InfirmaryPlayer()
        {
            mFrames = 1;
            mColumns = 1;
            mInterval = 75f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Set Core Variables
        /// </summary>
        /// <param name="_uid">Entity Unique Identifier</param>
        /// <param name="_sl">Reference to the Service Locator</param>
        public override void setVars(int _uid, IServiceLocator _sl)
        {
            base.setVars(_uid, _sl);
            mMind = new PlayerMind(this, mServiceLocator);
        }
        /// <summary>
        /// Set Core Variables
        /// </summary>
        /// <param name="_path">Path to the Texture</param>
        /// <param name="_cm">Reference to the Content Manager</param>
        public override void setVars(string _path, IContent_Manager _cm)
        {
            base.setVars(_path, _cm);
            if (_path == "Characters/Player/walkR")
                mFacingDirection = "right";
            else if (_path == "Characters/Player/walkL")
                mFacingDirection = "left";
        }
        /// <summary>
        /// Move input trigger
        /// </summary>
        /// <param name="_source">Event Source</param>
        /// <param name="_args">Event Arguments</param>
        public override void OnMoveInput(object _source, InputEvent _args)
        {
            
            base.OnMoveInput(_source, _args);
            switch (_args.currentKey)
            {
                // Right Movement
                case Keybindings.Right:
                    if (mFacingDirection != "right")
                    {
                        mFacingDirection = "right";
                        mTexturename = "Characters/Player/walkR";
                    }
                    mFrames = 8;
                    mColumns = 8;
                    mMoving = true;
                    break;
                //Left Movement
                case Keybindings.Left:
                    if (mFacingDirection != "left")
                    {
                        mFacingDirection = "left";
                        mTexturename = "Characters/Player/walkL";
                    }
                    mFrames = 8;
                    mColumns = 8;
                    mMoving = true;
                    break;
                // Override up and down, if using gamepad and the stick is slightly mvoed on the Y axis it confuses the input detection
                case Keybindings.Up:
                case Keybindings.Down:
                    break;
                // Reset if not moving, or input not recognised
                case Keybindings.Released:              
                default:
                    mFrames = 1;
                    mColumns = 1;
                    mCurrentFrame = 0;
                    if (mFacingDirection == "right")
                        mTexturename = "Characters/Player/standR";
                    else if (mFacingDirection == "left")
                        mTexturename = "Characters/Player/standL";

                    mFacingDirection = "stand";
                    mMoving = false;
                    break;
            }
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            mMind.Update(_gameTime);
            base.Update(_gameTime);        
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            if (mMoving)
                IncrementFrame(_gameTime);

            if (mTexturename != mTexture.Name)
                mTexture = mContentManager.ApplyTexture(mTexturename);

            base.Draw(_spriteBatch, _gameTime);
        }
        /// <summary>
        /// Non physical collision response
        /// </summary>
        /// <param name="_obj">Other object collided with</param>
        public override void Collision(ICollidable _obj)
        {
            base.Collision(_obj);
            mMind.Collision(_obj);
        }
        #endregion
    }
}
