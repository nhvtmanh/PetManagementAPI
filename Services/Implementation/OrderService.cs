using AutoMapper;
using PetManagementAPI.DTOs.OrderDTOs;
using PetManagementAPI.Enums;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IVoucherService _voucherService;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, ICartItemRepository cartItemRepository, IVoucherService voucherService, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _cartItemRepository = cartItemRepository;
            _voucherService = voucherService;
            _mapper = mapper;
        }

        public async Task<Order> Checkout(CheckoutDTO checkoutDTO)
        {
            // Validate cart items
            var cartItems = await _cartItemRepository.GetCartItems(checkoutDTO.CartItemIds);

            if (cartItems.Count() == 0)
            {
                throw new Exception("No cart items found");
            }

            // Check quantity in stock
            foreach (var item in cartItems)
            {
                if (item.Quantity > item.Product!.StockQuantity)
                {
                    throw new Exception($"{item.Product.Name} is out of stock");
                }
            }

            // Create order with status "Pending"
            var order = new Order
            {
                Status = (byte)OrderStatus.Pending,
                Total = cartItems.Sum(ci => ci.Product!.DiscountPrice * ci.Quantity),
                CustomerId = checkoutDTO.CustomerId
            };

            // Validate voucher
            if (!string.IsNullOrEmpty(checkoutDTO.VoucherCode))
            {
                var voucherValidateDTO = await _voucherService.IsValid(checkoutDTO.VoucherCode);

                if (!voucherValidateDTO.IsValid)
                {
                    throw new Exception("Invalid voucher");
                }

                // Apply voucher
                var voucher = voucherValidateDTO.Voucher;

                order.VoucherId = voucher!.Id;
                order.Total = order.Total * (1 - (decimal)voucher.DiscountAmount / 100);
            }

            // Save order to database
            order = await _orderRepository.Create(order);

            // Create order items
            var orderItems = cartItems.Select(ci => new OrderItem
            {
                OrderId = order.Id,
                ProductId = ci.ProductId,
                Quantity = ci.Quantity
            });

            order.OrderItems = orderItems.ToList();
            await _orderRepository.Update(order);

            return order;
        }
    }
}
