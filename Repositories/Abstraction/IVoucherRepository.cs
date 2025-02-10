using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface IVoucherRepository : IGenericRepository<Voucher>
    {
        Task<Voucher?> GetByCode(string code);
        Task<IEnumerable<Voucher>> GetByName(string name);
    }
}
