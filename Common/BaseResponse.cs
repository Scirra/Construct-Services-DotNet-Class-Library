using JetBrains.Annotations;
using Newtonsoft.Json;

namespace ConstructServices.Common;

public class BaseResponse
{
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; private protected set; }

    [JsonProperty(PropertyName = "errorMessage")]
    public string ErrorMessage { get; private protected set; }
    public bool ShouldSerializeErrorMessage() => !Success;

    [JsonProperty(PropertyName = "shouldRetry")]
    public bool ShouldRetry { get; private set; }
    public bool ShouldSerializeShouldRetry() => !Success;

    public BaseResponse()
    {
        Success = true;
    }
    public BaseResponse(string errorMessage, bool shouldRetry = false)
    {
        Success = false;
        ErrorMessage = errorMessage;
        ShouldRetry = shouldRetry;
    }


    [UsedImplicitly]
    public string RawJson { get; private set; }

    private object RawObject_ { get; set; }

    [UsedImplicitly]
    public dynamic RawObject
    {
        get
        {
            if (string.IsNullOrWhiteSpace(RawJson)) return null;
            RawObject_ ??= JsonConvert.SerializeObject(RawJson);
            return RawObject_;
        }
    }

    internal void SetRawJson(string json)
    {
        RawJson = json;
    }
}
