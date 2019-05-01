using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for Static objects
    /// </summary>
    public interface IStaticObject
    {
        /// Current texture name
        string TextureName { get; }
    }
}
