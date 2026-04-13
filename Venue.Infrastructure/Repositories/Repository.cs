using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Venue.Domain.Common;
using Venue.Domain.Interfaces;
using Venue.Infrastructure.DbContext;

namespace Venue.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region Add
        public async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
            => await _dbSet.AddAsync(entity, cancellationToken);

        #endregion

        #region Update
        public void Update(TEntity entity)
            => _dbSet.Update(entity);
        #endregion

        #region Delete
        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            if (entity == null)
                return;

            _dbSet.Remove(entity);
        }
        #endregion

        #region Get
        public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
             => await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        public IQueryable<TEntity> GetQuery()
             => _dbSet.AsQueryable();

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> where, bool isNoTracking = false)
            => isNoTracking
                ? _dbSet.AsNoTracking().Where(where)
                : _dbSet.Where(where);
        
        public IQueryable<TResult> Get<TResult>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TResult>> select,
            bool isNoTracking = false)
                => isNoTracking
                    ? _dbSet.AsNoTracking().Where(where).Select(select)
                    : _dbSet.Where(where).Select(select);
        #endregion

        #region Any
        public async Task<bool> AnyAsync(Guid id, CancellationToken cancellationToken = default)
            => await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        #endregion
    }
}
