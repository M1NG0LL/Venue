namespace Venue.Domain.Common
{
    public class PagedData<T>
    {
        public required List<T> Data { get; set; }
        public required int TotalPages { get; set; }
        public required int CurrentPage { get; set; }
        public required int TotalRecords { get; set; }
    }
}
