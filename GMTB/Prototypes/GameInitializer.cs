using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GMTB;
using GMTB.Interfaces;

namespace Prototypes
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
        List<ILevel> mLevels;
        int mLvlCount;
        string mLvlPath;

        public GameInitializer()
        {
            mLvlCount = 1;
            mLvlPath = "Prototypes.Levels.L";

            // Set the content root for this game
            ContentRoot = "Prototypes.Content";
            // Create a new instance of the Kernal, pass Content root and opened levels
            game1 = new Kernel(ContentRoot, GetLevels());
        }

        public void Run()
        {
            game1.Run();
        }

        /// <summary>
        /// Get all level files in the specified directory
        /// </summary>
        /// <returns> List of Levels </returns>
        private List<ILevel> GetLevels()
        {
            List<ILevel> _lvls = new List<ILevel>();

            for (int i = 0; i < mLvlCount; i++)
            {
                int lvlid = i + 1;
                string LeveltoOpen = mLvlPath + lvlid;
                Type t = Type.GetType(LeveltoOpen, true);
                ILevel lvl = Activator.CreateInstance(t) as ILevel;
                _lvls.Add(lvl);
            }
            return _lvls;
        }
    }
}
