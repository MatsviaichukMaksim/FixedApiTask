using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IUserService: IService<UserData>
    {
        UserData GetById(int id);
        UserData GetByEmail(string email);
    }
}
