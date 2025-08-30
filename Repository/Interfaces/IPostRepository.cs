using blog_api.DTOs.Post;
using blog_api.Models;

namespace blog_api.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<List<PostWithCommentCountDto>> GetAll();
        Task<Post?> GetById(int id);
        Task<Post> Update(Post post);
        Task<Post> Create(Post post);
        Task Delete(Post post);
    }
}
