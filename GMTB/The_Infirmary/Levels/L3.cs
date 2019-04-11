using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;

namespace The_Infirmary.Levels
{
    public class L3 : Level
    {
		#region Data Members
		#endregion
        #region Constructor
        public L3() : base()
        {
            bg = null;	
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            if (firstRun == true)
            {
                mBackgroundManager.ChangeBackground("MatronsOffice");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);
				
				//// Exit Door
				//createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				//var asInterface = createdEntity as IDoor;
				//asInterface.Initialize("L9", vector 2); //coordinates of players previous location
    //           // X, Y coordinates
    //            mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
    //            Removables.Add(createdEntity);
				
				// Bed
				createdEntity = mEntityManager.newEntity<RectangleShape>("Bed");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 160, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				
				//Table
				createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
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