using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    interface IRepository<T> where T : class
    {
        void Create(T item);
        IQueryable<T> Read();
        void Update(T item);
        void Delete(T item); 
    }
}
