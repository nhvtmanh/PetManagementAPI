using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.DTOs.DashboardDTOs;
using PetManagementAPI.Enums;
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

        public async Task<OrderDashboardData> GetOrderDashboardData()
        {
            var totalOrders = await _dbContext.Orders.CountAsync();

            var totalOrdersProcessing = await _dbContext.Orders.CountAsync(x => x.Status == (byte)OrderStatus.Processing);
            var totalOrdersShipping = await _dbContext.Orders.CountAsync(x => x.Status == (byte)OrderStatus.Shipping);
            var totalOrdersDelivered = await _dbContext.Orders.CountAsync(x => x.Status == (byte)OrderStatus.Delivered);
            var totalOrdersCancelled = await _dbContext.Orders.CountAsync(x => x.Status == (byte)OrderStatus.Cancelled);
            
            var totalRevenue = await _dbContext.Orders.Where(x => x.Status == (byte)OrderStatus.Delivered).SumAsync(x => x.Total);
            
            var revenueByDays = await _dbContext.Orders
                .Where(x => x.Status == (byte)OrderStatus.Delivered)
                .GroupBy(x => x.OrderDate.Date)
                .Select(x => new RevenueByDayDTO
                {
                    Date = DateOnly.FromDateTime(x.Key),
                    Revenue = x.Sum(x => x.Total)
                })
                .OrderBy(x => x.Date)
                .ToListAsync();

            var orderDashboardData = new OrderDashboardData
            {
                TotalOrders = totalOrders,
                TotalOrdersProcessing = totalOrdersProcessing,
                TotalOrdersShipping = totalOrdersShipping,
                TotalOrdersDelivered = totalOrdersDelivered,
                TotalOrdersCancelled = totalOrdersCancelled,
                TotalRevenue = totalRevenue,
                RevenueByDays = revenueByDays
            };
            return orderDashboardData;
        }
    }
}
