using AutoMapper;
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

        public bool Create(UserData userData)
        {
            User user = new User();
            user = MappUserDataToUser(userData, user);
            if (user != null)
            {
                Repository.Create(user);
                bool created = Repository.SaveChanges();
                if (created)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }

        public bool Delete(int id)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Repository.Delete(user);
                bool deleted = Repository.SaveChanges();
                if (deleted)
                {
                return true;
                }
                else
                {
                    return true;//?
                }
            }
            else
            {
                return true;
            }
        }
        public UserData GetByEmail(string email)
        {
            UserData userData = new UserData();
            var user = Repository.Read().FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                userData = MappUserToUserData(user);
                return userData;
            }
            else
            {
                return null;
            }
        }

        public UserData GetById(int id)
        {
            UserData userData = new UserData();
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                userData = MappUserToUserData(user);
                return userData;
            }
            else
            {
                return null;
            }
        }

        public List<UserData> Read()
        {
            List<UserData> userDataList = new List<UserData>();
            userDataList = Repository.Read().Select(a => MappUserToUserData(a)).ToList();
            return userDataList;
        }

        public bool Update(UserData userData,int id)
        {
            var user = Repository.Read().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user = MappUserDataToUser(userData,user);
                Repository.Update(user);
                bool updated = Repository.SaveChanges();
                if (updated)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private UserData MappUserToUserData(User obj)
        {
            return Mapper.Map<User,UserData>(obj);
        }
        private User MappUserDataToUser(UserData userData, User user)
        {
            //return Mapper.Map<UserData, User>(obj);
            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;
            user.Phone = userData.Phone;
            return user;
        }
    }
}
