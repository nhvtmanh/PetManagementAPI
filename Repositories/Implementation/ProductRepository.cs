using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;

namespace PetManagementAPI.Repositories.Implementation
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _dbContext.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }
    }
}
