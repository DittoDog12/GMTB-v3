using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.Managers;
using System;
using GMTB.CollisionSystem;
using The_Infirmary;

namespace The_Infirmary.Levels
{
    public class L12 : Level
    {
		#region Data Members
		private Random rand;
		private int mTable;
		private int mCart;
		#endregion

        #region Constructor
        public L12() : base()
        {
            bg = null;
			mTable = 6;
			mCart = 3;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            if (firstRun == true)
            {
                mBackgroundManager.ChangeBackground("Basement");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);
				
				// Matron
				createdEntity = mEntityManager.newEntity<Characters.Matron.Marton>("Matron");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L13");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L14");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L12");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				//Tables
				for (int i = 1; i <= mTable; i++)
                {
				createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
                Removables.Add(createdEntity);
				}
				
				//Cart
				for (int i = 1; i <= mCart; i++){
				createdEntity = mEntityManager.newEntity<RectangleShape>("Cart");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
                Removables.Add(createdEntity);
				}
				
                firstRun = false;

            }
        }
        #endregion
    }
}
