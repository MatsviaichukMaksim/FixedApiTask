using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IService<T,V> /*: IRepository<T>*/ where T:class
    {
        void Create(V item);
        List<T> Read();
        bool Update(V item,int id);
        bool Delete(int id);
    }
}
