using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;

namespace The_Infirmary.Levels
{
    public class L3 : Level
    {
        #region Constructor
        public L3() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            mBackgroundManager.ChangeBackground("Levels/Ward");
            mBackgroundManager.ChangePosition(0, 4000);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 100, 4260);
                Removables.Add(createdEntity.UID, createdEntity);

                //// Exit Door
                createdEntity = mEntityManager.newEntity<Door>("door");
                var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L9", true); //coordinates of players previous location
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 4260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Bed
                createdEntity = mEntityManager.newEntity<RectangleShape>("Objects/bed");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 880, 4260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);
				
				
				// Table
				createdEntity = mEntityManager.newEntity<RectangleShape>("Objects/table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 850, 4260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Bedside Table
                createdEntity = mEntityManager.newEntity<RectangleShape>("Objects/bedsidetable");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1000, 2260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                ////Collectable Object
                //createdEntity = mEntityManager.newEntity<Collectable>("Item");
                //           // X, Y coordinates
                //            mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
                //            Removables.Add(createdEntity.UID, createdEntity);


            }
        }
        #endregion
    }
}