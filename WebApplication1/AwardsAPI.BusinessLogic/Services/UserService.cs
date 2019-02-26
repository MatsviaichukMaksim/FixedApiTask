using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Services
{
    public class UserService :/* BaseService<User>,*/ IUserService
    {
        //public UserService(IRepository<User> repository) : base(repository)
        //{

        //}
        protected IRepository<User> Repository;
        protected UserService(IRepository<User> repository)
        {
            Repository = repository;
        }

        public void Create(User user)
        {
            Repository.Create(user);
        }

        public bool Delete(int id)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Repository.Delete(user);
                return true;
            }
            else
            {
                return false;
            }
        }
        public User GetByEmail(string email)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Email == email);
            return user;
        }

        public User GetById(int id)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            return user;
        }

        public List<User> Read()
        {
            return Repository.Read().ToList();
        }

        public bool Update(User userData,int id)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = userData.FirstName;
                user.LastName = userData.LastName;
                user.Email = userData.Email;
                user.Phone = userData.Phone;
                Repository.Update(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
