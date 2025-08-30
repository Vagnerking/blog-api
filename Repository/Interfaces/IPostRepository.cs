using blog_api.Models;

namespace blog_api.Repository.Interfaces
{
    public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post?> GetPostById(int id);
        Task<Post> Update(Post post);
        Task<Post> Create(Post post);
        Task Delete(Post post);
    }
}
