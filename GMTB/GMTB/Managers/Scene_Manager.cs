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
        private IDictionary<int, IEntity> mSceneGraph;

        private IEntity_Manager mEntityManager;
        private IBackground_Manager mBackgroundManager;

        //StorageDevice device;
        //string containerName = "GMTBSaveData";
        //string filename = "InfirmarySave.sav";
        #endregion

        #region Accessors
        public IDictionary<int, IEntity> Entities
        {
            get { return mEntities; }
        }

        public IDictionary<int, IEntity> SceneGraph
        {
            get { return mSceneGraph; }
        }
        #endregion

        #region Constructor      
        public Scene_Manager(IEntity_Manager _em, IBackground_Manager _bm)
        {
            // Initialise Entity List
            //mEntities = em.Entities;
            mEntityManager = _em;
            mBackgroundManager = _bm;
            mSceneGraph = new Dictionary<int, IEntity>();
        }
        #endregion

        public void newEntity(IEntity _createdEntity, int _x, int _y)
        {
            // Add the new entity to the SceneManagers entity list
            //mEntities.Add(createdEntity);

            mSceneGraph.Add(_createdEntity.UID, _createdEntity);

            // Set the entities initial position
            var _entity = _createdEntity as IPhysicalEntity;
            _entity.setDefaultPos(new Vector2(_x, _y));

        }
        public void Update(GameTime _gameTime)
        {
            for (int i = 1; i <= mEntityManager.TotalEntities(); i++)
            {
                var _entity = mEntityManager.GetEntity(i) as IPhysicalEntity;
                //mEntities[i].Update(_gameTime);
                _entity.Update(_gameTime);
            }
                

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();
            mBackgroundManager.Draw(_spriteBatch);

            // Call draw method for each Entity if entity is visible        
            for (int i = 1; i <= mEntityManager.TotalEntities(); i++)
            {
                var _entity = mEntityManager.GetEntity(i) as IPhysicalEntity;
                _entity.Draw(_spriteBatch);
            }
                

            _spriteBatch.End();
        }
        // For use if camera is to follow player
        public void Draw(SpriteBatch _spriteBatch, Camera2D cam, GraphicsDevice graDev)
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend,
                null, null, null, null, cam.GetTransform(graDev));

            mBackgroundManager.Draw(_spriteBatch);

            // Call draw method for each Entity if entity is visible
            for (int i = 1; i <= mEntityManager.TotalEntities(); i++)
            {
                var _entity = mEntityManager.GetEntity(i) as IPhysicalEntity;
                _entity.Draw(_spriteBatch);
            }

            _spriteBatch.End();
        }
    }
}
