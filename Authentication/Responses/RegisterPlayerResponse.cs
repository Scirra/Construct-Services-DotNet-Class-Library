using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public sealed class CreatePlayerResponse : BaseResponse
{
    [JsonProperty(PropertyName = "player")]
    public Player Player { get; set; }

    [JsonProperty(PropertyName = "session")]
    public Session Session { get; set; }

    public CreatePlayerResponse()
    {
    }
    public CreatePlayerResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}