using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GMTB.Interfaces;

namespace GMTB.Managers
{
    public class Content_Manager : IContent_Manager
    {
        #region Data Members
        ContentManager mContent;
        #endregion

        #region Constructor
        public Content_Manager(ContentManager _content, string _Root)
        {
            mContent = _content;
            mContent.RootDirectory = _Root;
        }
        #endregion

        #region Methods
        public void ApplyTexture(string _tex, IPhysicalEntity _ent)
        {
            _ent.Texture = mContent.Load<Texture2D>(_tex);
        }
        public void ApplyTexture(string _tex, IBackground_Manager _man)
        {
            _man.Texture = mContent.Load<Texture2D>(_tex);
        }
        #endregion
    }
}
