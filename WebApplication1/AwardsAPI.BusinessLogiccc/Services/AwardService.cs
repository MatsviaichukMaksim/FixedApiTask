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
    public class AwardService : /*BaseService<Award>,*/ IAwardService
    {
        //public AwardService(IRepository<Award> repository) : base(repository)
        //{

        //}
        private IRepository<Award> Repository;
        public AwardService(IRepository<Award> repository)
        {
            Repository = repository;
        }

        public bool Create(AwardData awardData)
        {
            Award award = new Award();
            award = MappAwardDataToData(awardData, award);
            if (award != null)
            {
                Repository.Create(award);
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
            var award = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (award != null)
            {
                Repository.Delete(award);
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

        public List<AwardData> GetGiverAwards(int id)
        {
            List<AwardData> awardDataList = new List<AwardData>();
            awardDataList = Repository.Read().Where(a => a.GiverId == id).Select(a => MappAwardToAwardData(a)).ToList();
            return awardDataList;
        }

        public List<AwardData> GetRecipientAwards(int id)
        {
            List<AwardData> awardDataList = new List<AwardData>();
            awardDataList = Repository.Read().Where(a => a.GetterId == id).Select(a => MappAwardToAwardData(a)).ToList();
            return awardDataList;
        }

        public List<AwardData> Read()
        {
            List<AwardData> awardDataList = new List<AwardData>();
            awardDataList =  Repository.Read().Select(a => MappAwardToAwardData(a)).ToList();
            return awardDataList;
        }
        private AwardData MappAwardToAwardData(Award obj)
        {
            return Mapper.Map<Award, AwardData>(obj);
        }
        private Award MappAwardDataToData(AwardData awardData,Award award)
        {
            //return Mapper.Map<UserData, User>(obj);
            award.GiverId = awardData.GiverId;
            award.GetterId = awardData.GetterId;
            award.Date = awardData.Date;
            award.Points = awardData.Points;
            award.Title = awardData.Title;
            return award;
        }

    }
}
