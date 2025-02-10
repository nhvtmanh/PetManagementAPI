using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order?> GetOrderDetails(Guid orderId);
        Task<IEnumerable<Order>> GetCustomerOrders(string customerId);
    }
}
