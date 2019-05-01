﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;
using GMTB.InputSystem;
using GMTB.CollisionSystem;
using System.Diagnostics;

namespace GMTB.Entities
{
    /// <summary>
    /// Main Class for player
    /// </summary>
    public class Player : AnimatingEntity, IPlayer
    {
        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public Player()
        {
            mSpeed = 3f;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Setup movement input triggers
        /// </summary>
        public override void ConfigureInput()
        {
            base.ConfigureInput();
            mInputManager.Sub_Move(OnMoveInput);
        }
        /// <summary>
        /// Get current Position
        /// </summary>
        /// <returns>Current Vector Position</returns>
        public Vector2 GetPos()
        {
            return mPosition;
        }
        /// <summary>
        /// Main movement method
        /// </summary>
        /// <param name="_source">Event source</param>
        /// <param name="_args">Event Arguments</param>
        public virtual void OnMoveInput(object _source, InputEvent _args)
        {
            // Check the current keybinding in the event argument.
            // Apply force respectiveley
            switch (_args.currentKey)
            {
                case Keybindings.Down:                    
                case Keybindings.Up:           
                    break;
                case Keybindings.Right:
                    ApplyForce(new Vector2(mSpeed, 0));
                    break;
                case Keybindings.Left:
                    ApplyForce(new Vector2(-mSpeed, 0));
                    break;
                // If Keybinding is released, or keybinding is not recognised, stop moving
                case Keybindings.Released:
                default:
                    mVelocity = Vector2.Zero;
                    break;
            }
        }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            Debug.WriteLine(mPosition);
        }


        #endregion
    }
}
