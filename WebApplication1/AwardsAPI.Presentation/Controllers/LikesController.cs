using AwardsAPI.BusinessLogic.Interfaces;
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
        private ILikeService _service;

        public LikesController(ILikeService service)
        {
            _service = service;
        }

        //POST api/likes
        [HttpPost]
        public ActionResult Post([FromBody] Like like)
        {
            if (like == null)
            {
                return BadRequest();
            }
            _service.Create(like);
            return Ok();
        }
        //DELETE api/likes/{Id} 
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
