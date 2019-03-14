using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMTB;
using GMTB.Entities.AI;
using Microsoft.Xna.Framework;
using GMTB.Interfaces;

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
        #endregion

        #region Constructor
        public IdleState(IMind _mind) : base (_mind)
        {
            mRandom = new Random();
            mMind.MySelf.Acceleration = new Vector2(1, 1) * 3f;
        }
        #endregion

        #region Methods
        public override void Update(GameTime _gameTime)
        {
            
            mMind.MySelf.ApplyForce(Wander());
            // if cheese exists
            //ChangeState("persue");

            // if cat close
            //ChangeState("Flee");
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
