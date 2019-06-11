using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://gamedevelopment.tutsplus.com/tutorials/quick-tip-use-quadtrees-to-detect-likely-collisions-in-2d-space--gamedev-374

namespace GMTB.CollisionSystem
{
    /// <summary>
    /// QuadTree Broadphase Collision Dection
    /// </summary>
    public class Quadtree : IQuadtree
    {
        #region Data Members
        /// Maximum number of objects allowed in a quadtree before it splits
        private int mMaxObjs = 5;
        /// Maximum number of sublevels
        private int mMaxLevels = 5;

        /// Current quadtree level
        private int mLevel;
        /// Objects in this quadtree
        private List<ICollidable> mObjects;
        /// Bounds of the quadtree
        private Rectangle mBounds;
        /// Subnodes of this quadtree
        private IQuadtree[] mNodes; 
        #endregion

        #region Constuctor
        /// <summary>
        /// Main Constructor
        /// </summary>
        /// <param name="_Level">Current Level</param>
        /// <param name="_Bounds">QuadTree Bounds</param>
        public Quadtree(int _Level, Rectangle _Bounds)
        {
            mLevel = _Level;
            mObjects = new List<ICollidable>();
            mBounds = _Bounds;
            mNodes = new Quadtree[4];
        }
        #endregion

        #region Methods
        /// <summary>
        /// Allows Collision Manager to update the quadtrees position
        /// </summary>
        /// <param name="_bounds"></param>
        public void UpdatePosition(Rectangle _bounds)
        {
            mBounds = _bounds;
        }
        /// <summary>
        /// Clears the Quadtree and all subquadtrees
        /// </summary>
        public void Clear()
        {
            mObjects.Clear();

            for (int i = 0; i < mNodes.Length; i++)
            {
                if (mNodes[i] != null)
                {
                    mNodes[i].Clear();
                    mNodes[i] = null;
                }
            }
        }
        /// <summary>
        /// Splits the node into 4 subnodes
        /// </summary>
        private void Split()
        {
            int _subWidth = mBounds.Width / 2;
            int _subHeight = mBounds.Height / 2;

            int _x = mBounds.X;
            int _y = mBounds.Y;

            mNodes[0] = new Quadtree(mLevel + 1, new Rectangle(_x + _subWidth, _y, _subWidth, _subHeight)); // Top Right
            mNodes[1] = new Quadtree(mLevel + 1, new Rectangle(_x, _y, _subWidth, _subHeight)); // Top Left
            mNodes[2] = new Quadtree(mLevel + 1, new Rectangle(_x, _y + _subHeight, _subWidth, _subHeight)); // Bottom Left
            mNodes[3] = new Quadtree(mLevel + 1, new Rectangle(_x + _subWidth, _y + _subHeight, _subWidth, _subHeight)); // Bottom Right
        }
        /// <summary>
        /// Determine which Subtree an objects fits into
        /// -1 means the object cannot complete fit in a child node and is part of the parent node
        /// </summary>
        /// <param name="_rect"> Object to test </param>
        /// <returns> Subtree reference </returns>
        private int GetIndex(Rectangle _rect)
        {
            int _index = -1;
            double _vertMid = mBounds.X + (mBounds.Width / 2);
            double _horiMid = mBounds.Y + (mBounds.Height / 2);

            //Object can completey fit in top quadrants
            bool _topQuad = _rect.Y < _horiMid && _rect.Y + _rect.Height < _horiMid;
            // Object can completely fir within bottom quadrants
            bool _bottomQuad = _rect.Y > _horiMid;

            // Object can compeltely fit within the left quadrants
            if (_rect.X < _vertMid && _rect.X + _rect.Width < _vertMid)
            {
                if (_topQuad)
                    _index = 1;
                else if (_bottomQuad)
                    _index = 2;
            }
            // Object can completly fit within right quadrants
            else if (_rect.X > _vertMid)
            {
                if (_topQuad)
                    _index = 0;
                else if (_bottomQuad)
                    _index = 3;
            }

            return _index;
        }
        /// <summary>
        /// Main process for inserting objects to the quad trees
        /// Splits the tree if the maximum objects is exceeded
        /// </summary>
        /// <param name="_obj"> Collidable object to add to the tree </param>
        public void Insert(ICollidable _obj)
        {
            // Cast the target object to an IPhysicalEntity to access it's location and size
            IPhysicalEntity _entity = _obj as IPhysicalEntity;
            Rectangle _rect = new Rectangle((int)_entity.Position.X, (int)_entity.Position.Y, _entity.CurrentTextureWidth, _entity.CurrentTextureHeight);


            if (mNodes[0] != null)
            {
                // Check which subnode the object should be placed in
                int _index = GetIndex(_rect);

                // If not this one, then call the respective subnode's Insert method
                if (_index != -1)
                {
                    mNodes[_index].Insert(_obj);
                    return;
                }
            }

            // Add the object to the list
            mObjects.Add(_obj);

            // Check if this node is full
            // Create a new subnode and move objects if required
            if (mObjects.Count > mMaxObjs && mLevel < mMaxLevels)
            {
                if (mNodes[0] == null)
                    Split();

                int i = 0;
                while (i < mObjects.Count)
                {
                    // Cast the target object to an IPhysicalEntity to access it's location and size
                    IPhysicalEntity _ent = mObjects[i] as IPhysicalEntity;
                    Rectangle _rec = new Rectangle((int)_ent.Position.X, (int)_ent.Position.Y, _ent.CurrentTextureWidth, _ent.CurrentTextureHeight);

                    int _index = GetIndex(_rec);
                    if (_index != -1)
                    {
                        // Add the object to its respective subnode and remove from the current node
                        mNodes[_index].Insert(mObjects[i]);
                        mObjects.Remove(mObjects[i]);
                    }
                    else
                        i++;
                }
            }
        }
        /// <summary>
        /// Main Method for accessing the quadtree process
        /// </summary>
        /// <param name="_objects"> List of objects, either from the Collision Manager as new, or from the previous layer </param>
        /// <param name="_target"> Target object to check against </param>
        /// <returns> List of all objects in the same tree as the specified target object </returns>
        public List<ICollidable> Retrieve(List<ICollidable> _objects, ICollidable _target)
        {
            // Cast the target object to an IPhysicalEntity to access it's location and size
            IPhysicalEntity _entity = _target as IPhysicalEntity;
            Rectangle _rect = new Rectangle((int)_entity.Position.X, (int)_entity.Position.Y, _entity.CurrentTextureWidth, _entity.CurrentTextureHeight);

            // Calculate which quadtree the target obejct is in
            int _index = GetIndex(_rect);

            // If the target object is in a subtree, pass the detection off to that subtree
            if (_index != -1 && mNodes[0] != null)
                mNodes[_index].Retrieve(_objects, _target);

            // Add all of this subtree's objects to the list
            _objects.AddRange(mObjects);

            // Return list to the next layer up/Collision manager
            return _objects;
        }

        #endregion
    }
}
