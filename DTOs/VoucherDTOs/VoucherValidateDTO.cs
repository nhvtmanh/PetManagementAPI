using PetManagementAPI.Models;

namespace PetManagementAPI.DTOs.VoucherDTOs
{
    public class VoucherValidateDTO
    {
        public bool IsValid { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
