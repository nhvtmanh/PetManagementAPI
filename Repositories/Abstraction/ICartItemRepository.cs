using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem?> GetCartItem(Guid cartId, Guid productId);
        Task<IEnumerable<CartItem>> GetCartItems(List<Guid> cartItemIds);

        Task DeleteCartItems(IEnumerable<CartItem> cartItems);
        Task DeleteCartItemsByProductIds(List<Guid> productIds);
    }
}
