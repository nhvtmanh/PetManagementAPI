using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetManagementAPI.DTOs.OrderDTOs;
using PetManagementAPI.Enums;
using PetManagementAPI.Services.Abstraction;
using System.Net.Security;
using System.Security.Claims;

namespace PetManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await _orderService.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var order = await _orderService.GetOne(id);
            if (order == null)
            {
                return NotFound(new { message = "Order not found" });
            }
            return Ok(order);
        }

        [HttpGet("get-customer-orders")]
        public async Task<IActionResult> GetCustomerOrders([FromQuery] string customerId)
        {
            var orders = await _orderService.GetCustomerOrders(customerId);
            return Ok(orders);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterOrders([FromQuery] byte status)
        {
            var orders = await _orderService.FilterOrders(status);
            return Ok(orders);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDTO checkoutDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _orderService.Checkout(checkoutDTO);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderDTO placeOrderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _orderService.PlaceOrder(placeOrderDTO);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("update-order-status")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusDTO updateOrderStatusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var order = await _orderService.UpdateOrderStatus(updateOrderStatusDTO.OrderId, updateOrderStatusDTO.OrderStatus);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
