using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.CollisionSystem
{
    class Collision_Manager : ICollision_Manager
    {
        #region Data Members
        private List<Vector2> ObjectABNormals = new List<Vector2>();
        //private IPlayer mPlayer;
        private IDictionary<int, ICollidable> mCollidables;
        private IEntity_Manager mEntityManager;

        private Vector2 mCollisionNormal;
        private float mCollisionOverlap;

        private IQuadtree mQuadtree;

        #endregion

        #region Constructor
        /// <summary>
        /// Collision Manager
        /// </summary>
        /// <param name="c">List of entities to check collisions on</param>
        /// <param name="p">Player entity</param>
        public Collision_Manager(IEntity_Manager _em, Point _screenSize)
        {
            mCollidables = new Dictionary<int, ICollidable>();
            mEntityManager = _em;
            mQuadtree = new Quadtree(0, new Rectangle(new Point(0, 0), _screenSize));
        }
        #endregion

        #region Methods

        /// <summary>
        /// Collision Detection - Setup subroutine
        /// First compile a list of all normalized Normals of each object to test
        /// Runs through all entities in the list
        /// </summary>
        /// <returns>Collision Occured boolean</returns>
        public void CollisionDetec()
        {
            // Iterate through all the current Entities
            foreach (KeyValuePair<int, IEntity> _keypair in mEntityManager.AllEntities)
            {                
                // try cast the current Dictionary entry as a collidable
                var asInterface = _keypair.Value as ICollidable;
                // If successful, add it to the local list
                if (asInterface != null)
                {
                    mCollidables.Add(asInterface.UID, asInterface);
                    // Add to the 
                    mQuadtree.Insert(asInterface);
                }

                // If needed uncomment to store the player seperately
                //else
                //{
                //    var asInterface = _keypair.Value as IPlayer;
                //    if (asInterface != null)
                //        mPlayer = asInterface
                //}
            }

            // Iterate through all objects in the collidable list
            foreach (KeyValuePair<int, ICollidable> _keypair in mCollidables)
            {
                // Initialize a second list
                List<ICollidable> _nearbyObjs = new List<ICollidable>();

                // Broad phase collision detection - Quadtree
                // Get all the objects in the same quadtree as this object
                _nearbyObjs = mQuadtree.Retrieve(_nearbyObjs, _keypair.Value);

                foreach (ICollidable _obj in _nearbyObjs)
                {
                    ICollidable objA = _keypair.Value;
                    ICollidable objB = _obj;
                    // Check not colliding with self
                    if (objA != objB)
                    {
                        // Mid phase collision detection - Intersecting rectangles
                        if (objA.Hitbox.Intersects(objB.Hitbox))
                        {
                            // Narrow phase collision detection - SAT
                            ObjectABNormals.Clear();
                            foreach (Vector2 vec in objA.UpdateCollisionMesh())
                            {
                                ObjectABNormals.Add(vec);
                            }
                            //foreach (Vector2 vec in objB.RectangleNormalize)
                            foreach (Vector2 vec in objB.UpdateCollisionMesh())
                            {
                                ObjectABNormals.Add(vec);
                            }
                            // Call the main collision test method, pass the reference to the objects Vertices lists
                            // If collision returns true, call the MTV calculation, pass Object A as the target
                            if (CalculateDot(objA.RectangleVertices, objB.RectangleVertices))
                                DetermineCollisionType(objA, objB);
                        }
                    }
                                       
                }
                #region OLD
                //// Second iterate, ie compare all objects against all other objects
                //for (int j = 1; j <= mCollidables.Count; j++)
                //{
                //    // Skip if current list entry is same object
                //    if (mCollidables[i].UID != mCollidables[j].UID)
                //    {
                //        ICollidable objA = mCollidables[i];
                //        ICollidable objB = mCollidables[j];
                //        ObjectABNormals.Clear();
                //        foreach (Vector2 vec in objA.RectangleNormalize)
                //        {
                //            ObjectABNormals.Add(vec);
                //        }
                //        foreach (Vector2 vec in objB.RectangleNormalize)
                //        {
                //            ObjectABNormals.Add(vec);
                //        }
                //        // Call the main collision test method, pass the reference to the objects Vertices lists
                //        // If collision returns true, call the MTV calculation, pass Object A as the target
                //        if (CalculateDot(objA.RectangleVertices, objB.RectangleVertices))
                //            MTVCalc(objA, objB);
                //    } 
                //}
                #endregion
            }
            mCollidables.Clear();
            mQuadtree.Clear();
        }

        /// <summary>
        /// Collision Detection - Main Subroutine
        /// Project the shapes passed by the setup subroutine onto an axis.
        /// Check if the axis are overlapping.
        /// Break out of loop if any overlaps return false
        /// </summary>
        /// <param name="recAVerts">First Objects Vertices</param>
        /// <param name="recBVerts">Second Objects Vertices</param>
        /// <param name="CollisionFlag">Collision Boolean</param>
        /// <returns></returns>
        private bool CalculateDot(List<Vector2> objAVerts, List<Vector2> objBVerts)
        {
            bool CollisionFlag = true;

            Vector2 mShortestOverlap = new Vector2(0);
            float mOverlap = 1000;
            // Use the face of each shape as the separating axis
            foreach (Vector2 Norm in ObjectABNormals)
            {
                // Project the first face of each shape onto the currently selected axis
                // Get a baseline Dot product
                float dot = Vector2.Dot(Norm, objAVerts[0]);
                float obj1Min = dot;
                float obj1Max = dot;
                dot = Vector2.Dot(Norm, objBVerts[0]);
                float obj2Min = dot;
                float obj2Max = dot;

                // Project each other face onto the currently selected axis
                // Update the min and max if a different min or max is found
                foreach (Vector2 vert in objAVerts)
                {
                    dot = 0;
                    dot = Vector2.Dot(Norm, vert);

                    if (dot < obj1Min) obj1Min = dot;
                    if (dot > obj1Max) obj1Max = dot;
                }
                // As above but Object B
                foreach (Vector2 vert in objBVerts)
                {
                    dot = 0;
                    dot = Vector2.Dot(Norm, vert);

                    if (dot < obj2Min) obj2Min = dot;
                    if (dot > obj2Max) obj2Max = dot;
                }
                // Overlap detection
                // Use the maximum and minimum dot products from the last step to check for an overlap
                // If no overlap detected, break from the for loop and return false
                // Else store overlap value for later translation vecotr calculation
                float currentOverlap = 0;

                if ((obj2Max >= obj1Max && obj1Max < obj2Min) ||
                    (obj1Max >= obj2Max && obj2Max < obj1Min))
                {
                    CollisionFlag = false;
                    break;
                }
                else
                {
                    // Check which side is overlapping
                    if (obj1Max > obj2Max)
                        currentOverlap = obj1Max - obj2Min;
                    else if (obj2Max > obj1Max)
                        currentOverlap = obj1Min - obj2Max;
                    // Check for shorter overlap
                    if (currentOverlap < mOverlap)
                    {
                        mOverlap = currentOverlap;
                        mShortestOverlap = Norm;
                    }
                }
            }
            // If all faces have not broken the main loop
            // The loop will exit here, run MTV calculation and then return a true collision flag
            if (CollisionFlag)
            {
                mCollisionNormal = mShortestOverlap;
                mCollisionOverlap = mOverlap;
            }
            return CollisionFlag;
        }
        /// <summary>
        /// Figures out if a physical collision has occured or a trigger collision
        /// Runs MTV calculations if physical
        /// </summary>
        /// <param name="_target"> First object involved </param>
        /// <param name="_otherTarget"> Second object involved </param>
        public void DetermineCollisionType(ICollidable _target, ICollidable _otherTarget)
        {
            // First cast the two objects to IisTriggers
            IisTrigger _ObjA = _target as IisTrigger;
            IisTrigger _ObjB = _otherTarget as IisTrigger;

            // Check if either object is a trigger, call Object A's OnTrigger 
            // passing it the other object it collided with as an IColliadble
            if (_ObjA != null || _ObjB != null)
            {
                // Double check that we are currently working with Object A
                // This is to prevent a non Trigger entity acting as if it is colliding with a physical entity
                if (_ObjA != null)
                    _ObjA.OnTrigger(_otherTarget);
            }
                
            else
            {
                // Assume Physical Collision,
                // Perform MTV calculations and call main Collision Method
                Vector2 _mtv = mCollisionNormal * mCollisionOverlap;
                _target.Collision(_mtv, mCollisionNormal, _otherTarget);
                _otherTarget.Collision(_otherTarget);
            }
            
        }

        #endregion
    }
}
