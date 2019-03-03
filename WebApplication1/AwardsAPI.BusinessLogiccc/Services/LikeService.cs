using AutoMapper;
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

        public bool Create(LikeData likeData)
        {
            Like like = new Like();
            like = MappLikeDataToLike(likeData, like);
            if (like != null)
            {
                Repository.Create(like);
                bool created = Repository.SaveChanges();
                if (created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

       
        public bool Delete(int id)
        {
            var like = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (like != null)
            {
                Repository.Delete(like);
                bool deleted = Repository.SaveChanges();
                if (deleted)
                {
                    return true;
                }
                else
                {
                    return true;//?
                }
            }
            else
            {
                return true;
            }
        }

        public List<LikeData> Read()
        {
            List<LikeData> likeDataList = new List<LikeData>();
            likeDataList = Repository.Read().Select(a => MappLikeToLikeData(a)).ToList();
            return likeDataList;
        }

        private LikeData MappLikeToLikeData(Like obj)
        {
            return Mapper.Map<Like, LikeData>(obj);
        }
        private Like MappLikeDataToLike(LikeData likeData, Like like)
        {
            //return Mapper.Map<UserData, User>(obj);
            like.AwardId = likeData.AwardId;
            like.UserId = likeData.UserId;
            return like;
        }
    }
}
