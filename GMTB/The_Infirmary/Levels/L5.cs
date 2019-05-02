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
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/Surgery");
            mBackgroundManager.ChangePosition(0, 2000);

            if (firstRun == true)
            {
                // Create Player
                // <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/walkR", true);
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 25, 2260);
                Removables.Add(createdEntity.UID, createdEntity);

                // Exit Door
                createdEntity = mEntityManager.newEntity<Door>("blank");
                var asInterface = createdEntity as IDoor;
                asInterface.Initialize("L5", true); //coordinates of players previous location
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 2260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Surgery Table
                createdEntity = mEntityManager.newEntity<RectangleShape>("blank");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 500, 2260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Surgery Table
                createdEntity = mEntityManager.newEntity<RectangleShape>("blank");
                // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 1200, 2260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                ////Collectable Object
                //createdEntity = mEntityManager.newEntity<Collectable>("Item");
                //           // X, Y coordinates
                //            mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
                //            Removables.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, -40, 2400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity.UID, createdEntity);

                //Footsteps
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/hospital-busy", 3f, true, false, 1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity.UID, createdEntity);

            }
        }
        #endregion
    }
}