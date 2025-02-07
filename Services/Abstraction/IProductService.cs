using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product?> GetById(Guid id);
        Task<IEnumerable<Product>> GetByName(string name);

        Task<Product> Create(CreateProductDTO productDTO);
        Task<Product?> Update(Guid id, UpdateProductDTO productDTO);
        Task<Product?> Delete(Guid id);
    }
}
