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
    public class AwardsController : ControllerBase
    {
        private IRepository<Award> repository;
        public AwardsController()
        {
            repository = new AwardRepository();
            //repository = new Repository<Award>();
        }
        //POST api/awards
        [HttpPost]
        public ActionResult<Award> Post([FromBody] Award award)
        {
            if (award == null)
            {
                return BadRequest();
            }
            repository.Create(award);
            return Ok();
        }
        //GET /api/users/{id}/recipientawards
        [Route("/api/users/{id}/recipientawards")]
        //[HttpGet("{id}/recipientawards")]
        public ActionResult<IEnumerable<Award>> GetRecipientAwardsById(int id)
        {
            var award = repository.Read().Where(a => a.GetterId == id).ToList();
            if (award !=null)
            {
                return award;
            }
            return NotFound();
        }
        //GET /api/users/{id}/recipientawards
        [Route("/api/users/{id}/giverawards")]
        //[HttpGet("{id}/userbyid")]
        public ActionResult<IEnumerable<Award>> GetGiverAwardsById(int id)
        {
            var award = repository.Read().Where(a => a.GiverId == id).ToList();
            if (award != null)
            {
                return award;
            }
            return NotFound();
        }
        //DELETE api/awards/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<Award> Delete(int id)
        {
            var award = repository.Read().FirstOrDefault(u => u.Id == id);
            if (award == null)
            {
                return NotFound();
            }
            repository.Delete(award);
            return Ok();
        }

    }
}
