using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.CommentDTOs
{
    public class CommentDTO
    {
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        public Guid ProductId { get; set; }

        [StringLength(255)]
        [Required]
        public string Comment { get; set; } = string.Empty;
    }
}
