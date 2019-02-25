using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IAwardService
    {
        IQueryable<Award> GetGiverAwards(int id);
        IQueryable<Award> GetRecipientAwards(int id);
    }
}
