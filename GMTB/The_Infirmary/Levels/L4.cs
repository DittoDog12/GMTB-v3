﻿using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;

namespace The_Infirmary.Levels
{
    public class L4 : Level
    {
        #region Constructor
        public L4() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/1stFloorL", "Levels/1stFloorR");
            mBackgroundManager.ChangePosition(0, 0);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standL", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260);
                mLevelEntities.Add(createdEntity.UID, createdEntity);


                // Nurse
                createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse1/standR");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 3400, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Nurse
                createdEntity = mEntityManager.newEntity<Characters.Nurse2.Nurse>("Characters/Nurse2/standR");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2500, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Doctor
                createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Characters/Doctor/standL");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2200, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //// Door - Medicine
                //createdEntity = mEntityManager.newEntity<Door>("blank");
                //var asInterface = createdEntity as IDoor;
                //            asInterface.Initialize("L5", true);
                //           // X, Y coordinates
                //            mSceneManager.newEntity(createdEntity, 1180, 260); //Change coordinates
                //            Removables.Add(createdEntity.UID, createdEntity);

                // Door - Ward
                createdEntity = mEntityManager.newEntity<Door>("blank");
                var asInterface = createdEntity as IDoor;
                asInterface = createdEntity as IDoor;
                asInterface.Initialize("L10", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2380, 280); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				// Door - Surgary
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 3085, 280); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<LockedDoor>("Objects/lock_closed");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L6", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 80, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, -200, -100); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 4800, -100); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 0, 400); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 2400, 400); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                firstRun = false;

            }
        }
        #endregion
    }
}
