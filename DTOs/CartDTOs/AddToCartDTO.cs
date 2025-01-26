using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.CartDTOs
{
    public class AddToCartDTO
    {
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
