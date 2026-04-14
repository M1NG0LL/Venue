using Venue.Application.Common;

namespace Venue.Application.Dtos.Common
{
    public abstract class BaseDto
    {
        public required Guid Id { get; set; }
    }

    public abstract class BaseSearchDto
    {
        public int PageSize { get; set; } = 15;
        public int PageNumber { get; set; } = 1;
        public string? SearchText { get; set; }

        public SortByType SortByType { get; set; } = SortByType.Ascending;
    }

    public interface BaseUpdateDto
    {
        Guid Id { get; set; }
    }
}
