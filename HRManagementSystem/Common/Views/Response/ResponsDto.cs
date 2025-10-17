using HRManagementSystem.Common.Data.Enums;

namespace HRManagementSystem.Common.Views.Response
{
    public record ResponseDto<T>(T data, bool isSuccess, string message, ErrorCode errorCode)
    {
        public static ResponseDto<T> Success(T data, string message = "Request was successful") =>
            new ResponseDto<T>(data, true, message, ErrorCode.None);
        public static ResponseDto<T> Failure(string message, ErrorCode errorCode = ErrorCode.None) =>
            new ResponseDto<T>(default!, false, message, errorCode);
        public static ResponseDto<T> Failure(ErrorCode errorCode) =>
            new ResponseDto<T>(default!, false, errorCode.ToString(), errorCode);
    }
}
