using Shared.Dtos;

namespace CommentService.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDto> GetByPostId(string postId);
        CommentDto Create(CommentDto comment);
    }

    public class CommentRepository : ICommentRepository
    {
        private readonly List<CommentDto> _comments = new();

        public IEnumerable<CommentDto> GetByPostId(string postId)
        {
            return _comments.Where(c => c.PostId == postId);
        }

        public CommentDto Create(CommentDto comment)
        {
            _comments.Add(comment);
            return comment;
        }
    }
}