using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMTB.Interfaces
{
    public interface IEntity_Manager
    {
        //IDictionary<int, IEntity> Entities { get; }

        IEntity GetEntity(int _index);
        int TotalEntities();
        IEntity newEntity<T>() where T : IEntity, new();
        IEntity newEntity<T>(string _path) where T : IEntity, new();
        IEntity newEntity<T>(string _path, bool _inputReq) where T : IEntity, new();
    }
}
