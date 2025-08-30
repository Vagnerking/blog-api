using blog_api.DTOs.Comment;
using blog_api.Models;

namespace blog_api.Services.Interfaces
{
    public interface ICommentService
    {
        Task<CommentWithoutPostDto> Create(UpsertCommentDto commentDto);
        Task<CommentWithoutPostDto> Update(int id, UpsertCommentDto commentDto);
        Task<Comment> GetById(int id);
        Task<List<CommentWithoutPostDto>> GetAll(int postId);
        Task Delete(int id);
    }
}
