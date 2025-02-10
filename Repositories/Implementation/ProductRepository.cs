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

        public async Task<FavoriteProduct?> AddFavorite(string customerId, Guid productId)
        {
            if (!_dbContext.FavoriteProducts.Any(x => x.CustomerId == customerId && x.ProductId == productId))
            {
                var favoriteProduct = new FavoriteProduct
                {
                    CustomerId = customerId,
                    ProductId = productId
                };

                _dbContext.FavoriteProducts.Add(favoriteProduct);
                await _dbContext.SaveChangesAsync();

                return favoriteProduct;
            }
            return null;
        }

        public async Task<FavoriteProduct?> DeleteFavorite(string customerId, Guid productId)
        {
            var favoriteProduct = await _dbContext.FavoriteProducts
                .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.ProductId == productId);

            if (favoriteProduct != null)
            {
                _dbContext.FavoriteProducts.Remove(favoriteProduct);
                await _dbContext.SaveChangesAsync();
                return favoriteProduct;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetByCategory(string name)
        {
            return await _dbContext.Products
                .Where(x => x.Category!.Name == name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByName(string name)
        {
            return await _dbContext.Products
                .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }

        public async Task<IEnumerable<FavoriteProduct>> GetFavorite(string customerId)
        {
            return await _dbContext.FavoriteProducts
                .Include(x => x.Product)
                .Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Product?> GetProductDetails(Guid id)
        {
            return await _dbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
