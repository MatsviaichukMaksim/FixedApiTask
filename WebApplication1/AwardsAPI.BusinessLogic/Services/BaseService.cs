using ConsoleAppForDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Services
{
    public abstract class BaseService
    {
        private UserDbContext _userDbContext;

        public BaseService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
    }
}
