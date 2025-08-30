using blog_api.DTOs.Post;
using blog_api.Models;

namespace blog_api.Services.Interfaces
{
    public interface IPostService
    {
        Task<Post> Create(UpsertPostDto postDto);
        Task<Post> Update(int id, UpsertPostDto postDto);
        Task<Post> GetById(int id);
        Task<List<PostWithCommentCountDto>> GetAll();
        Task Delete(int id);
    }
}
