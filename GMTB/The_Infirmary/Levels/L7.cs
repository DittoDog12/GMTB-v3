using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using System;
using System.Collections.Generic;

namespace The_Infirmary.Levels
{
    public class L7 : Level
    {
		#region Data Members
		private Random rand;
		private int mChair;
		#endregion

        #region Constructor
        public L7() : base()
        {
			rand = new Random(); 
			mChair = 8;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/Boardroom");
            mBackgroundManager.ChangePosition(0, 2000);


            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 20, 2260);
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
				asInterface.Initialize("L6", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 20, 2260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
			
                //Collectable Object
                createdEntity = mEntityManager.newEntity<CollectableItem>("Objects/key");
                ICollectableItem _item = createdEntity as ICollectableItem;
                foreach (KeyValuePair<int, IEntity> _keyPair in mEntityManager.AllEntities)
                {
                    ILockedDoor _door = _keyPair.Value as ILockedDoor;
                    if (_door != null)
                    {
                        _item.SetTarget(_door);
                        break;
                    }
                }
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 2360); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, -40, 2400); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //Footsteps
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/footsteps", 3f, true, false, 1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                firstRun = false;
            }
        }
        #endregion
    }
}