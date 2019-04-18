using GMTB.Abstracts;
using GMTB.CollisionSystem;
using GMTB.Entities;
using GMTB.Interfaces;
using System;

namespace The_Infirmary.Levels
{
    public class L5 : Level
    {
        #region Constructor
        public L5() : base() { }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            mBackgroundManager.ChangeBackground("Levels/Surgery");
            mBackgroundManager.ChangePosition(0, 2000);

            if (firstRun == true)
            {
                // Create Player
                // <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerR", true);
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 25, 260);
                Removables.Add(createdEntity.UID, createdEntity);

                // Exit Door
                createdEntity = mEntityManager.newEntity<Door>("blank");
                var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true); //coordinates of players previous location
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Surgery Table
                createdEntity = mEntityManager.newEntity<RectangleShape>("blank");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 500, 260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Surgery Table
                createdEntity = mEntityManager.newEntity<RectangleShape>("blank");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1200, 260); //Change coordinates
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