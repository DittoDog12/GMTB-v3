using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Prototypes.Characters.Mouse
{
    class PersueState : State
    {
        #region Data Members
        private SoundEffect mCheeseCollection;
        private IContent_Manager mContentManager;
        #endregion
        #region Constructor
        public PersueState(IAIMind _mind): base(_mind)
        {           
            mPath = new Queue<Point>(); 
        }
        #endregion

        #region Methods
        public override void Initialize()
        {
            base.Initialize();
            mContentManager = mMind.MySelf.ServiceLocator.GetService<IContent_Manager>();
            mCheeseCollection = mContentManager.LoadSound("cheese_vendor");
        }
        public override void Update(GameTime _gameTime)
        {
            if (mMind.Target != null)
                mMind.MySelf.ApplyForce(Persue());

            else if (mMind.Target == null)
                ChangeState("idle");

            // if cat close
            //ChangeState("flee");
        }
        private Vector2 Persue()
        {
            Vector2 _rtnval;

            // COnvert mouse and cheese position into locations on the grid.
            // Divide the Vector2 pixel position by the texture width.
            // then -1 to account for grid starting at 0.
            Point _mousepos = new Point(((int)mMind.MySelf.Position.Y / 50), ((int)mMind.MySelf.Position.X / 50));
            Point _activedest = new Point(((int)mMind.Target.Position.Y / 50), ((int)mMind.Target.Position.X / 50));

            // Check if the path exists
            if (mPath.Count > 0)
            {
                mCurrentDest.Y = mPath.Peek().X * 50;
                mCurrentDest.X = mPath.Peek().Y * 50;
                mPath.Dequeue();

                // Check if the mouse is at the lastest position
                // If yes then load the next desitination from the queue
                if (mMind.MySelf.Position == mCurrentDest)
                {
                    mCurrentDest.Y = mPath.Peek().X * 50;
                    mCurrentDest.X = mPath.Peek().Y * 50;
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
            _rtnval.Normalize();

            return _rtnval;
        }
        public override void ChangeState(string _nextState)
        {
            mCheeseCollection.Play();
            base.ChangeState(_nextState);
        }
        #endregion
    }
}
