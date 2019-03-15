﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface ILevel
    {
        string Background { get; }
        string LvlID { get; }
        bool FirstRun { set; }

        void Initialise(IScene_Manager _sm, IEntity_Manager _em, IBackground_Manager _bm);
    }
}
