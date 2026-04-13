using Microsoft.EntityFrameworkCore;
using Venue.Domain.Interfaces;
using Venue.Infrastructure.DbContext;

namespace Venue.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default) 
            => await _dbContext.SaveChangesAsync(cancellationToken) > 0;
    }
}
