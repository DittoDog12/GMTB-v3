using Microsoft.Xna.Framework;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Main Entity Interface, everything that exists impliments this Interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Entity Unique Identifier
        /// </summary>
        int UID { get; }

        /// <summary>
        /// Set Core Variables
        /// </summary>
        /// <param name="_uid">Entity Unique Identifier</param>
        /// <param name="_sl">Reference to Service Locator</param>
        void setVars(int _uid, IServiceLocator _sl);      
        /// <summary>
        /// Main Update Loop
        /// </summary>
        /// <param name="_gameTime">Reference to current GameTime</param>
        void Update(GameTime _gameTime);     
        /// <summary>
        /// Configure Input for this Entity
        /// </summary>
        void ConfigureInput();
        /// <summary>
        /// Suspends this entity from all Updates
        /// </summary>
        void Suspend();
        /// <summary>
        /// Resume this entities updates
        /// </summary>
        void Resume();
        /// <summary>
        /// Get current suspension state of this entity
        /// </summary>
        /// <returns>Current suspension state</returns>
        bool GetState();
        /// <summary>
        /// Destroy Self
        /// </summary>
        void Destroy();
        /// <summary>
        /// Cleans up the entitity before destruction
        /// </summary>
        void Cleanup();
    }
}
