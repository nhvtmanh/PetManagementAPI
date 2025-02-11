using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.DTOs.DashboardDTOs;
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

        public async Task<FavoriteProduct> AddFavorite(string customerId, Guid productId)
        {
            var favoriteProduct = await _dbContext.FavoriteProducts
                .FirstOrDefaultAsync(x => x.CustomerId == customerId && x.ProductId == productId);

            // If the product is already in favorites -> remove
            if (favoriteProduct != null)
            {
                _dbContext.FavoriteProducts.Remove(favoriteProduct);
                await _dbContext.SaveChangesAsync();

                return favoriteProduct;
            }

            // If the product is not in favorites -> add
            favoriteProduct = new FavoriteProduct
            {
                CustomerId = customerId,
                ProductId = productId
            };
            _dbContext.FavoriteProducts.Add(favoriteProduct);
            await _dbContext.SaveChangesAsync();

            return favoriteProduct;
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

        public async Task<ProductDashboardData> GetProductDashboardData()
        {
            var productDashboardData = new ProductDashboardData
            {
                TotalProducts = await _dbContext.Products.CountAsync(),
                TopSellingProducts = await _dbContext.Products
                    .OrderByDescending(p => p.SoldQuantity)
                    .Take(5)
                    .Select(p => new TopSellingProductDTO
                    {
                        ProductName = p.Name,
                        SoldQuantity = p.SoldQuantity,
                        ImageUrl = p.ImageUrl!
                    })
                    .ToListAsync()
            };
            return productDashboardData;
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
