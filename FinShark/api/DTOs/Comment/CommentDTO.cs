namespace api.DTOs.Comment
{
    public class CommentDTO
    {
        public int CommentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreateOn { get; set; }
        public int? StockId { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
