using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using System;

namespace The_Infirmary.Levels
{
    public class L5 : Level
    {
		#region Data Members
		private Random rand;
		private int mBeds;
		private int mTables;
		#endregion
        #region Constructor
        public L5() : base()
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
                mBackgroundManager.ChangeBackground("Surgery");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				var asInterface = createdEntity as IDoor;
				//asInterface.Initialize("L5", vector 2); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);

				//Surgery Table
				createdEntity = mEntityManager.newEntity<RectangleShape>("SurgeryTable");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				////Collectable Object
				//createdEntity = mEntityManager.newEntity<Collectable>("Item");
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
    //            Removables.Add(createdEntity);

            }
        }
        #endregion
    }
}