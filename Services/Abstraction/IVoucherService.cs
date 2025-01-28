﻿using PetManagementAPI.DTOs.VoucherDTOs;
using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IVoucherService
    {
        Task<IEnumerable<Voucher>> GetAll();
        Task<Voucher?> GetById(Guid id);
        Task<Voucher> Create(CreateVoucherDTO voucherDTO);
        Task<Voucher?> Update(Guid id, UpdateVoucherDTO voucherDTO);
        Task<Voucher?> Delete(Guid id);
    }
}
