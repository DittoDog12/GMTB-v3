using GMTB.Interfaces;
using GMTB.InputSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using GMTB.CollisionSystem;

//http://www.stefanoricciardi.com/2009/09/25/service-locator-pattern-in-csharpa-simple-example/

namespace GMTB.Managers
{
    /// <summary>
    /// Service Locator, holds references to all Managers and retrieves on request
    /// </summary>
    public class ServiceLocator : IServiceLocator
    {
        #region Data Members
        /// Dictionary of Managers and their Interfaces
        private IDictionary<object, object> mServices;
        #endregion

        #region Constructor
        /// <summary>
        /// Main Constructor
        /// Creates Managers
        /// </summary>
        /// <param name="_content">Reference to Monogame Content Manager</param>
        /// <param name="_contentRoot">Path to Content Root Directory</param>
        /// <param name="_levels">Pass dictionary of all Levels here</param>
        /// <param name="_menus">Pass dictionary of all Menus here</param>
        /// <param name="_viewport">Size of current viewport</param>
        internal ServiceLocator(ContentManager _content, string _contentRoot, IDictionary<string, ILevel> _levels, IDictionary<string, IMenu> _menus, Point _viewport)
        {
            mServices = new Dictionary<object, object>();
            // Create Managers
            // Input Manager - No Dependencies
            mServices.Add(typeof(IInput_Manager), new Input_Manager());
            // Content Manager - Requires Monogame Content Manager and Game Content Root Directory
            mServices.Add(typeof(IContent_Manager), new Content_Manager(_content, _contentRoot));
            // Background Manager - Requires Content Manager
            mServices.Add(typeof(IBackground_Manager), new Background_Manager(GetService<IContent_Manager>()));
            // Entity Manager - Requires Service Locator and Content Manager
            mServices.Add(typeof(IEntity_Manager), new Entity_Manager(this, GetService<IContent_Manager>()));
            // Scene Manager - Requires Entity Manager and Background Manager
            mServices.Add(typeof(IScene_Manager), new Scene_Manager(GetService<IEntity_Manager>(), GetService<IBackground_Manager>()));
            // Collision Manager - Requires Entity Manager and Viewport
            mServices.Add(typeof(ICollision_Manager), new Collision_Manager(GetService<IEntity_Manager>(), _viewport));
            // AI Manager - Requires Entity Manager
            mServices.Add(typeof(IAI_Manager), new AI_Manager(GetService<IEntity_Manager>()));
            // Menu Manager - Requires Service Locator and List of Menus
            mServices.Add(typeof(IMenu_Manager), new Menu_Manager(this, _menus));
            // Level Manager - Requires Service Locator and Entity Manager
            mServices.Add(typeof(ILevel_Manager), new Level_Manager(this, GetService<IEntity_Manager>(), _levels));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get a service/manager of the specified type
        /// </summary>
        /// <typeparam name="T">Service/Manager to locate</typeparam>
        /// <returns>The located Service/Manager</returns>
        public T GetService<T>()
        {
            try
            {
                return (T)mServices[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Requested Manager not found");
            }
        }
        #endregion

    }
}
