using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart?> GetCartByCustomerId(string customerId);
    }
}
