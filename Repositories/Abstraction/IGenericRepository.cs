namespace PetManagementAPI.Repositories.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<bool> Exists(Guid id);
    }
}
