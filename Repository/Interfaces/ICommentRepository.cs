using blog_api.Models;

namespace blog_api.Repository.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAll(int postId);
        Task<Comment?> GetById(int id);
        Task<Comment> Update(Comment comment);
        Task<Comment> Create(Comment comment);
        Task Delete(Comment comment);

    }
}
