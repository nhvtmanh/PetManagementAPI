using PetManagementAPI.DTOs.DashboardDTOs;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class DashboardService : IDashboardService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public DashboardService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<DashboardDTO> GetDashboardData()
        {
            var productDashboardData = await _productRepository.GetProductDashboardData();
            var orderDashboardData = await _orderRepository.GetOrderDashboardData();

            return new DashboardDTO
            {
                ProductDashboardData = productDashboardData,
                OrderDashboardData = orderDashboardData
            };
        }
    }
}
