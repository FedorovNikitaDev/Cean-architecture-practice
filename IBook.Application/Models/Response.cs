namespace IBook.Application.Models;

public class Response<T>
{
    public bool IsSuccess { get; set; } = true;
    
    public T Data { get; set; }

    public string DisplayMessage { get; set; }
    
    public string[] Errors { get; set; }

    public Response()
    {
    }
    
    public Response(T data)
    {
        Data = data;
    }

    public Response(bool isSuccess, T data, string displayMessage, string[] errors)
    {
        Data = data;
        DisplayMessage = displayMessage;
        Errors = errors;
        IsSuccess = isSuccess;
    }
}