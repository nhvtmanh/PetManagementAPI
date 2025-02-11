using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        [StringLength(50)]
        [Required]
        public string FullName { get; set; } = string.Empty;

        [StringLength(255)]
        [Required]
        public string Address { get; set; } = string.Empty;

        [StringLength(255)]
        public string? AvatarUrl { get; set; }

        [Required]
        public bool Gender { get; set; }
    }
}
