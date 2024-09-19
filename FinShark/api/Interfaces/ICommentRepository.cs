
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsAsync(CommentQueryObject queryObject);
        Task<Comment?> GetStockByIdAsync(int Id);

        Task<Comment> CreateCommentAsync( Comment CommentModel);
        Task<Comment?> UpdateCommentAsync(int Id, Comment CommentModel);

        Task<Comment?> DeleteCommentAsync(int Id);
    }
}
