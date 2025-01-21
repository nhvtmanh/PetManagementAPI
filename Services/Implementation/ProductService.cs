using AutoMapper;
using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Create(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            return await _productRepository.Create(product);
        }

        public async Task<Product?> Delete(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }

            await _productRepository.Delete(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product?> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product?> Update(Guid id, UpdateProductDTO productDTO)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return null;
            }

            _mapper.Map(productDTO, product);

            await _productRepository.Update(product);
            return product;
        }
    }
}
