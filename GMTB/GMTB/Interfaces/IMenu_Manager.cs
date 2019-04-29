﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GMTB.Interfaces
{
    public interface IMenu_Manager
    {
        void ConfigureCamera(Camera2D _cam);
        void Update(GameTime _gameTime);
        void Draw(SpriteBatch _spriteBatch);
        void ActivateMenu(string _targetMenu);
        void InitializeMenus();
    }
}
