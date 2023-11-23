using Entities;

namespace CrudApi.Contracts
{
    public interface IAbstractRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task AddAsync(T entity);
        //Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task DeleteAsync(T entity);
        Task SaveChangesAsync();
    }
}
