using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.OldMan
{
    class Run : State
    {
        private IPhysicalEntity mNurse;
        private float mJumpActivation = 100f;
        private float mSpeed = 7f;

        public Run(IAIMind _mind) : base(_mind)
        {
            
        }

        public override void Draw(SpriteBatch _spriteBatch, GameTime _gameTime)
        {
            
        }
        public override void Reactivate()
        {
            base.Reactivate();
            mAnimation.Frames = 8;
            mAnimation.Columns = 8;
            mMind.MySelf.Texturename = "Characters/OldMan/walkR";
            // Find the nurse object
            foreach (KeyValuePair<int, IEntity> _keyPair in mMind.MySelf.ServiceLocator.GetService<IEntity_Manager>().AllEntities)
                if (_keyPair.Value.Name == "nurse")
                    mNurse = _keyPair.Value as IPhysicalEntity;
        }
        public override void Update(GameTime _gameTime)
        {
            mMind.MySelf.Moving = true;
            mMind.MySelf.ApplyForce(PlotPath());

            // If Close to Nurse then Jump
            Vector2 v1 = new Vector2(mNurse.Position.X, 0);
            Vector2 v2 = new Vector2(mMind.MySelf.Position.X, 0);
            float _distance = Vector2.Distance(v1, v2);
            if (_distance <= mJumpActivation)
                mMind.ChangeState("yeet");
        }
        /// <summary>
        /// Plot a path
        /// </summary>
        /// <returns>Direction to the path</returns>
        private Vector2 PlotPath()
        {
            Vector2 _rtnval;

            // Calcualte the vector to get to the current destination
            _rtnval = new Vector2(3000, mMind.MySelf.Position.Y) - mMind.MySelf.Position;
            _rtnval.Normalize();

            return _rtnval * mSpeed;
        }
    }
}
