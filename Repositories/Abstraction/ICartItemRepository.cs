using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<CartItem?> GetCartItem(Guid cartId, Guid productId);
    }
}
