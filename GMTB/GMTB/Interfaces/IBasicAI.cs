using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

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
