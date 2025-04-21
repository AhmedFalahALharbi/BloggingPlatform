using CommentService.Clients;
using CommentService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace CommentService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _repository;
        private readonly IPostServiceClient _postServiceClient;

        public CommentsController(ICommentRepository repository, IPostServiceClient postServiceClient)
        {
            _repository = repository;
            _postServiceClient = postServiceClient;
        }

        [HttpGet("{postId}")]
        public IActionResult GetByPostId(string postId)
        {
            return Ok(_repository.GetByPostId(postId));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentDto comment)
        {
            // Validate that the post exists
            if (!await _postServiceClient.PostExistsAsync(comment.PostId))
            {
                return BadRequest($"Post with ID {comment.PostId} does not exist.");
            }

            var createdComment = _repository.Create(comment);
            return CreatedAtAction(nameof(GetByPostId), new { postId = comment.PostId }, createdComment);
        }
    }
}