namespace blog_api.DTOs
{
    public class UpsertCommentDto
    {
        public string AuthorName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
