using ConstructServices.Authentication.Objects;
using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects;

public sealed class TeamPlayer
{
    [JsonProperty(PropertyName = "player")]
    public Player Player { get; private set; }

    [JsonProperty(PropertyName = "currentScore")]
    public long? CurrentScore { get; private set; }

    [JsonProperty(PropertyName = "formattedScore")]
    public string FormattedScore { get; private set; }

    public TeamPlayer()
    {

    }
}