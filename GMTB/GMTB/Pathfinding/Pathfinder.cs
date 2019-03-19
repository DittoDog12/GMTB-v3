using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB.Interfaces;

namespace GMTB.Pathfinding
{
    public class Pathfinder : IPathfinder
    {
        #region Data Members
        private List<Point> mOpenList;
        private List<Point> mClosedList;

        private Rectangle mSize;

        private byte[,] mWeight;
        #endregion

        #region Accessors
        public Rectangle Size
        {
            get { return mSize; }
        }
        public byte[,] Weight
        {
            get { return mWeight; }
            set { mWeight = value; }
        }
        #endregion

        #region Constructor
        public Pathfinder()
        {
            int x = (int)Global.ScreenSize.X;
            int y = (int)Global.ScreenSize.Y;
            mSize = new Rectangle(0, 0, x, y);

        }
        public Pathfinder(int x, int y, byte[,] _Weight)
        {
            mSize = new Rectangle(0, 0, x, y);

            mWeight = _Weight;

            //mWeight = new byte[x, y];

            //for (var i = 0; i < x; i++)
            //{
            //    for (var j = 0; j < y; j++)
            //    {
            //        mWeight[i, j] = _Weight;
            //    }
            //}
        }
        #endregion 

        #region Methods
        /// <summary>
        /// Find the shortest path between two points
        /// </summary>
        /// <param name="_start">Start position</param>
        /// <param name="_end">End Position</param>
        /// <returns>List of Points that comprise the shortest path</returns>
        public List<Point> FindPath(Point _start, Point _end)
        {

            //mStart = start;
            //mEnd = end;

            // Initialize the lists
            // Nodes that have been analyzed
            mClosedList = new List<Point>();
            // Nodes that have been identified as a neighbor but not fully analyzed
            mOpenList = new List<Point> { _start };

            // Dictionary of points, showing the best origin point to each node
            var mCameFrom = new Dictionary<Point, Point>();

            // Dictionary showing how far each node is from the start
            var mCurrentDistance = new Dictionary<Point, int>();

            // Dictionary showing expected distance to end via specified node
            var mPredictDistance = new Dictionary<Point, float>();

            // Add the starting position to the open list
            //mOpenList.Add(new Node(mStart));

            // Initialise the start node with a distance of 0
            // estimated distance of y + x
            mCurrentDistance.Add(_start, 0);
            mPredictDistance.Add(
                _start,
                0 + +Math.Abs(_start.X - _end.X) + Math.Abs(_start.Y - _end.Y)
                );

            // If there are any unanalyzed nodes, analyze them    
            while (mOpenList.Count > 0)
            {
                // Get the current node with the lowest predicted cost
                //Node _shortestNode = mOpenList[0];
                var _currentNode = (from p in mOpenList orderby mPredictDistance[p] ascending select p).First();

                // If it is the finish node, return the complete path
                if (_currentNode.X == _end.X && _currentNode.Y == _end.Y)
                {
                    // Call the path generator
                    return ReconstructPath(mCameFrom, _end);
                }

                // Move the current node from the Open list to Closed list
                mOpenList.Remove(_currentNode);
                mClosedList.Add(_currentNode);

                // Process the vaild Neighbour nodes
                foreach (var _neighbour in GetNeighbourhood(_currentNode))
                {
                    var _tempCurrentDist = mCurrentDistance[_currentNode] + 1;

                    // If we already know a faster way to this neighbour, use it
                    if (mClosedList.Contains(_neighbour) && _tempCurrentDist >= mCurrentDistance[_neighbour])
                    {
                        continue;
                    }

                    // If we dont know a route to this neighbour, or if it's faster store this route
                    if (!mClosedList.Contains(_neighbour) || _tempCurrentDist < mCurrentDistance[_neighbour])
                    {
                        if (mCameFrom.Keys.Contains(_neighbour))
                            mCameFrom[_neighbour] = _currentNode;
                        else
                            mCameFrom.Add(_neighbour, _currentNode);

                        mCurrentDistance[_neighbour] = _tempCurrentDist;
                        mPredictDistance[_neighbour] = mCurrentDistance[_neighbour]
                            + Math.Abs(_neighbour.X - _end.X) + Math.Abs(_neighbour.Y - _end.Y);

                        // If this is a new node, add it to the open list to be processed
                        if (!mOpenList.Contains(_neighbour))
                            mOpenList.Add(_neighbour);
                    }
                }
            }

            // If unable to figure out a path, ABORT
            throw new Exception(
                string.Format(
                    "Unable to find a path, start: {0},{1} end: {2},{3}",
                    _start.X, _start.Y, _end.X, _end.Y));
        }

        /// <summary>
        /// Returns a list of all nodes neighboring the specified node
        /// </summary>
        /// <param name="_node">Node at centre to analyze</param>
        /// <returns>List of nodes that are in this neighbourhood</returns>
        private IEnumerable<Point> GetNeighbourhood(Point _node)
        {
            var _nodes = new List<Point>();

            // Up Node
            // Check the above node is not higher than the top of the grid
            if (_node.Y - 1 >= 0)
                if (mWeight[_node.X, _node.Y - 1] > 0)
                    _nodes.Add(new Point(_node.X, _node.Y - 1));

            // Down Node
            //
            if (_node.Y + 1 <= 28)
                if (mWeight[_node.X, _node.Y + 1] > 0)
                    _nodes.Add(new Point(_node.X, _node.Y + 1));

            // Left Node
            if (_node.X - 1 >= 0)
                if (mWeight[_node.X - 1, _node.Y] > 0)
                    _nodes.Add(new Point(_node.X - 1, _node.Y));

            // Right Node
            if (_node.X + 1 <= 17)
                if (mWeight[_node.X + 1, _node.Y] > 0)
                    _nodes.Add(new Point(_node.X + 1, _node.Y));

            return _nodes;
        }

        /// <summary>
        /// Processes a list of valid paths and returns a coherent path to the current node
        /// </summary>
        /// <param name="_cameFrom">Dictionary of nodes and the origin to that node</param>
        /// <param name="_current">Destination node to find</param>
        /// <returns>Shortest from start to destination</returns>
        private List<Point> ReconstructPath(Dictionary<Point, Point> _cameFrom, Point _current)
        {

            if (!_cameFrom.Keys.Contains(_current))
                return new List<Point> { _current };

            var _path = ReconstructPath(_cameFrom, _cameFrom[_current]);
            _path.Add(_current);
            return _path;
        }
        #endregion
    }
}
