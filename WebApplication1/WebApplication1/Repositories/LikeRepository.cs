using ConsoleAppForDb;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace WebApplication1.Repositories
{
    public class LikeRepository : IRepository<Like>
    {
        private UserDbContext _userDbContext;

        public LikeRepository()
        {
            this._userDbContext = new UserDbContext();
        }
        public void Create(Like like)
        {
            _userDbContext.Likes.Add(like);
            _userDbContext.SaveChanges();
        }

        public IQueryable<Like> Read()
        {
            return _userDbContext.Likes;
        }

        public void Update(Like like)
        {
            //do nothing
        }
        public void Delete(Like like)
        {
            _userDbContext.Likes.Remove(like);
            _userDbContext.SaveChanges();
        }
    }
}
