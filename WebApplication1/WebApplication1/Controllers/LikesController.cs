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
    public class LikesController : ControllerBase
    {
        private IRepository<Like> _repository;
        public LikesController()
        {
            _repository = new LikeRepository();
            //repository = new Repository<Like>();
        }

        //private LikesController(IRepository<Like> repo) 
        //{
        //    _repository = repo;
        //}

        //POST api/likes
        [HttpPost]
        public ActionResult<Like> Post([FromBody] Like like)
        {
            if (like == null)
            {
                return BadRequest();
            }
            _repository.Create(like);
            return Ok();
        }
        //DELETE api/likes/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<Like> Delete(int id)
        {
            var like = _repository.Read().FirstOrDefault(u => u.Id == id);
            if (like == null)
            {
                return NotFound();
            }
            _repository.Delete(like);
            return Ok();
        }
    }
}
