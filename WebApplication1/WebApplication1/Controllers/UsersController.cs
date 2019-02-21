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
    public class UsersController : ControllerBase
    {
        private IRepository<User> _repository;
        public UsersController()
        {
            _repository = new UserRepository();
            //repository = new Repository<User>();
        }

        //private UsersController(IRepository<User> repo)
        //{
        //    _repository = repo;
        //}

        //POST api/users
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _repository.Create(user);
            return Ok();
        }
        // PUT api/users/{Id} 
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User userData)
        {
            //var user = GetById(id);
            var user = _repository.Read().FirstOrDefault(u => u.Id == id); //repeat
            if (user == null)
            {
                return NotFound();
            }
            user.FirstName = userData.FirstName;
            user.LastName = userData.LastName;
            user.Email = userData.Email;
            user.Phone = userData.Phone;
            _repository.Update(user);
            return Ok();

            //_userDbContext.Save();
        }
        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
             return _repository.Read().ToList();
        }
        //GET api/users/{Id}/userbyid
        [HttpGet("{id}/userbyid")]
        public ActionResult<User> GetById(int id)
        {
            var user = _repository.Read().FirstOrDefault(u=>u.Id==id);
            if (user != null)
            {
                return user;
            }
            return NotFound();
        }
        //GET api/users/{Email}/userbyemail
        [HttpGet("{Email}/userbyemail")]
        public ActionResult<User> GetByEmail(string email)
        {
            var user = _repository.Read().FirstOrDefault(u => u.Email == email);
            if(user!=null)
            {
                return user;
            }
            return NotFound();
        }
        //DELETE api/users/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id) // ActionResult<User> //repeat
        {
            //if (id != user.Id)
            //{
            //    return NotFound();
            //}
            //repository.Delete(id);
            //return Ok();
            //var user = GetById(id);
            var user = _repository.Read().FirstOrDefault(u => u.Id == id);
            if (user==null)
            {
                return NotFound();
            }
            _repository.Delete(user);
            return Ok();
        }
        //GET /api/users/{id}/recipientawards
        //[Route("/api/users/{id}/giverawards")]
        //[HttpGet("{id}/giverawards")]
        //public ActionResult<IEnumerable<Award>> GetGiverAwardsById(int id)
        //{
        //    var award = repository.Awards.Where(a => a.AgiverId == id).ToList();
        //}
    }
}
