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
    public class UserRepository : IRepository<User>
    {
        private UserDbContext _userDbContext;

        public UserRepository()
        {
            this._userDbContext = new UserDbContext();
        }
        public void Create(User user)
        {
            //_userDbContext.Set<User>().Add(user);
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }
        public IQueryable<User> Read()
        {
            return _userDbContext.Users;//.ToList().AsQueryable();
        }

        public void Update(User user)
        {
            _userDbContext.Entry(user).State = EntityState.Modified;
            _userDbContext.SaveChanges();
        }
        public void Delete(User user) //User user
        {
         // var user = _userDbContext.Users.Find(id);
            _userDbContext.Users.Remove(user); // can leave just this string
         //_userDbContext.Set<User>().Remove(user);
            _userDbContext.SaveChanges();
        }

    }
}
