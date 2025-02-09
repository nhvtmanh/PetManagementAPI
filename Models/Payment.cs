using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; } = string.Empty;

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public string PaymentMethod { get; set; } = string.Empty;
    }
}
