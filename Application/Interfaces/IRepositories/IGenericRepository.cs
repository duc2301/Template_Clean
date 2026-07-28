using System.Linq.Expressions;


namespace Application.Interfaces.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate, string includeProperties = "");
        Task<T?> GetByIdAsync(Guid? id);
        Task<T?> GetByIdAsync(int? id);
        Task CreateAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(Guid id);
        void DeleteById(int id);
        Task CreateRangeAsync(IEnumerable<T> entities);
    }
}
