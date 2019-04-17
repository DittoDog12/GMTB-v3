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
                mBackgroundManager.ChangeBackground("Levels/1stFloorL", "Levels/1stFloorR");
                mBackgroundManager.ChangePosition(0, 0);

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerL", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260);
                Removables.Add(createdEntity.UID, createdEntity);


				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Nurse1");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Nurse2");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Doctor
				createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Doctor");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Medicine
				createdEntity = mEntityManager.newEntity<Door>("Door");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1180, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Ward
				createdEntity = mEntityManager.newEntity<Door>("Door");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2380, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Surgary
				createdEntity = mEntityManager.newEntity<Door>("Door");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 3100, 2600); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<Door>("Stair");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L6", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 80, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
                firstRun = false;

            }
        }
        #endregion
    }
}
