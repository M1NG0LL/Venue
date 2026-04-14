namespace Venue.Application.Common
{
    public class ResponseBase
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; } = null;

        public static ResponseBase Success(string message = "Operation completed successfully")
            => new ResponseBase()
            {
                IsSuccess = true,
                Message = message,
                Errors = null
            };

        public static ResponseBase Failure(string message, List<string>? errors = null)
            => new ResponseBase()
            {
                IsSuccess = false,
                Message = message,
                Errors = errors
            };
    }

    public class ResponseBase<T> : ResponseBase
    {
        public T? Data { get; set; }

        public static ResponseBase<T> Success(T data, string message = "Operation completed successfully")
            => new ResponseBase<T>()
            {
                IsSuccess = true,
                Message = message,
                Errors = null,
                Data = data
            };

        public static new ResponseBase<T> Failure(string message, List<string>? errors = null)
        {
            return new ResponseBase<T>()
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                Data = default
            };
        }
    }

    public class PaginatedResponseBase<T> : ResponseBase<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public static PaginatedResponseBase<T> Success(T? data, int pageNumber, int pageSize, int totalCount, string message = "Operation completed successfully")
            => new PaginatedResponseBase<T>()
            {
                IsSuccess = true,
                Message = message,
                Errors = null,
                Data = data,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount
            };

        public static new PaginatedResponseBase<T> Failure(string message, List<string>? errors = null)
            => new PaginatedResponseBase<T>()
            {
                IsSuccess = false,
                Message = message,
                Errors = errors,
                Data = default
            };
    }
}
