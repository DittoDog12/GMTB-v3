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

            mBackgroundManager.ChangeBackground("Levels/Ward");
            mBackgroundManager.ChangePosition(0, 2000);

            if (firstRun == true)
            {
                

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Player>("Characters/Player/playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 10, 2260);
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
                    createdEntity = mEntityManager.newEntity<RectangleShape>("Objects/bed");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 2000), 2260); //Change coordinates
                    Removables.Add(createdEntity.UID, createdEntity);
                }

                //Tables
                for (int i = 1; i <= mTables; i++)
                {
                    createdEntity = mEntityManager.newEntity<RectangleShape>("Objects/bedsidetable");
                    // X, Y coordinates
                    mSceneManager.newEntity(createdEntity, rand.Next(100, 2000), 2260); //Change coordinates
                    Removables.Add(createdEntity.UID, createdEntity);
                }

                firstRun = false;
            }
        }
        #endregion
    }
}