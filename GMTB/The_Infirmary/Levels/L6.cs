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
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 260);
                Removables.Add(createdEntity.UID, createdEntity);


				// Nurse
				createdEntity = mEntityManager.newEntity<Characters.Nurse.Nurse>("Nurse1");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Doctor
				createdEntity = mEntityManager.newEntity<Characters.Doctor.Doctor>("Doctor");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Matron
				createdEntity = mEntityManager.newEntity<Characters.Matron.Matron>("Matron");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				// Door - Boardroom
				createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L7", true);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 2400, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //// Door - Matrons office
                createdEntity = mEntityManager.newEntity<Door>("Door");
                asInterface = createdEntity as IDoor;
                asInterface.Initialize("L8", true);
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1680, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);


                // Stairs
                createdEntity = mEntityManager.newEntity<Door>("Stair");
				asInterface = createdEntity as IDoor;
                asInterface.Initialize("L9", false);
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 4700, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
                firstRun = false;

            }
        }
        #endregion
    }
}
