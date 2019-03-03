using ConsoleAppForDb;
using ConsoleAppForDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private UserDbContext _userDbContext;

        public Repository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public void Create(T item)
        {
            _userDbContext.Set<T>().Add(item);
            //_userDbContext.SaveChanges();
        }

        public IQueryable<T> Read()
        {
            return _userDbContext.Set<T>();
        }

        public void Update(T item)
        {
            _userDbContext.Entry(item).State = EntityState.Modified;
            //_userDbContext.SaveChanges();
        }
        public void Delete(T item)
        {
            _userDbContext.Set<T>().Remove(item);
            //_userDbContext.SaveChanges();
        }
        public bool SaveChanges()
        {
            return _userDbContext.SaveChanges() > 0;
        }
    }
}
