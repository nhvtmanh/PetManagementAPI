using AutoMapper;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;
using PetManagementAPI.Services.Integrate;

namespace PetManagementAPI.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CloudinaryService _cloudinaryService;

        public ProductService(IProductRepository productRepository, IMapper mapper, CloudinaryService cloudinaryService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Product> Create(CreateProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);

            product.ImageUrl = await _cloudinaryService.UploadImage(productDTO.Image!, "products");

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

            // Check if image is updated
            if (productDTO.Image != null)
            {
                product.ImageUrl = await _cloudinaryService.UploadImage(productDTO.Image, "products");
            }

            await _productRepository.Update(product);
            return product;
        }
    }
}
