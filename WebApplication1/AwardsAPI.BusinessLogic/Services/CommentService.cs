using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb;
using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Services
{
    public class CommentService : /*BaseService<Comment>,*/ ICommentService
    {
        //public CommentService(IRepository<Comment> repository) : base(repository)
        //{

        //}
        private IRepository<Comment> Repository;

        public CommentService(IRepository<Comment> repository)
        {
            Repository = repository;
        }

        public void Create(CommentData commentData)
        {
            Comment comment = new Comment();
            comment.UserId = commentData.UserId;
            comment.AwardId = commentData.AwardId;
            comment.Text = commentData.Text;
            comment.Date = commentData.Date;
            Repository.Create(comment);
        }

        public bool Delete(int id)
        {
            var comment = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (comment != null)
            {
                Repository.Delete(comment);
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<CommentData> Read()
        {
            List<CommentData> commentDataList = new List<CommentData>();
            var comment = Repository.Read().ToList();
            foreach (Comment commentTemp in comment)
            {
                CommentData commentData = new CommentData();
                commentData.UserId = commentTemp.UserId;
                commentData.AwardId = commentTemp.AwardId;
                commentData.Date = commentTemp.Date;
                commentData.Text = commentTemp.Text;
                commentDataList.Add(commentData);
            }
            return commentDataList;
        }

        public List<CommentData> GetCommentsForAward(int id)
        {
            CommentData commentData = new CommentData();
            List<CommentData> commentDataList = new List<CommentData>();
            var comment = Repository.Read().Where(a => a.AwardId == id).ToList();
            foreach (Comment commentTemp in comment)
            {
                commentData.UserId = commentTemp.UserId;
                commentData.AwardId = commentTemp.AwardId;
                commentData.Date = commentTemp.Date;
                commentData.Text = commentTemp.Text;
                commentDataList.Add(commentData);
            }
            return commentDataList;
        }

        public bool Update(CommentData commentData, int id)
        {
            var comment = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (comment != null)
            {
                comment.UserId = commentData.UserId;
                comment.AwardId = commentData.AwardId;
                comment.Text = commentData.Text;
                comment.Date = commentData.Date;
                Repository.Update(comment);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
