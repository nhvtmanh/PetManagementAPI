using System.ComponentModel.DataAnnotations;

namespace PetManagementAPI.DTOs.VoucherDTOs
{
    public class UpdateVoucherDTO
    {
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
    }
}
