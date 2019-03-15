using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface IPathfinder
    {
        Rectangle Size { get; }
        byte[,] Weight { get; set; }

        List<Point> FindPath(Point _start, Point _end);
    }
}
