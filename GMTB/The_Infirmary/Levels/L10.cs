using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Prototypes.Characters.Mouse;
using Prototypes.Characters.Triangle;

namespace The_Infirmary.Levels
{
    public class L10 : Level
    {
		#region Data Members
		private random rand;
		private int mChair;
		#endregion
        #region Constructor
        public L10() : base()
        {
            bg = null;
			rand = new random; 
			mChair = 8;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            if (firstRun == true)
            {
                mBackgroundManager.ChangeBackground("BoardRoom");

                // Create Player
				// <Entity Type>("Texture", needs input?)
                createdEntity = mEntityManager.newEntity<Characters.Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);
				
				// Exit Door
				createdEntity = mEntityManager.newEntity<Door>("ExitDoor");
				var asInterface = createdEntity as IDoor;
				asInterface.initialise("L9", vector 2); //coordinates of players previous location
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				// 
				for (int i = 1; i <= mChair; i++){
				createdEntity = mEntityManager.newEntity<squareShape>("Chair");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, rand.next(min, max), 150); //Change coordinates
                Removables.Add(createdEntity);
				}

				createdEntity = mEntityManager.newEntity<squareShape>("Table");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 150, 150); //Change coordinates
                Removables.Add(createdEntity);
				
				//Collectable Object
				createdEntity = mEntityManager.newEntity<Collectable>("Item");
               // X, Y coordinates
                mSceneManager.newEntity(createdEntity, 170, 150); //Change coordinates
                Removables.Add(createdEntity);
            }
        }
        #endregion
    }
}