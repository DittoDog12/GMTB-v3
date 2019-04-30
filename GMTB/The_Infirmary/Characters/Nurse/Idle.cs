using GMTB.Abstracts;
using GMTB.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Infirmary.Characters.Nurse
{
    class Idle : State
    {
        private float mTriggerDistance = 300f;

        public Idle(IAIMind _mind) : base(_mind)
        {
        }

        public override void Update(GameTime _gameTime)
        {
            if (mMind.Target != null)
            {
                Vector2 _dist = mMind.Target.Position - mMind.MySelf.Position;
                float _distance = _dist.Length();
                if (_distance < mTriggerDistance)
                    ChangeState("persue");
            }           
        }
    }
}
