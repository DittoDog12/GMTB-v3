using GMTB.CollisionSystem;
using GMTB.InputSystem;
using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GMTB.Managers
{
    public class Entity_Manager : IEntity_Manager
    {
        #region Data Members
        // Create Master List for all entities
        private IDictionary<int, IEntity> mEntities = new Dictionary<int, IEntity>();
        // Create UID 
        private int UID;

        // Create Deletion List
        private IDictionary<int, IEntity> mDeletions;

        private IContent_Manager mContentManager;
        private IServiceLocator mServiceLocator;
        #endregion

        #region Accessors
        //public IDictionary<int, IEntity> Entities
        //{
        //    get { return Entities; }
        //}
        public IEntity GetEntity(int _index)
        {
            try
            {
                return mEntities[_index];
            }
            catch
            {
                return null;
            }
        }
        public IDictionary<int, IEntity> AllEntities
        {
            get { return mEntities; }
        }
        public int TotalEntities()
        {
            return mEntities.Count;
        }
        #endregion

        #region Constructor
        public Entity_Manager(IServiceLocator _sl, IContent_Manager _cm)
        {
            // Set UID counter to 0 for first object
            UID = 1;
            // Initialise Deletion List
            mDeletions = new Dictionary<int, IEntity>();
            mServiceLocator = _sl;
            mContentManager = _cm;
        }
        #endregion

        #region Methods

        private void setEntityVars(IEntity _entity)
        {
            // Set the entities UID
            _entity.setVars(UID, mServiceLocator);
            // Increment the UID
            UID++;
        }
        private void setEntityVars(IPhysicalEntity _entity, string _path)
        {
            // Set the entities Texture Path
            _entity.setVars(_path, mContentManager);
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
            IEntity _createdEntity = newEntity<T>();
            // Change the Entity to a PhysicalEntity
            IPhysicalEntity _entity = _createdEntity as IPhysicalEntity;
            // Call the Content Manager to apply the entities texture
            _entity.Texture = mContentManager.ApplyTexture(_path);
            setEntityVars(_entity, _path);
            // Return Created Entity
            return _createdEntity;
        }
        public IEntity newEntity<T>(string _path, bool _inputReq) where T : IEntity, new()
        {
            // Call parent to create Entity type
            IEntity _createdEntity = newEntity<T>(_path);
            // Inform the new entity of the Input Manager
            _createdEntity.ConfigureInput();
            // Return Created Entity
            return _createdEntity;
        }
        public IEntity newEntity<T>(bool _util) where T : IEntity, new()
        {
            // Call parent to create entity type
            IEntity _createdEntity = newEntity<T>();
            // Cast entity to Utility Class
            var asInterface = _createdEntity as IUtility_Entity;
            // Pass other managers to the new utility
            asInterface.setVars(mServiceLocator);
            // Return Created Entity
            return _createdEntity;
        }
        public void DestroyEntity(int _uid)
        {
            mEntities.Remove(_uid);
        }
        public void ClearAll()
        {
            mEntities.Clear();
        }
        #endregion
    }

}
