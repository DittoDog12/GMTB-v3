using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace The_Infirmary.Levels
{
    public class L8 : Level
    {
		#region Data Members
		#endregion
        #region Constructor
        public L8() : base()
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
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				var asInterface = createdEntity as IDoor;
				//asInterface.Initialize("L9", vector 2); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Chair
				createdEntity = mEntityManager.newEntity<RectangleShape>("Chair");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 160, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
				//Table
				createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				//Bookcase
				createdEntity = mEntityManager.newEntity<RectangleShape>("Bookcase");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
            }
        }
        #endregion
    }
}