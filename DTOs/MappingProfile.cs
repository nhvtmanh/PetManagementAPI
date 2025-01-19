using AutoMapper;
using PetManagementAPI.DTOs.CategoryDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>();
        }
    }
}
