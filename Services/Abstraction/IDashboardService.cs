using PetManagementAPI.DTOs.DashboardDTOs;

namespace PetManagementAPI.Services.Abstraction
{
    public interface IDashboardService
    {
        Task<DashboardDTO> GetDashboardData();
    }
}
