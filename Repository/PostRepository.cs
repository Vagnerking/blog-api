using blog_api.Database;
using blog_api.Models;
using blog_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blog_api.Repository
{
    public class PostRepository : IPostRepository
    {

        private readonly AppDbContext _db;

        public PostRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Post> Create(Post post)
        {
            await _db.Posts.AddAsync(post);
            await _db.SaveChangesAsync();

            return post;
        }

        public async Task Delete(Post post)
        {
            _db.Posts.Remove(post);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAll()
        {
            return await _db.Posts.ToListAsync();
        }

        public async Task<Post?> GetPostById(int id)
        {
            return await _db.Posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> Update(Post post)
        {
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
            return post;
        }
    }
}
