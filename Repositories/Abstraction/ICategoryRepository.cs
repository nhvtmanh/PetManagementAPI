using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<IEnumerable<Category>> GetByName(string name);
    }
}
