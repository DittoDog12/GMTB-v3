using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GMTB.Interfaces;

namespace GMTB.Dialogue
{
    public class DialogueBox : IDialogueBox
    {
        #region Data Members
        private IContent_Manager mContentManager;
        private SpriteFont mFont;
        private Vector2 mPosition;
        #endregion

        #region Constructor
        public DialogueBox(IServiceLocator _sl, Vector2 _pos)
        {
            mContentManager = _sl.GetService<IContent_Manager>();
            mPosition = _pos;
            mFont = mContentManager.LoadFont("HudText");
        }
        #endregion

        #region Methods
        public void Draw(SpriteBatch _spriteBatch, string _line)
        {
            _spriteBatch.DrawString(mFont, _line, mPosition, Color.White);
        }
        #endregion
    }
}
