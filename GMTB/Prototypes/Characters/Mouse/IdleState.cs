using GMTB.Abstracts;
using GMTB.Entities.AI;
using GMTB.Interfaces;
using GMTB.Pathfinding;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototypes.Characters.Mouse
{
    public struct Circle
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }
    }
    public class IdleState : State
    {
        #region Data Members
        private float mWanderAngle;
        private Random mRandom;

        private Vector2 mDestination1 = new Vector2(1390, 50);
        private Vector2 mDestination2;
        private Vector2 mActiveDestination;

        private bool mFirstRun = true;
        #endregion

        #region Constructor
        public IdleState(IAIMind _mind) : base(_mind)
        {
            mRandom = new Random();
            mMind.MySelf.Acceleration = new Vector2(1, 1) * 3f;

            mPath = new Queue<Point>();
        }
        #endregion

        #region Methods
        public override void Update(GameTime _gameTime)
        {
            if (mFirstRun)
            {
                mDestination2 = mMind.MySelf.Position;
                mActiveDestination = mDestination1;
                mFirstRun = false;

            }
            mMind.MySelf.ApplyForce(BackandForth());

            //mMind.MySelf.ApplyForce(Wander());
            if (mMind.Target != null)
            {
                ChangeState("persue");
                mFirstRun = true;
            }

            // if cat close
            //ChangeState("Flee");
        }
        private Vector2 BackandForth()
        {
            Vector2 _rtnval;

            // COnvert mouse and cheese position into locations on the grid.
            // Divide the Vector2 pixel position by the texture width
            Point _mousepos = new Point(((int)mMind.MySelf.Position.Y / 50), ((int)mMind.MySelf.Position.X / 50));
            Point _activedest = new Point(((int)mActiveDestination.Y / 50), ((int)mActiveDestination.X / 50));

            // Check if the path exists
            if (mPath.Count > 0)
            {
                // Load the first destination out of the queue
                Point _currdest = mPath.Peek();
                mCurrentDest.Y = _currdest.X * 50;
                mCurrentDest.X = _currdest.Y * 50;

                //mCurrentDest.Y = mPath.Peek().X * 50;
                //mCurrentDest.X = mPath.Peek().Y * 50;
                //mPath.Dequeue();
                // Check if the mouse is at the lastest position
                // If yes then load the next desitination from the queue               
                if (_mousepos == _currdest)
                {
                    mPath.Dequeue();
                }
            }
            else
            {
                // If not the load the path into a queue
                foreach (Point p in mMind.Pathfinder.FindPath(_mousepos, _activedest))
                {
                    mPath.Enqueue(p);
                }
            }

            // Calcualte the vector to get to the current destination
            _rtnval = mCurrentDest - mMind.MySelf.Position;
            //_rtnval = Vector2.Distance(mCurrentDest, mMind.MySelf.Position);
            _rtnval.Normalize();

            // If the current destination has been reached, swap the current destinations
            if (_mousepos == _activedest && mActiveDestination == mDestination1)
                mActiveDestination = mDestination2;

            else if (_mousepos == _activedest && mActiveDestination == mDestination2)
                mActiveDestination = mDestination1;


            return _rtnval;
        }
        public Vector2 Wander()
        {
            Vector2 _wanderForce = new Vector2();

            // Calculate a circle centred on the mouse and scale it
            float _circleDist = 2f;

            Circle _circle = new Circle();
            _circle.Center = new Vector2(mMind.MySelf.Position.X + (mMind.MySelf.Texture.Width / 2),
                mMind.MySelf.Position.Y + (mMind.MySelf.Texture.Height / 2));
            _circle.Radius = mMind.MySelf.Texture.Width / 2;
            _circle.Center.Normalize();
            _circle.Center *= _circleDist;

            // Calculate an angle to turn to
            Vector2 _displacement = new Vector2(0, -1);
            _displacement *= _circle.Radius;
            _displacement = SetAngle(_displacement, mWanderAngle);

            mWanderAngle += mRandom.Next(10, 80);

            _wanderForce = _circle.Center += _displacement;

            return _wanderForce;
        }

        public Vector2 SetAngle(Vector2 _disp, float _angle)
        {
            float len = _disp.Length();
            _disp.X = (float)Math.Cos(_angle) * len;
            _disp.Y = (float)Math.Sin(_angle) * len;
            return _disp;
        }
        #endregion
    }
}
