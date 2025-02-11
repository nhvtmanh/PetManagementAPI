using PetManagementAPI.Models;

namespace PetManagementAPI.Services.Abstraction
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
