using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IService<T> /*: IRepository<T>*/ where T:class
    {
        void Create(T item);
        List<T> Read();
        bool Update(T item,int id);
        bool Delete(int id);
    }
}
