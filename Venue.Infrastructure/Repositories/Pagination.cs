using Microsoft.EntityFrameworkCore;
using Venue.Domain.Common;
using Venue.Domain.Interfaces;

namespace Venue.Infrastructure.Repositories
{
    public class Pagination : IPagination
    {
        public Task<PagedData<T>> PagedResultAsync<T>(List<T> list, int pageNumber, int pageSize) where T : class
        {
            var skipValue = Math.Max((pageNumber - 1) * pageSize, 0);
            var pagedList = list.Skip(skipValue).Take(pageSize).ToList();

            var result = new PagedData<T>
            {
                Data = pagedList,
                TotalPages = Convert.ToInt32(Math.Ceiling((double)list.Count / pageSize)),
                CurrentPage = pageNumber,
                TotalRecords = list.Count
            };

            return Task.FromResult(result);
        }

        public async Task<PagedData<T>> PagedResultAsync<T>(IQueryable<T> query, int pageNumber, int pageSize) where T : class
        {
            query = query.AsNoTracking();
            var skipValue = Math.Max((pageNumber - 1) * pageSize, 0);

            var data = await query.Skip(skipValue).Take(pageSize).ToListAsync();
            var count = await query.CountAsync();

            var result = new PagedData<T>
            {
                Data = data,
                TotalPages = Convert.ToInt32(Math.Ceiling((double)count / pageSize)),
                CurrentPage = pageNumber,
                TotalRecords = count
            };

            return result;
        }
    }
}
