using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
