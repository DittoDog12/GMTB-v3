using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB;
using GMTB.Interfaces;

namespace The_Infirmary
{
    class GameInitializer : IDisposable
    {

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~GameInitializer() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        Kernel game1;
        string ContentRoot;
        int mLvlCount;
        string mLvlPath;

        public GameInitializer()
        {
            mLvlCount = 13;
            mLvlPath = "The_Infirmary.Levels.L";

            // Set the content root for this game
            ContentRoot = "Content";
            // Create a new instance of the Kernal, pass Content root and opened levels
            game1 = new Kernel(ContentRoot, GetLevels(), GetMenus());
            game1.IsMouseVisible = true;
        }

        public void Run()
        {
            game1.Run();
        }

        /// <summary>
        /// Get all level files in the specified directory
        /// </summary>
        /// <returns> List of Levels </returns>
        private IDictionary<string, ILevel> GetLevels()
        {
            IDictionary<string, ILevel> _lvls = new Dictionary<string, ILevel>();

            for (int i = 0; i < mLvlCount; i++)
            {
                int lvlid = i + 1;
                string LeveltoOpen = mLvlPath + lvlid;
                Type t = Type.GetType(LeveltoOpen, true);
                ILevel lvl = Activator.CreateInstance(t) as ILevel;
                _lvls.Add(lvl.LvlID, lvl);
            }
            return _lvls;
        }
        private IDictionary<string, IMenu> GetMenus()
        {
            IDictionary<string, IMenu> _menus = new Dictionary<string, IMenu>();
            IMenu _newMenu = new Menus.MainMenu("main");
            _menus.Add(_newMenu.Name, _newMenu);

            _newMenu = new Menus.PauseMenu("pause");
            _menus.Add(_newMenu.Name, _newMenu);

            return _menus;

        }
    }
}
