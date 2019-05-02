using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using System;
using Microsoft.Xna.Framework;

namespace The_Infirmary.Levels
{
    public class L2 : Level
    {
		#region Data Members
		private Random rand;
		private int mBeds;
		private int mTables;
		#endregion

        #region Constructor
        public L2() : base()
        {
			rand = new Random(); 
			mBeds = 6;
			mTables = 6;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);
            mBackgroundManager.BlankBackgrounds();
            mBackgroundManager.ChangeBackground("Levels/Ward");
            mBackgroundManager.ChangePosition(0, 2000);

            if (firstRun == true)
            {
                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player.InfirmaryPlayer>("Characters/Player/walkR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 2260);
                Removables.Add(createdEntity.UID, createdEntity);

                // Floor
                createdEntity = mEntityManager.newEntity<StaticObject>("floor");
                mSceneManager.newEntity(createdEntity, 0, 2400); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Left
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, -30, 1890); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Wall Right
                createdEntity = mEntityManager.newEntity<StaticObject>("wall");
                mSceneManager.newEntity(createdEntity, 1919, 1890); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                // Exit Door
                createdEntity = mEntityManager.newEntity<Door>("blank");
				var asInterface = createdEntity as IDoor;
				asInterface.Initialize("L1", true); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 2260); //Change coordinates
                Removables.Add(createdEntity.UID, createdEntity);

                //// Beds
                for (int i = 1; i <= mBeds; i++)
                {
                    createdEntity = mEntityManager.newEntity<StaticObject>("Objects/bed");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 2000), 2260); //Change coordinates
                    Removables.Add(createdEntity.UID, createdEntity);
                }

                //Tables
                for (int i = 1; i <= mTables; i++)
                {
                    createdEntity = mEntityManager.newEntity<StaticObject>("Objects/bedsidetable");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 2000), 2260); //Change coordinates
                    Removables.Add(createdEntity.UID, createdEntity);
                }

                //Background sound
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/rain-and-thunder-heart-beat", 0f, true, true, 0.1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity.UID, createdEntity);

                //Footsteps
                createdEntity = mEntityManager.newEntity<SoundEntity>("Audio/footsteps", 3f, true, false, 1f);
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity.UID, createdEntity);
                firstRun = false;
            }
        }
        #endregion
    }
}