using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.ProductDTOs
{
    public class UpdateProductDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int StockQuantity { get; set; }

        [Required]
        public decimal BasePrice { get; set; }

        [Required]
        public decimal DiscountPrice { get; set; }

        public IFormFile? Image { get; set; }

        public Guid CategoryId { get; set; }
    }
}
