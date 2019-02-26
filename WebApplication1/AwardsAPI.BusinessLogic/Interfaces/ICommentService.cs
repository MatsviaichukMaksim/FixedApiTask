using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface ICommentService :IService<Comment>
    {
        List<Comment> GetCommentsForAward(int id);
    }
}
