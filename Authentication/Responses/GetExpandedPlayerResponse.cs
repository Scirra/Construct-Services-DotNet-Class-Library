using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public sealed class GetExpandedPlayerResponse : BaseResponse
{
    [JsonProperty(PropertyName = "player")]
    public ExpandedPlayer Player { get; set; }
        
    public GetExpandedPlayerResponse(ExpandedPlayer expandedPlayer)
    {
        Player = expandedPlayer;
    }
    public GetExpandedPlayerResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}