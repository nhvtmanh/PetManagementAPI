using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(ICartRepository cartRepository, ICartItemRepository cartItemRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartItem> AddToCart(Guid cartId, Guid productId, int quantity)
        {
            var cartItem = await _cartItemRepository.GetCartItem(cartId, productId);
            if (cartItem == null)
            {
                // Create a new cart item
                var newCartItem = new CartItem
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = quantity
                };

                return await _cartItemRepository.Create(newCartItem);
            }
            else
            {
                // Cart item is already in the cart --> Update the quantity
                cartItem.Quantity += quantity;

                await _cartItemRepository.Update(cartItem);
                return cartItem;
            }
        }

        public async Task<Cart> GetCart(string customerId)
        {
            // Check if customer has a cart
            var cart = await _cartRepository.GetCartByCustomerId(customerId);
            if (cart == null)
            {
                // Create a new cart
                var newCart = new Cart
                {
                    CustomerId = customerId
                };

                return await _cartRepository.Create(newCart);
            }

            return cart;
        }
    }
}
