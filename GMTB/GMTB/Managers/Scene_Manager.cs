using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GMTB.Managers
{
    /// <summary>
    /// Scene Manager, Controls positioning of new Entities, update and draw of all entities
    /// </summary>
    public class Scene_Manager : IScene_Manager
    {
        #region Data Members
        /// Dictionary of all active entities
        private IDictionary<int, IEntity> mEntities;
        /// Entities to draw
        private IDictionary<int, IPhysicalEntity> mSceneGraph;

        /// Reference to the Entity Manager
        private IEntity_Manager mEntityManager;
        /// Reference to the Background manager
        private IBackground_Manager mBackgroundManager;

        //StorageDevice device;
        //string containerName = "GMTBSaveData";
        //string filename = "InfirmarySave.sav";
        #endregion

        #region Accessors
        //public IDictionary<int, IEntity> Entities
        //{
        //    get { return mEntities; }
        //}

        //public IDictionary<int, IEntity> SceneGraph
        //{
        //    get { return mSceneGraph; }
        //}
        #endregion

        #region Constructor   
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_em">Reference to the Entity Manager</param>
        /// <param name="_bm">Reference to the Background manager</param>
        public Scene_Manager(IEntity_Manager _em, IBackground_Manager _bm)
        {
            // Initialise Entity List
            //mEntities = em.Entities;
            mEntityManager = _em;
            mBackgroundManager = _bm;
            mSceneGraph = new Dictionary<int, IPhysicalEntity>();
            mEntities = new Dictionary<int, IEntity>();
        }
        #endregion
        /// <summary>
        /// Position an entity at specifed coordinates
        /// </summary>
        /// <param name="_createdEntity">Entity to position</param>
        /// <param name="_x">X Coordinate</param>
        /// <param name="_y">Y Coordinate</param>
        public void newEntity(IEntity _createdEntity, float _x, float _y)
        {
            // Add the new entity to the SceneManagers entity list
            //mEntities.Add(createdEntity);

            //mSceneGraph.Add(_createdEntity.UID, _createdEntity);

            // Set the entities initial position
            var _entity = _createdEntity as IPhysicalEntity;
            if (_entity != null)
                _entity.setDefaultPos(new Vector2(_x, _y));

        }
        /// <summary>
        /// Position an entity at specifed coordinates
        /// </summary>
        /// <param name="_createdEntity">Entitiy to position</param>
        /// <param name="_pos">Vector Coordinates</param>
        public void newEntity(IEntity _createdEntity, Vector2 _pos)
        {
            newEntity(_createdEntity, _pos.X, _pos.Y);
        }
        /// <summary>
        /// Main Update Loop
        /// Gets all active entities from the Entity managers master list and runs their Update Methods
        /// </summary>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Update(GameTime _gameTime)
        {
            // Add each entity to a second list, check if the Entity is active or not
            foreach (KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {
                if (_keypair.Value.GetState())
                    mEntities.Add(_keypair.Key, _keypair.Value);
            }
            foreach (KeyValuePair<int, IEntity> _keypair in mEntities)
            {
                _keypair.Value.Update(_gameTime);
            }
            mEntities.Clear();
            //for (int i = 1; i <= mEntityManager.TotalEntities(); i++)
            //{

            //    //var _entity = mEntityManager.GetEntity(i) as IPhysicalEntity;
            //    mEntityManager.GetEntity(i).Update(_gameTime);
            //    //_entity.Update(_gameTime);
            //}


        }
        /// <summary>
        /// Main Draw Loop
        /// Gets all active physical entities from the Entity managers master list and run their Draw Methods
        /// </summary>
        /// <param name="_spriteBatch">Reference to the SpriteBatch</param>
        /// <param name="_gameTime">Reference to the current GameTime</param>
        public void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            // Add all entities to the SceneGraph, check that they are capable of being drawn first.
            foreach (KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {
                var _entity = _keypair.Value as IPhysicalEntity;
                if (_entity != null)
                    mSceneGraph.Add(_keypair.Key, _entity);
            }

            // Call draw method for each Entity if entity is visible   
            foreach (KeyValuePair<int, IPhysicalEntity> _keypair in mSceneGraph)
            {

                _keypair.Value.Draw(_spriteBatch, _gameTime);
            }

            //for (int i = 1; i <= mEntityManager.TotalEntities(); i++)
            //{
            //    var _entity = mEntityManager.GetEntity(i) as IPhysicalEntity;
            //    if (_entity != null)
            //        _entity.Draw(_spriteBatch,  _gameTime);
            //}

            mSceneGraph.Clear();
        }
    }
}
