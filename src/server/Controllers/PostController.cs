using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using server.Models;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;
        }  
        
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _context.Post.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Post> Get(long id)
        {
            var item = _context.Post.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        } 

        [HttpPost]
        public IActionResult Post([FromBody]Post post)
        {
            if(ModelState.IsValid)
            {
                _context.Post.Add(post);
                _context.SaveChanges();
                return Ok(post);
            }
            return BadRequest(ModelState);
        } 
    }
    
}