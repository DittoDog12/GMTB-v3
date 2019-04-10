using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Prototypes.Characters.Mouse;
using Prototypes.Characters.Triangle;

namespace The_Infirmary.Levels
{
    public class L1 : Level
    {
        #region Constructor
        public L1() : base()
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
                createdEntity = mEntityManager.newEntity<Characters.Player>("playerR", true);
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
				asInterface.initialise("L6")
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				var asInterface = createdEntity as IDoor;
				asInterface.initialise("L7")
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("Door");
				var asInterface = createdEntity as IDoor;
				asInterface.initialise("L8")
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<Door>("Stair");
				var asInterface = createdEntity as IDoor;
				asInterface.initialise("L9")
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				
                firstRun = false;

            }
        }
        #endregion
    }
}
