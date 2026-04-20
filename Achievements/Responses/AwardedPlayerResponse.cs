using ConstructServices.Achievements.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConstructServices.Achievements.Responses;

public sealed class AwardedPlayersResponse : BaseResponse
{    
    [JsonProperty(PropertyName = "pagination")]
    public Pagination Pagination { get; set; }
    
    [JsonProperty(PropertyName = "achievement")]
    public Achievement Achievement { get; set; }

    [JsonProperty(PropertyName = "awardedPlayers")]
    public List<AwardedPlayer> AwardedPlayers { get; set; }

    public AwardedPlayersResponse()
    {

    }
    public AwardedPlayersResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {

    }
}