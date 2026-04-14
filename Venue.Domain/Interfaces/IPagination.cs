using Venue.Domain.Common;

namespace Venue.Domain.Interfaces
{
    public interface IPagination
    {
        Task<PagedData<T>> PagedResultAsync<T>(List<T> list, int pageNumber, int pageSize) where T : class;
        Task<PagedData<T>> PagedResultAsync<T>(IQueryable<T> query, int pageNumber, int pageSize, CancellationToken cancellationToken = default) where T : class;
    }
}
