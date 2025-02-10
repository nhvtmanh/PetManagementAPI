using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.OrderDTOs
{
    public class UpdateOrderStatusDTO
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public byte OrderStatus { get; set; }

    }
}
