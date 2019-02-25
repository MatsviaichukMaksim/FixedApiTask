using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Services
{
    public class AwardService : IAwardService
    {
        public IQueryable<Award> GetGiverAwards(int id)
        {
            var award = _repository.Read().Where(a => a.GiverId == id).ToList();
            return award;
        }

        public IQueryable<Award> GetRecipientAwards(int id)
        {
            var award = _repository.Read().Where(a => a.GetterId == id).ToList();
            return award;
        }
    }
}
