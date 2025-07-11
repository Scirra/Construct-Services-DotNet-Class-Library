using Newtonsoft.Json;

namespace ConstructServices.Common;

public class BaseResponse
{
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; private protected set; }

    [JsonProperty(PropertyName = "errorMessage")]
    public string ErrorMessage { get; private protected set; }
    public bool ShouldSerializeErrorMessage() => Success == false;

    [JsonProperty(PropertyName = "shouldRetry")]
    public bool ShouldRetry { get; private set; }
    public bool ShouldSerializeShouldRetry() => !Success;

    protected BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(string errorMessage, bool shouldRetry)
    {
        Success = false;
        ErrorMessage = errorMessage;
        ShouldRetry = shouldRetry;
    }
}
