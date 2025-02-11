using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.UserDTOs
{
    public class RegisterDTO
    {
        [StringLength(50)]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [StringLength(50)]
        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [StringLength(255)]
        [Required]
        public string Password { get; set; } = string.Empty;

        [StringLength(50)]
        [Required]
        public string FullName { get; set; } = string.Empty;

        [StringLength(10)]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(255)]
        [Required]
        public string Address { get; set; } = string.Empty;

        [StringLength(255)]
        public string? AvatarUrl { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}
