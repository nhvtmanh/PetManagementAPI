using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.CategoryDTOs
{
    public class CategoryDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
    }
}
