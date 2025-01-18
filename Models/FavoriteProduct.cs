using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class FavoriteProduct
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
