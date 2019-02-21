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
    public class CommentsController : ControllerBase
    {
        private IRepository<Comment> _repository;
        public CommentsController()
        {
            _repository = new CommentRepository();
            //repository = new Repository<Comment>();
        }

        //private CommentsController(IRepository<Comment> repo)
        //{
        //    _repository = repo;
        //}

        //POST api/comments
        [HttpPost]
        public ActionResult<Comment> Post([FromBody] Comment comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            _repository.Create(comment);
            return Ok();
        }

        // PUT api/comments/{Id} 
        [HttpPut("{id}")]
        public ActionResult<Comment> Put(int id, [FromBody] Comment commentData)
        {
            var comment = _repository.Read().FirstOrDefault(u => u.Id == id); 
            if (comment == null)
            {
                return NotFound();
            }
            comment.Text = commentData.Text;
            comment.AwardId = commentData.AwardId;
            comment.UserId = commentData.UserId;
            comment.Date = commentData.Date;
            _repository.Update(comment);
            return Ok();
        }

        //DELETE api/comments/{Id} 
        [HttpDelete("{id}")]
        public ActionResult<Comment> Delete(int id)
        {
            var comment = _repository.Read().FirstOrDefault(u => u.Id == id);
            if (comment == null)
            {
                return NotFound();
            }
            _repository.Delete(comment);
            return Ok();
        }
        [Route("/api/awards/{id}/comments")]
        public ActionResult<IEnumerable<Comment>> GetCommentsForAward(int id)
        {
            var comment = _repository.Read().Where(a => a.AwardId == id).ToList();
            if (comment != null)
            {
                return comment;
            }
            return NotFound();
        }
    }
}
