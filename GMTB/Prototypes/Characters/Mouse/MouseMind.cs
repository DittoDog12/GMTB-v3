﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Entities.AI;
using GMTB.Interfaces;

namespace Prototypes.Characters.Mouse
{
    public class MouseMind : Mind
    {
        #region Constructor
        public MouseMind(IPhysicalEntity _self) : base(_self)
        {
            mStates.Add("idle", new IdleState(this));
            mStates.Add("persue", new PersueState(this));

            mCurrentState = mStates["idle"];
            
        }
        #endregion
    }
}
