using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.FavoriteDTOs
{
    public class AddFavoriteDTO
    {
        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [Required]
        public Guid ProductId { get; set; }
    }
}
