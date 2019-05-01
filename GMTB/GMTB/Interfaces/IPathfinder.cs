using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    /// <summary>
    /// Interface for pathfinder
    /// </summary>
    public interface IPathfinder
    {
        /// Size of pathfinder area
        Rectangle Size { get; }
        /// Array of nodes and weights
        byte[,] Weight { get; set; }

        /// <summary>
        /// Main Pathfinder routine
        /// </summary>
        /// <param name="_start">Start point</param>
        /// <param name="_end">End Point</param>
        /// <returns>List of nodes to navigate via</returns>
        List<Point> FindPath(Point _start, Point _end);
    }
}
