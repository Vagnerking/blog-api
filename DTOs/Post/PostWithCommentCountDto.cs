namespace blog_api.DTOs.Post
{
#nullable disable
    public class PostWithCommentCountDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CommentsCount { get; set; }
    }
}
