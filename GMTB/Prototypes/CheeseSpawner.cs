using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.InputSystem;
using GMTB.Interfaces;
using GMTB.Entities;
using GMTB.Managers;
using Microsoft.Xna.Framework;

namespace Prototypes
{
    public class CheeseSpawner : UtilityEntity
    {
        #region Data Members

        #endregion

        #region Constructor
        public CheeseSpawner()
        {
            
        }
        #endregion

        #region Methods
        public override void Initialize()
        {
            base.Initialize();
            mInputManager.Sub_Mouse(OnMouseClick);
        }
        public override void Update(GameTime _gameTime)
        {
            
        }
        public void OnMouseClick(object source, MouseEvent args)
        {
            IEntity createdEntity = mEntityManager.newEntity<Cheese>("cheese");
            mSceneManager.newEntity(createdEntity, args.currentPos);
        }
        #endregion
    }
}
