using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Claims;
using Venue.Domain.Common;
using Venue.Domain.Entities;
using Venue.Domain.Interfaces;

namespace Venue.Infrastructure.DbContext
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        private readonly ICurrentUserService? _currentUserService;
        public AppDbContext(DbContextOptions options, ICurrentUserService? currentUserService = null) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Tables
        public DbSet<VenueEntity> Venues { get; set; }
        public DbSet<Review> Reviews { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var userId = _currentUserService?.UserId;

            var entities = ChangeTracker.Entries();

            foreach (var entity in entities)
            {
                if (entity.Entity is BaseEntity baseEntity)
                {
                    var now = DateTime.UtcNow;

                    if (entity.State == EntityState.Added)
                    {
                        baseEntity.CreatedAt = now;
                        baseEntity.CreatedById = userId;
                    }
                    else if (entity.State == EntityState.Modified)
                    {
                        baseEntity.UpdatedAt = now;
                        baseEntity.UpdatedById = userId;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
