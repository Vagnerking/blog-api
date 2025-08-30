using blog_api.Database;
using blog_api.DTOs.Post;
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

        public async Task<List<PostWithCommentCountDto>> GetAll()
        {
            return await _db.Posts
            .Select(p => new PostWithCommentCountDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                AuthorName = p.AuthorName,
                CreatedAt = p.CreatedAt ?? DateTime.UtcNow,
                UpdatedAt = p.UpdatedAt ?? DateTime.UtcNow,
                CommentsCount = p.Comment.Count()
            })
            .ToListAsync();
        }

        public async Task<Post?> GetById(int id)
        {
            return await _db.Posts.Include(x => x.Comment).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Post> Update(Post post)
        {
            _db.Posts.Update(post);
            await _db.SaveChangesAsync();
            return post;
        }
    }
}
