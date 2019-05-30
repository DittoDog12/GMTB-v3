using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;

namespace The_Infirmary.Levels
{
    public class L1 : Level
    {
        #region Constructor
        public L1() : base(){ }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            mBackgroundManager.ChangeBackground("Levels/2ndFloorL", "Levels/2ndFloorR");
            mBackgroundManager.ChangePosition(0, 0);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 280);
                Removables.Add(createdEntity.UID, createdEntity);

				// Old Man
				createdEntity = mEntityManager.newEntity<Characters.OldMan.OldMan>("Characters/OldMan/walkL");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 150, 280); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Nurse
                createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse1/walkL");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 280); //Change coordinates
                createdEntity.setVars("nurse");
                Removables.Add(createdEntity.UID, createdEntity);

                // Door
                createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 790, 280); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L3", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1744, 280); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2485, 280); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<LockedDoor>("Objects/lock_closed");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L4", false);               
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4666, 300); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 0, 400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Floor 2
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 2400, 400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, -200, -100); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 4800, -100); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 2360, 400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity.UID, createdEntity);

                firstRun = false;
            }            
        }
        #endregion
    }
}
