using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;

namespace AwardsAPI.BusinessLogic.Services
{
    public abstract class BaseService<T> where T:class
    {
        //protected IRepository<T> Repository;

        //protected BaseService(IRepository<T> repository)
        //{
        //    Repository = repository;
        //}
       
    }
}
