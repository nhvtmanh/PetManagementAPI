using PetManagementAPI.DTOs.OrderDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IOrderService
    {
        Task<Order> Checkout(CheckoutDTO checkoutDTO);
        Task<Order> PlaceOrder(PlaceOrderDTO placeOrderDTO);
        Task ProcessAfterPlaceOrder(Order order);
    }
}
