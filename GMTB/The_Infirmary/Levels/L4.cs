using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;

namespace The_Infirmary.Levels
{
    public class L4 : Level
    {
        #region Constructor
        public L4() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/1stFloorL", "Levels/1stFloorR");
            mBackgroundManager.ChangePosition(0, 0);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/walkL", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260);
                Removables.Add(createdEntity.UID, createdEntity);


				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse1/walkR");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse2/walkR");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Doctor
				createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Characters/Doctor/walkR");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Medicine
				createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1180, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Ward
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L2", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2380, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Surgary
				createdEntity = mEntityManager.newEntity<Door>("blank");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 3100, 2600); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Stairs
				createdEntity = mEntityManager.newEntity<LockedDoor>("Objects/lock_closed");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L6", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 80, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 0, -100); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 4800, -100); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 0, 400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 2400, 400); //Change coordinates
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
