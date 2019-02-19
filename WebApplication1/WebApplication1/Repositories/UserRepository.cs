using ConsoleAppForDb;
using ConsoleAppForDb.Models;
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
            _userDbContext.Set<User>().Add(user);
            //_userDbContext.Users.Add(user);
        }

        public void Delete(int id) //User user
        {
            //_userDbContext.Set<User>().;
            var user = _userDbContext.Users.Find(id);
            if (user != null)
            {
               // _userDbContext.Users.Remove(user); // can leave just this string
                _userDbContext.Set<User>().Remove(user);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IQueryable<User> GetAll() 
        {
            //do nothing
            return _userDbContext.Users;//.ToList().AsQueryable();
        }

        public void Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
