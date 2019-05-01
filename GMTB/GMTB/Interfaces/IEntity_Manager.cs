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
    }
}
