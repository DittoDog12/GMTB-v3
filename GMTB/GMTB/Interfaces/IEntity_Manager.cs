using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Entity Manager
    /// </summary>
    public interface IEntity_Manager
    {
        //IDictionary<int, IEntity> Entities { get; }
        /// List of all entities
        IDictionary<int, IEntity> AllEntities { get; }

        /// <summary>
        /// Get a specified Entity
        /// </summary>
        /// <param name="_index">UID of Entity to locate</param>
        /// <returns>Entity of specifed UID</returns>
        IEntity GetEntity(int _index);
        /// <summary>
        /// Get total number of Entities
        /// </summary>
        /// <returns>Total number of all entities</returns>
        int TotalEntities();
        /// <summary>
        /// Main Entity Creation routine
        /// </summary>
        /// <typeparam name="T">Entity Type to Create, usually IEntity</typeparam>
        /// <returns>Created Entity</returns>
        IEntity newEntity<T>() where T : IEntity, new();
        /// <summary>
        /// Main Entity Creation routine Override
        /// Allows specifying Texture path
        /// </summary>
        /// <typeparam name="T">Entity Type to Create, usually IEntity</typeparam>
        /// <param name="_path">Path to Texture</param>
        /// <returns>Created Entity</returns>
        IEntity newEntity<T>(string _path) where T : IEntity, new();
        /// <summary>
        /// Main Entity Creation routine Override
        /// Sets Input needed
        /// </summary>
        /// <typeparam name="T">Entity Type to Create, usually IEntity</typeparam>
        /// <param name="_path">Path to Texture</param>
        /// <param name="_inputReq">Set True to enable Input</param>
        /// <returns>Created Entity</returns>
        IEntity newEntity<T>(string _path, bool _inputReq) where T : IEntity, new();
        /// <summary>
        /// Main Entity Creation routine Override
        /// Creates a utility Entity insteead
        /// </summary>
        /// <typeparam name="T">Entity Type to Create, usually IEntity</typeparam>
        /// <param name="_util">Set true to make the entity a Utility Entity</param>
        /// <returns>Created Entity</returns>
        IEntity newEntity<T>(bool _util) where T : IEntity, new();
        /// <summary>
        /// Destroy a specified Entity
        /// </summary>
        /// <param name="uid">UID of entity to destroy</param>
        void DestroyEntity(int uid);
        /// <summary>
        /// Clears all entities from the master list
        /// </summary>
        void ClearAll();
        /// <summary>
        /// Create Sound entity
        /// </summary>
        /// <typeparam name="T"> Type of IEntity to create </typeparam>
        /// <param name="_path"> Path to sound file </param>
        /// <param name="_interval"> Interval to trigger sound </param>
        /// <param name="_oneshot"> Set true if sound should only trigger once </param>
        /// <param name="_loop">Set if the sound should loop</param>
        /// <param name="_vol">Set sound volume</param>
        /// <returns> The new IEntity </returns>
        IEntity newEntity<T>(string _path, float _interval, bool _oneshot, bool _loop, float _vol) where T : IEntity, new();
    }
}
