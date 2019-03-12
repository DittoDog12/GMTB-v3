using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB;
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
        public override void Initialise(ISceneManager sm, IEntityManager em)
        {
            if (firstRun == true)
            {
                createdEntity = em.newEntity<TriangleShape>("trianglel");
                sm.newEntity(createdEntity, 100, 400);
                Removables.Add(createdEntity);

                firstRun = false;
            }
        }
        #endregion
    }
}
