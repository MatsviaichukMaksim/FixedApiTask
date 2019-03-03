using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IAwardService 
    {
        bool Create(AwardData item);
        List<AwardData> Read();
        //bool Update(AwardData item, int id);
        bool Delete(int id);
        List<AwardData> GetGiverAwards(int id);
        List<AwardData> GetRecipientAwards(int id);
    }
}
