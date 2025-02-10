using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;

namespace PetManagementAPI.Repositories.Implementation
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> FilterOrders(byte status)
        {
            return await _dbContext.Orders
                .Where(x => x.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(string customerId)
        {
            return await _dbContext.Orders
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order?> GetOrderDetails(Guid orderId)
        {
            return await _dbContext.Orders
                .Include(o => o.Voucher)
                .Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                .Include(o => o.Payment)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }
    }
}
