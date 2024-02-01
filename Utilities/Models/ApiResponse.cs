using Utilities.Enums;
using Utilities.Extensions;

namespace Utilities.Models;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; } = true;
    public int Success { get; set; }
    public string ErrorMessage { get; set; }
    public T Data { get; set; }

    public ApiResponse()
    {
        IsSuccess = true;
        Success = ResponseStatus.Success.ToInt();
        ErrorMessage = string.Empty;
    }

    public ApiResponse(T result)
    {
        IsSuccess = true;
        Success = ResponseStatus.Success.ToInt();
        Data = result;
        ErrorMessage = string.Empty;
    }

    public ApiResponse(string errorMessage)
    {
        IsSuccess = false;
        Success = ResponseStatus.Error.ToInt();
        ErrorMessage = errorMessage;
    }

    public ApiResponse(ResponseStatus responseStatus)
    {
        IsSuccess = false;
        Success = responseStatus.ToInt();
        ErrorMessage = responseStatus.GetDescription();
    }

    public ApiResponse(ResponseStatus responseStatus, string errorMessage)
    {
        IsSuccess = false;
        Success = responseStatus.ToInt();
        ErrorMessage = errorMessage;
    }


    public ApiResponse(Exception ex)
    {
        IsSuccess = false;
        Success = ResponseStatus.Error.ToInt();
        ErrorMessage = ex.Message;
    }
}
