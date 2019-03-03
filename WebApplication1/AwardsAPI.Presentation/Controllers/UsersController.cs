using AwardsAPI.BusinessLogic.Interfaces;
using ConsoleAppForDb.ModelsNewData;
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
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //POST api/users
        [HttpPost]
        public ActionResult Post([FromBody] UserData userData)
        {
            if (userData == null)
            {
                return BadRequest();
            }
            bool userCreate =_service.Create(userData);
            if (userCreate)
            {
            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        // PUT api/users/{Id} 
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserData userData)
        {
            bool userUpdate = _service.Update(userData, id);
            if (userUpdate)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        //GET api/users
        [HttpGet]
        public ActionResult<IEnumerable<UserData>> Get()
        {
            var users = _service.Read();
            if (users == null)
            {
                return NotFound();
            }
            else
            {
                return users;
            }
        }

        //GET api/users/{Id}/userbyid
        [HttpGet("byid/{id}")]
        public ActionResult<UserData> GetById(int id)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return user;
            }
        }
        //GET api/users/{Email}/userbyemail
        [HttpGet("byemail/{Email}")]
        public ActionResult<UserData> GetByEmail(string email)
        {
            var user = _service.GetByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
            return user;
            }
            
        }
        //DELETE api/users/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            bool userDelete = _service.Delete(id);
            if (userDelete)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
