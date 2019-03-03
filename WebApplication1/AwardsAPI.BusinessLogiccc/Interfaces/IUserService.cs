using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        bool Create(UserData item);
        List<UserData> Read();
        bool Update(UserData item, int id);
        bool Delete(int id);
        UserData GetById(int id);
        UserData GetByEmail(string email);
    }
}
