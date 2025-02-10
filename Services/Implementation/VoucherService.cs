using AutoMapper;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using PetManagementAPI.Data;
using PetManagementAPI.DTOs.VoucherDTOs;
using PetManagementAPI.Enums;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;
using PetManagementAPI.Services.Abstraction;

namespace PetManagementAPI.Services.Implementation
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IMapper _mapper;

        public VoucherService(IVoucherRepository voucherRepository, IMapper mapper)
        {
            _mapper = mapper;
            _voucherRepository = voucherRepository;
        }

        public async Task<Voucher> Create(CreateVoucherDTO voucherDTO)
        {
            var voucher = _mapper.Map<Voucher>(voucherDTO);

            // Set voucher status to inactive by default
            voucher.Status = (byte)VoucherStatus.Inactive;

            return await _voucherRepository.Create(voucher);
        }

        public async Task<Voucher?> Delete(Guid id)
        {
            var voucher = await _voucherRepository.GetById(id);
            if (voucher == null)
            {
                return null;
            }

            await _voucherRepository.Delete(voucher);
            return voucher;
        }

        public async Task<IEnumerable<Voucher>> GetAll()
        {
            return await _voucherRepository.GetAll();
        }

        public async Task<Voucher?> GetById(Guid id)
        {
            return await _voucherRepository.GetById(id);
        }

        public async Task<IEnumerable<Voucher>> GetByName(string name)
        {
            return await _voucherRepository.GetByName(name);
        }

        public async Task<VoucherValidateDTO> IsValid(string code)
        {
            var voucherValidateDTO = new VoucherValidateDTO
            {
                IsValid = false,
                Voucher = await _voucherRepository.GetByCode(code)
            };

            // Check if voucher exists
            if (voucherValidateDTO.Voucher == null)
            {
                return voucherValidateDTO;
            }

            // Check if voucher is active
            if (voucherValidateDTO.Voucher!.Status != (byte)VoucherStatus.Active)
            {
                return voucherValidateDTO;
            }

            // Check if voucher is expired
            if (DateTime.Now >= voucherValidateDTO.Voucher.ExpirationDate)
            {
                return voucherValidateDTO;
            }

            // Check if current usage is less than the maximum usage
            if (voucherValidateDTO.Voucher.CurrentUsageCount >= voucherValidateDTO.Voucher.MaxUsageCount)
            {
                return voucherValidateDTO;
            }

            voucherValidateDTO.IsValid = true;
            return voucherValidateDTO;
        }

        public async Task<Voucher?> Update(Guid id, UpdateVoucherDTO voucherDTO)
        {
            var voucher = await _voucherRepository.GetById(id);
            if (voucher == null)
            {
                return null;
            }

            _mapper.Map(voucherDTO, voucher);

            await _voucherRepository.Update(voucher);
            return voucher;
        }
    }
}
