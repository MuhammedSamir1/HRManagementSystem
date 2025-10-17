using HRManagementSystem.Common.Data.Enums;

namespace HRManagementSystem.Common.Views.Response
{
    public record RequestResult<T>(T data, bool isSuccess, string message, ErrorCode errorCode)
    {
        public static RequestResult<T> Success(T data, string message = "Request was successful") =>
            new RequestResult<T>(data, true, message, ErrorCode.None);
        public static RequestResult<T> Failure(string message, ErrorCode errorCode = ErrorCode.None) =>
            new RequestResult<T>(default!, false, message, errorCode);
        public static RequestResult<T> Failure(ErrorCode errorCode) =>
            new RequestResult<T>(default!, false, errorCode.ToString(), errorCode);
    }
}
