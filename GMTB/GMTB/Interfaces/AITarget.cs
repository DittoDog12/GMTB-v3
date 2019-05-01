using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for an AI to chase
    /// </summary>
    public interface AITarget
    {
        /// Location of Target
        Vector2 Position { get; }
    }
}
