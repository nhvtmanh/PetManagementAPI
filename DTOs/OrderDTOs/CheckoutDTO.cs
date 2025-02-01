using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.OrderDTOs
{
    public class CheckoutDTO
    {
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        public List<Guid> CartItemIds { get; set; } = new List<Guid>();

        [StringLength(50)]
        public string? VoucherCode { get; set; }
    }
}
