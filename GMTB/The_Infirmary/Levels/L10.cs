using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using System;
using Microsoft.Xna.Framework;

namespace The_Infirmary.Levels
{
    public class L10: Level
    {
		#region Data Members
		private Random rand;
		private int mBeds;
		private int mTables;
		#endregion

        #region Constructor
        public L10() : base()
        {
			rand = new Random(); 
			mBeds = 6;
			mTables = 6;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/Ward");
            mBackgroundManager.ChangePosition(0, 4000);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 4260);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, -200, 3890); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 1919, 3890); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Exit Door
                createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
				asInterface.Initialize("L4", true); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 4260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //// Beds
                for (int i = 1; i <= mBeds; i++)
                {
                    createdEntity = mEntityManager.newEntity<SolidObject>("Objects/bed");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 1850), 4260); //Change coordinates
                    mLevelEntities.Add(createdEntity.UID, createdEntity);
                }

                //Tables
                for (int i = 1; i <= mTables; i++)
                {
                    createdEntity = mEntityManager.newEntity<SolidObject>("Objects/bedsidetable");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 1850), 4260); //Change coordinates
                    mLevelEntities.Add(createdEntity.UID, createdEntity);
                }

                //Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, -40, 4400); //Change coordinates
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