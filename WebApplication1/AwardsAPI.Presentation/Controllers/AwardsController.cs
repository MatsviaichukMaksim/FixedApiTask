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
    public class AwardsController : ControllerBase
    {
        private IAwardService _service;

        public AwardsController(IAwardService service)
        {
            _service = service;
        }

        //POST api/awards
        [HttpPost]
        public ActionResult Post([FromBody] AwardData award)
        {
            if (award == null)
            {
                return BadRequest();
            }
            _service.Create(award);
            return Ok();
        }
        //GET /api/users/{id}/recipientawards
        [Route("/api/users/{id}/recipientawards")]
        public ActionResult<IEnumerable<AwardData>> GetRecipientAwards(int id)
        {
            var award = _service.GetRecipientAwards(id);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }

        //GET /api/users/{id}/recipientawards
        [Route("/api/users/{id}/giverawards")]
        public ActionResult<IEnumerable<AwardData>> GetGiverAwards(int id)
        {
            var award = _service.GetGiverAwards(id);
            if (award == null)
            {
                return NotFound();
            }
            return Ok(award);
        }
        //DELETE api/awards/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (_service.Delete(id))
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
