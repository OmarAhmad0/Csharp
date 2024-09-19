using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateCommentAsync( Comment CommentModel)
        {
            await _context.Comments.AddAsync(CommentModel);
            await _context.SaveChangesAsync();
            return CommentModel;
        }

        public async Task<Comment?> DeleteCommentAsync(int Id)
        {
            var CommentModel = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == Id);

            if (CommentModel == null)
                return null;

            _context.Comments.Remove(CommentModel);

            await _context.SaveChangesAsync();

            return CommentModel;
        }

        public async Task<List<Comment>> GetCommentsAsync(CommentQueryObject queryObject)
        {
            var comments = _context.Comments.Include(c => c.AppUser).AsQueryable();

           if(!string.IsNullOrWhiteSpace(queryObject.Symbol))
                comments = comments.Where(s => s.Stock.Symbol == queryObject.Symbol);

            if (queryObject.IsDecsending)
                comments = comments.OrderByDescending(s => s.CreateOn);

            return await comments.ToListAsync();
           
           
        }

        public async Task<Comment?> GetStockByIdAsync(int Id)
        {
           return await _context.Comments.Include(c => c.AppUser).FirstOrDefaultAsync(x => x.CommentId == Id);
        }

        public async Task<Comment?> UpdateCommentAsync(int Id, Comment CommentModel)
        {
            var ExistingComment = await _context.Comments.FirstOrDefaultAsync(x => x.CommentId == Id);

            if (ExistingComment == null)
                return null;

            ExistingComment.Title = CommentModel.Title;
            ExistingComment.Content = CommentModel.Content;

            await _context.SaveChangesAsync();

            return ExistingComment;
        }
    }
}
