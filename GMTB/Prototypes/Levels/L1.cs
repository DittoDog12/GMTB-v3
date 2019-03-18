using GMTB.Abstracts;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollisionSystem;
using Prototypes.Characters.Mouse;

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
        public override void Initialise(IScene_Manager _sm, IEntity_Manager _em, IBackground_Manager _bm)
        {
            if (firstRun == true)
            {
                _bm.ChangeBackground("Maze");

                // Create Player
                createdEntity = _em.newEntity<Player>("square", true);
                _sm.newEntity(createdEntity, 100, 100);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = _em.newEntity<TriangleShape>("trianglel", true);
                _sm.newEntity(createdEntity, 100, 400);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = _em.newEntity<TriangleShape>("trianglel", true);
                _sm.newEntity(createdEntity, 200, 400);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = _em.newEntity<TriangleShape>("trianglel", true);
                _sm.newEntity(createdEntity, 300, 100);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = _em.newEntity<TriangleShape>("trianglel", true);
                _sm.newEntity(createdEntity, 300, 250);
                Removables.Add(createdEntity);

                // Create Triangle
                createdEntity = _em.newEntity<TriangleShape>("trianglel", true);
                _sm.newEntity(createdEntity, 600, 50);
                Removables.Add(createdEntity);

                // Create large square
                createdEntity = _em.newEntity<RectangleShape>("squarelorge", true);
                _sm.newEntity(createdEntity, 300, 300);
                Removables.Add(createdEntity);
               
                // Create mouse
                createdEntity = _em.newEntity<Mouse>("mouseleft", true);
                _sm.newEntity(createdEntity, 700, 500);
                Removables.Add(createdEntity);

                // Create Cheese Spawner
                createdEntity = _em.newEntity<CheeseSpawner>(true);
                var asInterface = createdEntity as IUtility_Entity;
                asInterface.setVars(_sm);
                asInterface.Initialize();
                _sm.newEntity(createdEntity, 0, 0);
                Removables.Add(createdEntity);

                firstRun = false;
            }
        }
        #endregion
    }
}
