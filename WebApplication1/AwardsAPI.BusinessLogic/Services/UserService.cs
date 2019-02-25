using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwardsAPI.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        public User GetByEmail(string email)
        {
            var user = _repository.Read().FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User GetById(int id)
        {
            var user = _repository.Read().FirstOrDefault(u => u.Id == id);
            return user;
        }
    }
}
