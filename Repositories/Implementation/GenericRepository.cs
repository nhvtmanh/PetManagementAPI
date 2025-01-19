using Microsoft.EntityFrameworkCore;
using PetManagementAPI.Data;
using PetManagementAPI.Repositories.Abstraction;

namespace PetManagementAPI.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Create(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Detached;
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            var entity = await GetById(id);
            return entity != null;
        }
    }
}
