using Shared.Dtos;

namespace PostService.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<PostDto> GetAll();
        PostDto? GetById(string id);
        PostDto Create(PostDto post);
    }

    public class PostRepository : IPostRepository
    {
        private readonly List<PostDto> _posts = new();

        public IEnumerable<PostDto> GetAll()
        {
            return _posts;
        }

        public PostDto? GetById(string id)
        {
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public PostDto Create(PostDto post)
        {
            _posts.Add(post);
            return post;
        }
    }
}