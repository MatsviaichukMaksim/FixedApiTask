using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IAwardService : IService<Award,AwardData>
    {
        List<Award> GetGiverAwards(int id);
        List<Award> GetRecipientAwards(int id);
    }
}
