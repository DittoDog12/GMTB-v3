using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB;
using GMTB.Entities;
using GMTB.Interfaces;
using GMTB.CollidableShapes;

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
        public override void Initialise(IScene_Manager sm, IEntity_Manager em)
        {
            if (firstRun == true)
            {
                createdEntity = em.newEntity<Player>("square", true);
                sm.newEntity(createdEntity, 100, 100);
                Removables.Add(createdEntity);
                firstRun = false;


                createdEntity = em.newEntity<TriangleShape>("trianglel", true);
                sm.newEntity(createdEntity, 100, 400);
                Removables.Add(createdEntity);               
                firstRun = false;
            }
        }
        #endregion
    }
}
