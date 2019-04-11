using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;

namespace The_Infirmary.Levels
{
    public class L4 : Level
    {
        #region Constructor
        public L4() : base()
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
                mBackgroundManager.ChangeBackground("FirstFloor");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);


				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Nurse1");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Nurse2");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Doctor
				createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Doctor");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L6");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L7");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L8");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<Door>("Stair");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L9");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				
                firstRun = false;

            }
        }
        #endregion
    }
}
