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
    public class Scene_Manager : IScene_Manager
    {
        #region Data Members
        private IDictionary<int, IEntity> mEntities;
        private IDictionary<int, IPhysicalEntity> mSceneGraph;

        private IEntity_Manager mEntityManager;
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
        public void newEntity(IEntity _createdEntity, Vector2 _pos)
        {
            newEntity(_createdEntity, _pos.X, _pos.Y);
        }
        public void Update(GameTime _gameTime)
        {
            foreach(KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {
                mEntities.Add(_keypair.Key, _keypair.Value);

            }
            foreach(KeyValuePair<int, IEntity> _keypair in mEntities)
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
        public void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            foreach (KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {
                var _entity = _keypair.Value as IPhysicalEntity;
                if (_entity != null)
                    mSceneGraph.Add(_keypair.Key, _entity);
            }
           
            _spriteBatch.Begin();
            mBackgroundManager.Draw(_spriteBatch,  _gameTime);

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
            _spriteBatch.End();
        }
        // For use if camera is to follow player
        public void Draw(SpriteBatch _spriteBatch, GameTime _gameTime, Camera2D _cam, GraphicsDevice _graDev)
        {
            foreach (KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {
                var _entity = _keypair.Value as IPhysicalEntity;
                if (_entity != null)
                    mSceneGraph.Add(_keypair.Key, _entity);
            }

            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,
                null, null, null, null, _cam.GetTransform(_graDev));

            mBackgroundManager.Draw(_spriteBatch,  _gameTime);

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
            _spriteBatch.End();
        }
    }
}
