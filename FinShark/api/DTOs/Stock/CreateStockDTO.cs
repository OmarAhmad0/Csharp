using System.ComponentModel.DataAnnotations;

namespace api.DTOs.Stock
{
    public class CreateStockDTO
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Can not be more then 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(20, ErrorMessage = "Can not be more then 20 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1,1000000000000)]
        public decimal Purchase { get; set; }

        [Required]
        [Range(0.001 , 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Can not be more then 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000000)]
        public long MarketCap { get; set; }
    }
}
