namespace Venue.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
