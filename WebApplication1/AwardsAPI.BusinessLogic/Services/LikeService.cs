using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Services
{
    public class LikeService: ILikeService
    {
        //public LikeService(IRepository<Like> repository) : base(repository)
        //{

        //}
        private IRepository<Like> Repository;
        public LikeService(IRepository<Like> repository)
        {
            Repository = repository;
        }

        public void Create(LikeData likeData)
        {
            Like like = new Like();
            like.AwardId = likeData.AwardId;
            like.UserId = likeData.UserId;
            Repository.Create(like);
        }

       
        public bool Delete(int id)
        {
            var like = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (like != null)
            {
                Repository.Delete(like);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Like> Read()
        {
            return Repository.Read().ToList();
        }


        public bool Update(LikeData item, int id)
        {
            //do nothing
            return false;
        }
    }
}
