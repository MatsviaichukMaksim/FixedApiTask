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
    public class CommentRepository : IRepository<Comment>
    {
        private UserDbContext _userDbContext;

        public CommentRepository()
        {
            this._userDbContext = new UserDbContext();
        }

        public void Create(Comment comment)
        {
            _userDbContext.Comments.Add(comment);
            _userDbContext.SaveChanges();
        }

        public IQueryable<Comment> Read()
        {
            return _userDbContext.Comments;
        }

        public void Update(Comment comment)
        {
            _userDbContext.Entry(comment).State = EntityState.Modified;
            _userDbContext.SaveChanges();
        }
        public void Delete(Comment comment)
        {
            _userDbContext.Comments.Remove(comment);
            _userDbContext.SaveChanges();
        }

    }
}
