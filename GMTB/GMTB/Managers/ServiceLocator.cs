using GMTB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.stefanoricciardi.com/2009/09/25/service-locator-pattern-in-csharpa-simple-example/

namespace GMTB.Managers
{
    public class ServiceLocator : IServiceLocator
    {
        #region Data Members
        // Dictionary of Managers and their Interfaces
        private IDictionary<object, object> mServices;
        #endregion

        #region Constructor
        internal ServiceLocator()
        {
            mServices = new Dictionary<object, object>();
            this.mServices.Add(typeof(IContent_Manager), new Content_Manager());
        }
        #endregion

        #region Methods
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
