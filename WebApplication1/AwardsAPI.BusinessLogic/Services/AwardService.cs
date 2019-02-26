using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
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
        protected IRepository<Award> Repository;
        protected AwardService(IRepository<Award> repository)
        {
            Repository = repository;
        }

        public void Create(Award award)
        {
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

        public List<Award> GetGiverAwards(int id)
        {
            var award = Repository.Read().Where(a => a.GiverId == id).ToList();
            return award.ToList();
        }

        public List<Award> GetRecipientAwards(int id)
        {
            var award = Repository.Read().Where(a => a.GetterId == id).ToList();
            return award.ToList();
        }

        public List<Award> Read()
        {
            return Repository.Read().ToList();
        }

        public bool Update(Award award, int id)
        {
            //do nothing
            return false;
        }
    }
}
