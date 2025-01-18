using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class OrderItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid OrderId { get; set; }

        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Product? Product { get; set; }
    }
}
