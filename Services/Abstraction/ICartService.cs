using PetManagementAPI.DTOs.CartDTOs;
using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface ICartService
    {
        Task<Cart> GetCart(string customerId);

        Task<CartItem> AddToCart(Guid cartId, Guid productId, int quantity);

        Task<CartItem> UpdateCartItem(UpdateCartItemDTO updateCartItemDTO);

        Task DeleteCartItems(List<Guid> cartItemIds);
    }
}
