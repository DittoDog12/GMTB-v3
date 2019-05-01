using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for the Service Locator
    /// </summary>
    public interface IServiceLocator
    {
        /// <summary>
        /// Get a service/manager of the specified type
        /// </summary>
        /// <typeparam name="T">Service/Manager to locate</typeparam>
        /// <returns>The located Service/Manager</returns>
        T GetService<T>();
    }
}
