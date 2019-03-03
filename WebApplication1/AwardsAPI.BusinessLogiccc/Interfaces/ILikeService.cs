using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface ILikeService
    {
        bool Create(LikeData item);
        List<LikeData> Read();
        bool Delete(int id);
    }
}
