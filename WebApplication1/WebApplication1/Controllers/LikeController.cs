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
    public class LikeController : ControllerBase
    {
        private IRepository<Like> repository;
        public LikeController()
        {
            repository = new LikeRepository();
            //repository = new Repository<Like>();
        }
        //POST api/likes
        [HttpPost]
        public ActionResult<Like> Post([FromBody] Like like)
        {
            if (like == null)
            {
                return BadRequest();
            }
            repository.Create(like);
            return Ok();
        }
        //DELETE api/likes/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<Like> Delete(int id)
        {
            var like = repository.Read().FirstOrDefault(u => u.Id == id);
            if (like == null)
            {
                return NotFound();
            }
            repository.Delete(like);
            return Ok();
        }
    }
}
