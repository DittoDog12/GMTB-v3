using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
namespace The_Infirmary.Levels
{
    public class L6 : Level
    {
        #region Constructor
        public L6() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/GroundFloorL", "Levels/GroundFloorR");
            mBackgroundManager.ChangePosition(0, 0);

            if (firstRun == true)
            {
                // Create Player
                // <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 260);
                mLevelEntities.Add(createdEntity.UID, createdEntity);


                // Nurse
                createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Characters/Nurse1/standL");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2000, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Doctor
                createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Characters/Doctor/standR");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Matron
                createdEntity = mEntityManager.newEntity<Characters.Matron.Matron>("Characters/Matron/standR");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2200, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Door - Boardroom
                createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L7", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2380, 300); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                ////// Door - Matrons office
                //createdEntity = mEntityManager.newEntity<Door>("blank");
                //asInterface = createdEntity as IDoor;
                //asInterface.Initialize("L8", true);
                //// X, Y coordinates
                //mSceneManager.newEntity(createdEntity, 1680, 260); //Change coordinates
                //mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Stairs
                createdEntity = mEntityManager.newEntity<LockedDoor>("Objects/lock_closed");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L9", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, -200, -100); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 4800, -100); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, -40, 400); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 2360, 400); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                //Footsteps
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/footsteps", 3f, true, false, 1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                firstRun = false;

            }
        }
        #endregion
    }
}
