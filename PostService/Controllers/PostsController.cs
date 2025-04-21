using Microsoft.AspNetCore.Mvc;
using PostService.Repositories;
using Shared.Dtos;

namespace PostService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _repository;

        public PostsController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var post = _repository.GetById(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        [HttpPost]
        public IActionResult Create(PostDto post)
        {
            var createdPost = _repository.Create(post);
            return CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost);
        }
    }
}