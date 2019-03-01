using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        void Create(CommentData item);
        List<CommentData> Read();
        bool Update(CommentData item, int id);
        bool Delete(int id);
        List<CommentData> GetCommentsForAward(int id);
    }
}
