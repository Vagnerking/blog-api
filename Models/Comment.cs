using blog_api.DTOs.Comment;
using System.Text.Json.Serialization;

namespace blog_api.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int PostId { get; set; }

        [JsonIgnore]
        public Post Post { get; set; } = null!;

        public void UpdateFromDto(UpsertCommentDto upsertCommentDto)
        {
            PostId = upsertCommentDto.PostId;
            Content = upsertCommentDto.Content;
            AuthorName = upsertCommentDto.AuthorName;
            UpdatedAt = DateTime.UtcNow;
            if (CreatedAt == null) CreatedAt = DateTime.UtcNow;
        }

        public CommentWithoutPostDto ConvertToCommentWithoutPostDto()
        {
            return new CommentWithoutPostDto
            {
                Id = this.Id,
                AuthorName = this.AuthorName,
                Content = this.Content,
                CreatedAt = this.CreatedAt,
                UpdatedAt = this.UpdatedAt,
            };
        }
    }
}
