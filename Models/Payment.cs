using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Payment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public bool PaymentMethod { get; set; }

        [Required]
        public byte Status { get; set; }
    }
}
