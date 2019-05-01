using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for AI Mind
    /// </summary>
    public interface IAIMind
    {
        /// Reference to the Mind's Host
        IBasicAI MySelf { get; set; }
        /// Reference to the Minds Pathfinder
        IPathfinder Pathfinder { get; set; }
        /// Reference to the Current target
        AITarget Target { get; }
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Change State
        /// </summary>
        /// <param name="_newState">State to change to</param>
        void ChangeState(string _newState);
        /// <summary>
        /// Main Initialize
        /// </summary>
        void Initialize();
        /// <summary>
        /// Trigger Collision event
        /// </summary>
        /// <param name="_obj">Other Object Collided with</param>
        void Collision(ICollidable _obj);
    }
}
