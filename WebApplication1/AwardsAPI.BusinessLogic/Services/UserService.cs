using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.Models;
using ConsoleAppForDb.ModelsNewData;
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
        private IRepository<User> Repository;
        public UserService(IRepository<User> repository)
        {
            Repository = repository;
        }

        public void Create(UserData userData)
        {
            User user = new User();
            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;
            user.Phone = userData.Phone;
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
        public UserData GetByEmail(string email)
        {
            UserData userData = new UserData();
            var user = Repository.Read().FirstOrDefault(u => u.Email == email);
            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.Email = user.Email;
            userData.Phone = user.Phone;
            return userData;
        }

        public UserData GetById(int id)
        {
            UserData userData = new UserData();
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            userData.FirstName = user.FirstName;
            userData.LastName = user.LastName;
            userData.Email = user.Email;
            userData.Phone = user.Phone;
            return userData;
        }

        public List<UserData> Read()
        {
            List<UserData> userDataList = new List<UserData>();
            var user = Repository.Read().ToList();
            foreach (User userTemp in user)
            {
                UserData userData = new UserData();
                userData.FirstName = userTemp.FirstName;
                userData.LastName = userTemp.LastName;
                userData.Email = userTemp.Email;
                userData.Phone = userTemp.Phone;
                userDataList.Add(userData);
            }
            return userDataList;
        }

        public bool Update(UserData userData,int id)
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
