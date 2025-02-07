namespace PetManagementAPI.DTOs.CartDTOs
{
    public class DeleteCartItemDTO
    {
        public List<Guid> CartItemIds { get; set; } = new List<Guid>();
    }
}
