using ConsoleAppForDb;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class AwardRepository : IRepository<Award>
    {
        private UserDbContext _userDbContext;

        public AwardRepository()
        {
            this._userDbContext = new UserDbContext();
        }
        public void Create(Award award)
        {
            _userDbContext.Awards.Add(award);
            _userDbContext.SaveChanges();
        }

        public IQueryable<Award> Read()
        {
            return _userDbContext.Awards;
        }

        public void Update(Award item)
        {
            //do nothing
        }
        public void Delete(Award award)
        {
            _userDbContext.Awards.Remove(award);
            _userDbContext.SaveChanges();
        }
    }
}
