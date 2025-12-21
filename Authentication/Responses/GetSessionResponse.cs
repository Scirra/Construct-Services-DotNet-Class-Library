using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public sealed class GetSessionResponse : BaseResponse
{
    [JsonProperty(PropertyName = "session")]
    public Session Session { get; set; }

    public GetSessionResponse()
    {
    }
    public GetSessionResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {
    }
}