﻿using GMTB.CollisionSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for the Player mind
    /// </summary>
    public interface IPlayerMind
    {
        /// Accessor for States to access service Locator
        IServiceLocator ServiceLocator { get; }
        /// Reference to the Players Self
        IPlayer MySelf { get; set; }
        /// Moving bool to control animation when returning to walk state from jump state
        bool Moving { get; set; }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Change the state
        /// </summary>
        /// <param name="_newState">New state to specify</param>
        void ChangeState(string _newState);
        /// <summary>
        /// Main Initialize routine
        /// </summary>
        void Initialize();
        /// <summary>
        /// Allows the body to call the minds collision method
        /// </summary>
        /// <param name="_otherObj">Other object collided with</param>
        void Collision(ICollidable _otherObj);
        /// <summary>
        /// Allows the Entity to suspend any logic in the mind and behaviour states
        /// </summary>
        void Suspend();
        /// <summary>
        /// Allows the Entity to resume any Logic in the mind and behaviour states
        /// </summary>
        void Resume();
        /// <summary>
        /// Cleans up the entity before destruction
        /// </summary>
        void Cleanup();


    }
}
