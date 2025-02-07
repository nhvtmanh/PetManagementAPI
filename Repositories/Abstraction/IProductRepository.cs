using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
    }
}
