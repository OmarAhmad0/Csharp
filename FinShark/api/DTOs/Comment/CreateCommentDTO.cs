using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Comment
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5,ErrorMessage = "Must be 5 characters")]
        [MaxLength(200 , ErrorMessage = "Can not be more then 200 characters")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Must be 5 characters")]
        [MaxLength(200, ErrorMessage = "Can not be more then 200 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
