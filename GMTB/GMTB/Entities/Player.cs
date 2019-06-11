using System;
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
        #region Data Members
        /// String to hold the current facing direction
        protected string mFacingDirection;
        #endregion
        #region Constructor
        /// <summary>
        /// Main Constructor
        /// </summary>
        public Player()
        {
        }
        #endregion

        #region Accessors
        /// <summary>
        /// Allows states to see and alter the facing direction
        /// </summary>
        public string FacingDirection
        {
            get { return mFacingDirection; }
            set { mFacingDirection = value; }
        }
        #endregion
        #region Methods
        /// <summary>
        /// Setup movement input triggers
        /// </summary>
        public override void ConfigureInput()
        {
            base.ConfigureInput();
            
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
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        public override void Update(GameTime _gameTime)
        {
            base.Update(_gameTime);
            Debug.WriteLine("Player Position: " + mPosition);
        }


        #endregion
    }
}
