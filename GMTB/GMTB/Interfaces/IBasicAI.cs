﻿using GMTB.Interfaces;
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
    /// Interface for AI physical presence
    /// </summary>
    public interface IBasicAI
    {
        /// Reference to the Service Locator
        IServiceLocator ServiceLocator { get; }
        /// Moving or not override
        bool Moving { set; }
        /// Current Texture
        Texture2D Texture { get; }
        /// Lets Behaviours change Texture
        string Texturename { set; }
        /// Current Position
        Vector2 Position { get; }
        /// Current Acceleration
        Vector2 Acceleration { set; }
        /// Current AI Target
        AITarget Target { get; }
        /// Let's Behaviours set a target destination
        Vector2 Destination { set; }
        /// Let's behaviours set active state
        bool Active { set; }
        /// Lets behaviours see current direction
        GMTB.Entities.FacingDirection CurrentDirection { get; }
        /// <summary>
        /// Get the position of the specified target
        /// </summary>
        /// <param name="_target">Target to Locate</param>
        void LocateTarget(AITarget _target);
        /// <summary>
        /// Apply a specifed force to the entity
        /// </summary>
        /// <param name="_force">Force to Apply</param>
        void ApplyForce(Vector2 _force);
    }
}
