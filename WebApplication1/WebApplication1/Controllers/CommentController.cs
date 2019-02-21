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
    public class CommentController : ControllerBase
    {
        private IRepository<Comment> repository;
        public CommentController()
        {
            repository = new CommentRepository();
            //repository = new Repository<Comment>();
        }
        //POST api/comments
        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            repository.Create(comment);
            return Ok();
        }

        // PUT api/comments/{Id} 
        [HttpPut("{id}")]
        public ActionResult<Comment> Put(int id, [FromBody] Comment commentData)
        {
            var comment = repository.Read().FirstOrDefault(u => u.Id == id); 
            if (comment == null)
            {
                return NotFound();
            }
            comment.Text = commentData.Text;
            comment.AwardId = commentData.AwardId;
            comment.UserId = commentData.UserId;
            comment.Date = commentData.Date;
            repository.Update(comment);
            return Ok();
        }

        //DELETE api/comments/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<Comment> Delete(int id)
        {
            var comment = repository.Read().FirstOrDefault(u => u.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            repository.Delete(comment);
            return Ok();
        }
        [Route("/api/awards/{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsForAwardById(int id)
        {
            var comment = repository.Read().Where(a => a.AwardId == id).ToList();
            if (comment != null)
            {
                return comment;
            }
            return NotFound();
        }
    }
}
