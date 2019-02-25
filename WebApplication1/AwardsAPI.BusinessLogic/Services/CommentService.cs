using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Services
{
    public class CommentService : BaseService,ICommentService
    {
        public CommentService(UserDbContext _repository) : base(_repository)
        {

        }
        public IQueryable<Comment> GetCommentsForAward(int id)
        {
            var comment = _repository.Read().Where(a => a.AwardId == id).ToList();
            return comment;
        }
    }
}
