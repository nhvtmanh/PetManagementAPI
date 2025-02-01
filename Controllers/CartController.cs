using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetManagementAPI.DTOs.CartDTOs;
using PetManagementAPI.Services.Abstraction;
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

        [HttpPost("add-to-cart")]
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
    }
}
