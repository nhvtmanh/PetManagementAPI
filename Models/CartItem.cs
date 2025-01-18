using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid CartId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Product? Product { get; set; }
    }
}
