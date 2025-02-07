﻿using PetManagementAPI.Models;

namespace PetManagementAPI.Repositories.Abstraction
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetByName(string name);
        Task<IEnumerable<Product>> GetByCategory(string name);
        Task<IEnumerable<FavoriteProduct>> GetFavorite(string customerId);

        Task<FavoriteProduct?> AddFavorite(string customerId, Guid productId);
        Task<FavoriteProduct?> DeleteFavorite(string customerId, Guid productId);
    }
}
