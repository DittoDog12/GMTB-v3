using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.Managers;
using System;
using GMTB.CollisionSystem;
using The_Infirmary;

namespace The_Infirmary.Levels
{
    public class L9 : Level
    {
        #region Constructor
        public L9() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Basement");
            mBackgroundManager.ChangePosition(0, 0);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerL", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260);
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Matron
				createdEntity = mEntityManager.newEntity<Characters.Matron.Matron>("Matron");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				//// Door - Freezer
				//createdEntity = mEntityManager.newEntity<Door>("Door");
				//var asInterface = createdEntity as IDoor;
    //            asInterface.Initialize("L13");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
    //            Removables.Add(createdEntity.UID, createdEntity);
				
				//// Door - Victory
				//createdEntity = mEntityManager.newEntity<Door>("Door");
				//asInterface = createdEntity as IDoor;
    //            asInterface.Initialize("L14");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
    //            Removables.Add(createdEntity.UID, createdEntity);
				
				//// Stairs
				//createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				//asInterface = createdEntity as IDoor;
    //            asInterface.Initialize("L12");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
    //            Removables.Add(createdEntity.UID, createdEntity);
				
				//Tables
				//for (int i = 1; i <= mTable; i++)
    //            {
				//createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
    //            Removables.Add(createdEntity.UID, createdEntity);
				//}
				
				//Cart
				//for (int i = 1; i <= mCart; i++){
				//createdEntity = mEntityManager.newEntity<RectangleShape>("Cart");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
    //            Removables.Add(createdEntity.UID, createdEntity);
				//}
				
                firstRun = false;

            }
        }
        #endregion
    }
}
