using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.InputSystem;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for utility entities
    /// Utility Entites are entites that need to run in the background but do not warrent using a full manager
    /// </summary>
    public interface IUtility_Entity
    {
        /// <summary>
        /// Set core variables
        /// </summary>
        /// <param name="_sl">Reference to Service Locator</param>
        void setVars(IServiceLocator _sl);
        /// <summary>
        /// Initialize routine
        /// </summary>
        void Initialize();
    }
}
