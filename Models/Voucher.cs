using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.Models
{
    public class Voucher
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public int DiscountAmount { get; set; }

        [Required]
        public DateTime ExpirationDate { get; set; }

        [Required]
        public byte Status { get; set; }

        [Required]
        public int MaxUsageCount { get; set; }

        public int CurrentUsageCount { get; set; }
    }
}
