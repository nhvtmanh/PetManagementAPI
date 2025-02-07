using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.CartDTOs
{
    public class UpdateCartItemDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
