using PetManagementAPI.DTOs.CategoryDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category?> GetById(Guid id);
        Task<IEnumerable<Category>> GetByName(string name);
        Task<Category> Create(CategoryDTO categoryDTO);
        Task<Category?> Update(Guid id, CategoryDTO categoryDTO);
        Task<Category?> Delete(Guid id);
    }
}
