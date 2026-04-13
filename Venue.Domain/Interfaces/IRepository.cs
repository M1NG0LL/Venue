using System.Linq.Expressions;
using Venue.Domain.Common;

namespace Venue.Domain.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQuery();

        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where, bool isNoTracking = false);
        IQueryable<TResult> Get<TResult>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TResult>> select, bool isNoTracking = false);

        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default);

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
