using blog_api.Database;
using blog_api.Models;
using blog_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blog_api.Repository
{
    public class CommentRepository : ICommentRepository
    {

        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Comment> Create(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
            await _db.SaveChangesAsync();

            return comment;
        }

        public async Task Delete(Comment comment)
        {
            _db.Comments.Remove(comment);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAll(int postId)
        {
            return await _db.Comments.Where(x => x.PostId == postId).ToListAsync();
        }

        public async Task<Comment?> GetById(int id)
        {
            return await _db.Comments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Comment> Update(Comment comment)
        {
            _db.Comments.Update(comment);
            await _db.SaveChangesAsync();
            return comment;
        }
    }
}
