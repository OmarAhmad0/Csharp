using api.DTOs.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment CommentModel)
        {
            return new CommentDTO
            {
                CommentId = CommentModel.CommentId,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                CreateOn = CommentModel.CreateOn,
                CreatedBy = CommentModel.AppUser.UserName,
                StockId = CommentModel.StockId
            };
        }

        public static Comment ToCreateCommentDTO(this CreateCommentDTO CommentDto, int StockId)
        {
            return new Comment
            {
                Title = CommentDto.Title,
                Content = CommentDto.Content,
                StockId = StockId
            };
        }

        public static Comment ToUpdateCommentDTO(this UpdateCommentDTO CommentDto)
        {
            return new Comment
            {
                Title = CommentDto.Title,
                Content = CommentDto.Content,
            };
        }
    }
}
