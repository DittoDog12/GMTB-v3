using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace The_Infirmary.Levels
{
    public class L8 : Level
    {
        #region Constructor
        public L8() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("MatronsOffice");
            mBackgroundManager.ChangePosition(0, 4000);


            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/standR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 4260);
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
				//asInterface.Initialize("L9", vector 2); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 4260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				// Chair
				createdEntity = mEntityManager.newEntity<RectangleShape>("Chair");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 160, 4260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				
				//Table
				createdEntity = mEntityManager.newEntity<RectangleShape>("Table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 4260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);
				
				//Bookcase
				createdEntity = mEntityManager.newEntity<RectangleShape>("Bookcase");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 4260); //Change coordinates
                mLevelEntities.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, -40, 4400); //Change coordinates
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