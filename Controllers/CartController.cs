using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetManagementAPI.DTOs.CartDTOs;
using PetManagementAPI.DTOs.OrderDTOs;
using PetManagementAPI.Services.Abstraction;
using PetManagementAPI.Services.Implementation;
using System.Security.Claims;

namespace PetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("get-cart")]
        public async Task<IActionResult> GetCart(string customerId)
        {
            var cart = await _cartService.GetCart(customerId);
            return Ok(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDTO cartDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (cartDTO.Quantity <= 0)
            {
                return BadRequest(new { message = "Quantity must be greater than 0" });
            }

            var cart = await _cartService.GetCart(cartDTO.CustomerId);

            var cartItem = await _cartService.AddToCart(cart.Id, cartDTO.ProductId, cartDTO.Quantity);
            return Ok(cartItem);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItem([FromBody] UpdateCartItemDTO updateCartItemDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cartItem = await _cartService.UpdateCartItem(updateCartItemDTO);
                return Ok(cartItem);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCartItems([FromBody] DeleteCartItemDTO deleteCartItemDTO)
        {
            try
            {
                await _cartService.DeleteCartItems(deleteCartItemDTO.CartItemIds);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
