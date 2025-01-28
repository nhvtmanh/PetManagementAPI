using AutoMapper;
using PetManagementAPI.DTOs.CategoryDTOs;
using PetManagementAPI.DTOs.ProductDTOs;
using PetManagementAPI.DTOs.VoucherDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDTO, Category>();

            CreateMap<CreateProductDTO, Product>();
            CreateMap<UpdateProductDTO, Product>();

            CreateMap<CreateVoucherDTO, Voucher>();
            CreateMap<UpdateVoucherDTO, Voucher>();
        }
    }
}
