using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;

namespace PetManagementAPI.Repositories.Implementation
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CartItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CartItem?> GetCartItem(Guid cartId, Guid productId)
        {
            return await _dbContext.CartItems
                .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(List<Guid> cartItemIds)
        {
            return await _dbContext.CartItems
                .Where(ci => cartItemIds.Contains(ci.Id))
                .Include(ci => ci.Product)
                .ToListAsync();
        }
    }
}
