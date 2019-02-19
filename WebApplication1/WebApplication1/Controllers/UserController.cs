using ConsoleAppForDb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IRepository<User> _userDbContext;
        public UserController()
        {
            _userDbContext = new UserRepository();
        }
        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            return _userDbContext.GetAll().ToList();
        }
        //GET api/users/{Id}/userbyid
        [HttpGet("{id}/userbyid")]
        public ActionResult<User> GetById(int id)
        {
            return _userDbContext.GetAll().FirstOrDefault(u=>u.Id==id);
        }
        //GET api/users/{Email}/userbyemail
        [HttpGet("{Email}/userbyemail")]
        public ActionResult<User> GetByEmail(string email)
        {
            return _userDbContext.GetAll().FirstOrDefault(u => u.Email == email);
        }
        //DELETE api/users/{Id} 
        [HttpDelete("{id}")]
        public void Delete(int id) // ActionResult<User>
        {
            _userDbContext.Delete(id);
            //var user = GetById(id);
            //if (user==null)
            //{
            //    return NotFound();
            //}
            //_userDbContext.Delete(user);

            //return Ok();
        }
    }
}
