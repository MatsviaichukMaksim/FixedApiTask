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

        public void Create(AwardData awardData)
        {
            Award award = new Award();
            award.GiverId = awardData.GiverId; 
            award.GetterId = awardData.GetterId; 
            award.Date = awardData.Date;
            award.Points = awardData.Points;
            award.CategoryId = awardData.CategoryId;
            award.Title = awardData.Title;
            Repository.Create(award);
        }

        public bool Delete(int id)
        {
            var award = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (award != null)
            {
                Repository.Delete(award);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<AwardData> GetGiverAwards(int id)
        {
            AwardData awardData = new AwardData();
            List<AwardData> awardDataList = new List<AwardData>();
            //AwardData awardData = new AwardData();
            var award = Repository.Read().Where(a => a.GiverId == id).ToList();
            foreach (Award awardTemp in award)
            {
                awardData.GiverId = awardTemp.GiverId;
                awardData.GetterId = awardTemp.GetterId;
                awardData.Date = awardTemp.Date;
                awardData.Points = awardTemp.Points;
                awardData.CategoryId = awardTemp.CategoryId;
                awardData.Title = awardTemp.Title;
                awardDataList.Add(awardData);
            }
            //awardData = Mapper.MapList<Award, AwardData>(award);
            return awardDataList;
        }

        public List<AwardData> GetRecipientAwards(int id)
        {
            AwardData awardData = new AwardData();
            List<AwardData> awardDataList = new List<AwardData>();
            var award = Repository.Read().Where(a => a.GetterId == id).ToList();
            foreach (Award awardTemp in award)
            {
                awardData.GiverId = awardTemp.GiverId;
                awardData.GetterId = awardTemp.GetterId;
                awardData.Date = awardTemp.Date;
                awardData.Points = awardTemp.Points;
                awardData.CategoryId = awardTemp.CategoryId;
                awardData.Title = awardTemp.Title;
                awardDataList.Add(awardData);
            }
            //awardData = Mapper.MapList<Award, AwardData>(award);
            return awardDataList;
        }

        public List<AwardData> Read()
        {
            List<AwardData> awardDataList = new List<AwardData>();
            var award =  Repository.Read().ToList();
            foreach (Award awardTemp in award)
            {
                AwardData awardData = new AwardData();
                awardData.GiverId = awardTemp.GiverId;
                awardData.GetterId = awardTemp.GetterId;
                awardData.Date = awardTemp.Date;
                awardData.Points = awardTemp.Points;
                awardData.CategoryId = awardTemp.CategoryId;
                awardData.Title = awardTemp.Title;
                awardDataList.Add(awardData);
            }
            return awardDataList;
        }

        public bool Update(AwardData award, int id)
        {
            //do nothing
            return false;
        }
    }
}
