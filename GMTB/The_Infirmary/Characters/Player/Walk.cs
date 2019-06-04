using GMTB;
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
    /// Player Walk State
    /// </summary>
    public class Walk : State
    {
        #region Data Members
        /// Reference to the Input Manager
        private IInput_Manager mInputManager;
        private float mSpeed;
        
        #endregion
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_mind">Reference to the Mind</param>
        public Walk(IPlayerMind _mind) : base(_mind)
        {
            mSpeed = 3f;
        }
        /// <summary>
        /// Initialize the state
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
            mInputManager = mPMind.ServiceLocator.GetService<IInput_Manager>();
            // Set intial facing direction
            switch (mPMind.MySelf.Texturename)
            {
                case "Characters/Player/standR":
                    mPMind.MySelf.FacingDirection = "right";
                    break;
                case "Characters/Player/standL":
                    mPMind.MySelf.FacingDirection = "left";
                    break;
            }
            Reactivate();
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            
        }
        /// <summary>
        /// Reset settings when swithcing back to this state
        /// </summary>
        public override void Reactivate()
        {
            mInputManager.Sub_Space(OnSpace);
            mInputManager.Sub_Move(OnMoveInput);
            if (mAnimation.Moving)
            {
                mAnimation.Frames = 8;
                mAnimation.Columns = 8;
                if (mPMind.MySelf.FacingDirection == "right")
                    mPMind.MySelf.Texturename = "Characters/Player/walkR";
                else if (mPMind.MySelf.FacingDirection == "left")
                    mPMind.MySelf.Texturename = "Characters/Player/walkL";
            }
            else
            {
                mAnimation.Frames = 1;
                mAnimation.Columns = 1;
                mAnimation.Frame = 0;
                if (mPMind.MySelf.FacingDirection == "standR")
                    mPMind.MySelf.Texturename = "Characters/Player/standR";
                else if (mPMind.MySelf.FacingDirection == "standL")
                    mPMind.MySelf.Texturename = "Characters/Player/standL";
            }
            
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
                        mPMind.MySelf.Texturename = "Characters/Player/walkR";
                    }
                    mAnimation.Frames = 8;
                    mAnimation.Columns = 8;
                    mAnimation.Moving = true;
                    mPMind.MySelf.ApplyForce(new Vector2(mSpeed, 0));
                    break;
                //Left Movement
                case Keybindings.Left:
                    if (mPMind.MySelf.FacingDirection != "left")
                    {
                        mPMind.MySelf.FacingDirection = "left";
                        mPMind.MySelf.Texturename = "Characters/Player/walkL";
                    }
                    mAnimation.Frames = 8;
                    mAnimation.Columns = 8;
                    mAnimation.Moving = true;
                    mPMind.MySelf.ApplyForce(new Vector2(-mSpeed, 0));
                    break;
                // Override up and down, if using gamepad and the stick is slightly mvoed on the Y axis it confuses the input detection
                case Keybindings.Up:
                case Keybindings.Down:
                    break;
                // Reset if not moving, or input not recognised
                case Keybindings.Released:
                default:
                    mAnimation.Frames = 1;
                    mAnimation.Columns = 1;
                    mAnimation.Frame = 0;
                    if (mPMind.MySelf.FacingDirection == "right")
                    {
                        mPMind.MySelf.Texturename = "Characters/Player/standR";
                        mPMind.MySelf.FacingDirection = "standR";
                    }
                    else if (mPMind.MySelf.FacingDirection == "left")
                    {
                        mPMind.MySelf.Texturename = "Characters/Player/standL";
                        mPMind.MySelf.FacingDirection = "standL";
                    }
                    mAnimation.Moving = false;
                    mPMind.MySelf.ApplyForce(Vector2.Zero);
                    break;
            }
        }
        /// <summary>
        /// On space switch to the Jump State
        /// </summary>
        /// <param name="source">Event Source</param>
        /// <param name="args">Event Arguments</param>
        public void OnSpace(object source, InputEvent args)
        {
            if (args.currentKey == Keybindings.Jump && Global.GameState == Global.availGameStates.Playing)
            {
                mPMind.ChangeState("jump");
                mInputManager.Un_Space(OnSpace);
                mInputManager.Un_Move(OnMoveInput);
            }
                
        }
        /// <summary>
        /// Main Draw Loop
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }
    }
}
