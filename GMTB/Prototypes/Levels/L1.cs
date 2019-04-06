using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Prototypes.Characters.Mouse;
using Prototypes.Characters.Triangle;

namespace Prototypes.Levels
{
    public class L1 : Level
    {
        #region Constructor
        public L1() : base()
        {
            bg = null;
        }
        #endregion

        #region Methods
        public override void Initialise(IServiceLocator _sl)
        {
            base.Initialise(_sl);

            if (firstRun)
            {
                mBackgroundManager.ChangeBackground("Maze");
                firstRun = false;

                // Create Player
                createdEntity = mEntityManager.newEntity<Characters.Player>("playerR", true);
				// X, Y coordinates
                mSceneManager.newEntity(createdEntity, 700, 150);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = mEntityManager.newEntity<TriangleShape>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 100, 400);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = mEntityManager.newEntity<TriangleShape>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 200, 400);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = mEntityManager.newEntity<TriangleShape>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 300, 100);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = mEntityManager.newEntity<TriangleShape>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 300, 250);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = mEntityManager.newEntity<TriangleShape>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 600, 50);
                Removables.Add(createdEntity);

                // Create large square
                createdEntity = mEntityManager.newEntity<RectangleShape>("squarelorge", true);
                mSceneManager.newEntity(createdEntity, 300, 300);
                Removables.Add(createdEntity);
               
                // Create mouse
                createdEntity = mEntityManager.newEntity<Mouse>("mouseleft", true);
                mSceneManager.newEntity(createdEntity, 1200, 700);
                Removables.Add(createdEntity);

                // Create Cheese Spawner
                createdEntity = mEntityManager.newEntity<CheeseSpawner>(true);
                var asInterface = createdEntity as IUtility_Entity;
                asInterface.setVars(_sl);
                asInterface.Initialize();
                mSceneManager.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity);

                // Create Moving Triangle
                createdEntity = mEntityManager.newEntity<Triangle>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 1000, 150);
                Removables.Add(createdEntity);

                // Create door
                createdEntity = mEntityManager.newEntity<Door>("door");
                var door1 = createdEntity as IDoor;
                door1.setVars(_sl);
                door1.Initialize("L2");
                mSceneManager.newEntity(createdEntity, 1100, 250); //Change coordinates
                Removables.Add(createdEntity);

                // Create door
                createdEntity = mEntityManager.newEntity<Door>("door");
                var door2 = createdEntity as IDoor;
                door2.setVars(_sl);
                door2.Initialize("L3");
                mSceneManager.newEntity(createdEntity, 1100, 550); //Change coordinates
                Removables.Add(createdEntity);
            }
        }
        #endregion
    }
}
