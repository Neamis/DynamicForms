using System.Linq.Expressions;
using DynamicForms.Domain;

namespace DynamicForms.Database.EfCore.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
            params Expression<Func<T, object>>[] includeProperties);

        Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
    }
}