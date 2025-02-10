using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.Models;
using PetManagementAPI.Repositories.Abstraction;

namespace PetManagementAPI.Repositories.Implementation
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public VoucherRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Voucher>> FilterVouchers(byte status)
        {
            return await _dbContext.Vouchers
                .Where(v => v.Status == status)
                .ToListAsync();
        }

        public async Task<Voucher?> GetByCode(string code)
        {
            return await _dbContext.Vouchers
                .FirstOrDefaultAsync(v => v.Code == code);
        }

        public async Task<IEnumerable<Voucher>> GetByName(string name)
        {
            return await _dbContext.Vouchers
                .Where(v => v.Code.ToLower().Contains(name.ToLower()))
                .ToListAsync();
        }
    }
}
