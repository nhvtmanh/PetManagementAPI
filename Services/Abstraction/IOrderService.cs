using PetManagementAPI.DTOs.OrderDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order?> GetOne(Guid id);
        Task<IEnumerable<Order>> GetCustomerOrders(string customerId);

        Task<Order> Checkout(CheckoutDTO checkoutDTO);
        Task<Order> PlaceOrder(PlaceOrderDTO placeOrderDTO);
        Task ProcessAfterPlaceOrder(Order order);
        Task<Order> UpdateOrderStatus(Guid orderId, byte status);
    }
}
