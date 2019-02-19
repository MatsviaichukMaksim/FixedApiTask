using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Interfaces
{
    interface IRepository<T> : IDisposable
         where T : class
    {
        void Create(T item);
        void Read(int id);
        void Update(T item);
        void Delete(int id); //T item
        IQueryable<T> GetAll(); 
    }
}
