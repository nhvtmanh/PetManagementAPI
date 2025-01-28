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
    }
}
