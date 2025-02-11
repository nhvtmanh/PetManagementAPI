namespace PetManagementAPI.DTOs.DashboardDTOs
{
    public class ProductDashboardData
    {
        public int TotalProducts { get; set; }
        public List<TopSellingProductDTO> TopSellingProducts { get; set; } = new List<TopSellingProductDTO>();
    }
}
