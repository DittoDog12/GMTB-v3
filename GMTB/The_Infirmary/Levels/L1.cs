using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;

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
                mBackgroundManager.ChangeBackground("Levels/2ndFloorL", "Levels/2ndFloorR");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 260);
                Removables.Add(createdEntity.UID, createdEntity);

				// Old Man
				createdEntity = mEntityManager.newEntity<Characters.OldMan.OldMan>("Characters/OldMan/Front");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse1/Right");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 840, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L3", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1790, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2525, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4000, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
                firstRun = false;

            }            
        }
        #endregion
    }
}
