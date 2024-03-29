﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for the player
    /// </summary>
    public interface IPlayer
    {

        /// <summary>
        /// Get current position
        /// </summary>
        /// <returns>Current Vector Position</returns>
        Vector2 GetPos();
        /// Set Current Texture
        Texture2D Texture { set; }
        /// <summary>
        /// Allows States to change the texture
        /// </summary>
        string Texturename { get; set; }
        /// <summary>
        /// Apply a specified force to the Acceleration
        /// </summary>
        /// <param name="_force">New Force to apply</param>
        void ApplyForce(Vector2 _force);
        /// <summary>
        /// Allows states to see and alter the facing direction
        /// </summary>
        string FacingDirection { get; set; }

    }
}
