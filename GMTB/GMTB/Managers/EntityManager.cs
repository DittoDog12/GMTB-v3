using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Managers
{
    public class EntityManager : IEntityManager
    {
        #region Data Members
        // Create Master List for all entities
        private IDictionary<int, IEntity> mEntities = new Dictionary<int, IEntity>();
        // Create UID 
        private int UID;

        // Create Deletion List
        private IDictionary<int, IEntity> mDeletions;
        #endregion

        #region Accessors
        //public IDictionary<int, IEntity> Entities
        //{
        //    get { return Entities; }
        //}
        public IEntity GetEntity(int _index)
        {
            return mEntities[_index];
        }
        public int TotalEntities()
        {
            return mEntities.Count;
        }
        #endregion

        #region Constructor
        public EntityManager()
        {
            // Set UID counter to 0 for first object
            UID = 1;
            // Initialise Deletion List
            mDeletions = new Dictionary<int, IEntity>();
        }
        #endregion

        #region Methods

        private void setEntityVars(IEntity _entity)
        {
            // Set the entities UID
            _entity.setVars(UID);
            // Increment the UID
            UID++;
        }
        private void setEntityVars(IEntity _entity, string _path)
        {
            // Set the entities Texture Path
            _entity.setVars(_path);
        }

        /// <summary>
        /// Main Entity creation method
        /// </summary>
        /// <typeparam name="T"> Type of IEntity to create </typeparam>
        /// <returns> IEntity of new entity </returns>
        public IEntity newEntity<T>() where T : IEntity, new()
        {
            // Create an entity of the type specifed by the Kernel
            IEntity createdEntity = new T();
            // Store in the list
            mEntities.Add(UID, createdEntity);
            // Set the entities variables
            setEntityVars(createdEntity);
            // Return the new entity to the kernel
            return createdEntity;
        }
        /// <summary>
        /// Main Entity creation method
        /// </summary>
        /// <typeparam name="T"> Type of IEntity to create </typeparam>
        /// <param name="_path"> Texture Path for the new entity</param>
        /// <returns> IEntity of new entity </returns>
        public IEntity newEntity<T>(string _path) where T : IEntity, new()
        {
            // Call parent to create Entity type
            IEntity createdEntity = newEntity<T>();
            // Set the entities Texture
            createdEntity.setVars(_path);
            // Return Created Entity
            return createdEntity;
        }
        #endregion
    }

}
