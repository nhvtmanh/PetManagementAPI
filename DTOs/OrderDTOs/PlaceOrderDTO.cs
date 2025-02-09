using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace PetManagementAPI.DTOs.OrderDTOs
{
    public class PlaceOrderDTO
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public byte PaymentMethod { get; set; } = 0;
    }
}
