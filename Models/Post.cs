using blog_api.DTOs.Post;

namespace blog_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Comment> Comment { get; set; } = new List<Comment>();

        public void UpdateFromDto(UpsertPostDto upsertPostDto)
        {
            Title = upsertPostDto.Title;
            Content = upsertPostDto.Content;
            AuthorName = upsertPostDto.AuthorName;
            UpdatedAt = DateTime.UtcNow;
            if (CreatedAt == null) CreatedAt = DateTime.UtcNow;
        }
    }
}
