using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.CollisionSystem;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for behaviour states
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Initialize routine
        /// </summary>
        void Initialize();
        /// <summary>
        /// Main Update loop
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        void Update(GameTime _gameTime);
        /// <summary>
        /// Non Physical Collision response
        /// </summary>
        /// <param name="_obj">Other object collided with</param>
        void Collision(ICollidable _obj);
        /// <summary>
        /// Optional Method for reactivating a state after change
        /// </summary>
        void Reactivate();
    }
}
