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
    }
}
