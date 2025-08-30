using blog_api.DTOs.Comment;
using blog_api.Models;

namespace blog_api.Services.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> Create(UpsertCommentDto commentDto);
        Task<Comment> Update(int id, UpsertCommentDto commentDto);
        Task<Comment> GetById(int id);
        Task<List<Comment>> GetAll(int postId);
        Task Delete(int id);
    }
}
