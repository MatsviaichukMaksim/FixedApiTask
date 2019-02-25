using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        User GetByEmail(string email);
    }
}
