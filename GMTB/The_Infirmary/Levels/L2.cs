using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using System;

namespace The_Infirmary.Levels
{
    public class L2 : Level
    {
		#region Data Members
		private Random rand;
		private int mBeds;
		private int mTables;
		#endregion
        #region Constructor
        public L2() : base()
        {
            bg = null;
			rand = new Random(); 
			mBeds = 6;
			mTables = 6;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            if (firstRun == true)
            {
                mBackgroundManager.ChangeBackground("Ward");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				var asInterface = createdEntity as IDoor;
				//asInterface.Initialize("L1", vector 2); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				//// Beds
				//for (int i = 1; i <= mBeds; i++){
				//createdEntity = mEntityManager.newEntity<RectangleShape>("Bed");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
    //            Removables.Add(createdEntity);
				//}

				//Tables
				//for (int i = 1; i <= mTables; i++){
				//createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, rand.Next(min, max), 150); //Change coordinates
    //            Removables.Add(createdEntity);
				//}
            }
        }
        #endregion
    }
}