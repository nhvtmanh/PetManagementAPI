using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.UserDTOs
{
    public class LoginDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
