namespace ConstructServices.Common;

public class GenericMethodResult
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public GenericMethodResult(bool success, string message = null)
    {
        Success = success;
        Message = message;
    }
}