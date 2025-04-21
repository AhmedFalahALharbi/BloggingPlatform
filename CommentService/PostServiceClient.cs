namespace CommentService.Clients
{
    public interface IPostServiceClient
    {
        Task<bool> PostExistsAsync(string postId);
    }

    public class PostServiceClient : IPostServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<PostServiceClient> _logger;

        public PostServiceClient(HttpClient httpClient, IConfiguration configuration, ILogger<PostServiceClient> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<bool> PostExistsAsync(string postId)
        {
            try
            {
                var postServiceUrl = _configuration["PostServiceUrl"];
                var response = await _httpClient.GetAsync($"{postServiceUrl}/posts/{postId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating post existence for postId {PostId}", postId);
                return false;
            }
        }
    }
}