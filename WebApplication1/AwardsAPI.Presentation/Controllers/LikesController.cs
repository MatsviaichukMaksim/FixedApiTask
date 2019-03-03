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
    public class LikesController : ControllerBase
    {
        private ILikeService _service;

        public LikesController(ILikeService service)
        {
            _service = service;
        }

        //POST api/likes
        [HttpPost]
        public ActionResult Post([FromBody] LikeData like)
        {
            if (like == null)
            {
                return BadRequest();
            }
            bool likeCreate = _service.Create(like);
            if (likeCreate)
            {
            return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //DELETE api/likes/{Id} 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            bool likeDelete = _service.Delete(id);
            if (likeDelete)
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
