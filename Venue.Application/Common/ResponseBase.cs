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
    }
}
