using AutoMapper;
using PetManagementAPI.DTOs.CategoryDTOs;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Category> Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            return await _categoryRepository.Create(category);
        }

        public async Task<Category?> Delete(Guid id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }

            await _categoryRepository.Delete(category);
            return category;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category?> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            return await _categoryRepository.GetByName(name);
        }

        public async Task<Category?> Update(Guid id, CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return null;
            }

            _mapper.Map(categoryDTO, category);

            await _categoryRepository.Update(category);
            return category;
        }
    }
}
