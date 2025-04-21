namespace Shared.Dtos
{
    public class CommentDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PostId { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}