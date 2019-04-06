using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Prototypes.Characters.Mouse;
using Prototypes.Characters.Triangle;

namespace Prototypes.Levels
{
    public class L3 : Level
    {
        #region Constructor
        public L3() : base()
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


                // Create Moving Triangle
                createdEntity = mEntityManager.newEntity<Triangle>("trianglel", true);
                mSceneManager.newEntity(createdEntity, 1000, 150);
                Removables.Add(createdEntity);

                // Create door
                createdEntity = mEntityManager.newEntity<Door>("door");
                var door1 = createdEntity as IDoor;
                door1.setVars(_sl);
                door1.Initialize("L1");
                mSceneManager.newEntity(createdEntity, 1100, 250); //Change coordinates
                Removables.Add(createdEntity);
            }
        }
        #endregion
    }
}
