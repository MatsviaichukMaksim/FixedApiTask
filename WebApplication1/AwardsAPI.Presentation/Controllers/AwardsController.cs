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
            bool awardCreate = _service.Create(award);
            if (awardCreate)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //GET /api/users/{id}/recipientawards
        [Route("/api/users/recipientawards/{id}")]
        public ActionResult<IEnumerable<AwardData>> GetRecipientAwards(int id)
        {
            var award = _service.GetRecipientAwards(id);
            if (award == null)
            {
                return NotFound();
            }
            return award;
        }

        //GET /api/users/{id}/recipientawards
        [Route("/api/users/giverawards/{id}")]
        public ActionResult<IEnumerable<AwardData>> GetGiverAwards(int id)
        {
            var award = _service.GetGiverAwards(id);
            if (award == null)
            {
                return NotFound();
            }
            return award;
        }
        //DELETE api/awards/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool awardDelete = _service.Delete(id);
            if (awardDelete)
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
