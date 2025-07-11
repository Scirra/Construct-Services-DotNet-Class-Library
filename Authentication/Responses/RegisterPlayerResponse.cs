using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public class RegisterPlayerResponse : BaseResponse
{
    [JsonProperty(PropertyName = "player")]
    public Player Player { get; set; }

    [JsonProperty(PropertyName = "session")]
    public Session Session { get; set; }

    public RegisterPlayerResponse()
    {
    }
    public RegisterPlayerResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {
    }
}