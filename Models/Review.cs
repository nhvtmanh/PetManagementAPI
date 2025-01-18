using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Comment { get; set; } = string.Empty;

        [Required]
        public DateTime ReviewDate { get; set; }
    }
}
