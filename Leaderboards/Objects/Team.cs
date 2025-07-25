using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Objects;

public class Team
{
    [JsonProperty(PropertyName = "teamID")]
    public Guid ID { get; private set; }

    [JsonProperty(PropertyName = "dateCreated")]
    public DateTime DateCreated { get; private set; }

    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set; }

    [JsonProperty(PropertyName = "rank")]
    public int? Rank { get; private set; }

    [JsonProperty(PropertyName = "ordinal")]
    public string Ordinal { get; private set; }

    [JsonProperty(PropertyName = "formattedRank")]
    public string FormattedRank { get; private set; }

    [JsonProperty(PropertyName = "players")]
    public short Players { get; private set; }

    [JsonProperty(PropertyName = "formattedPlayers")]
    public string FormattedPlayers { get; private set; }

    [JsonProperty(PropertyName = "scores")]
    public int Scores { get; private set; }

    [JsonProperty(PropertyName = "formattedScores")]
    public string FormattedScores { get; private set; }

    [JsonProperty(PropertyName = "totalScoreValues")]
    public decimal TotalScoreValues { get; private set; }

    [JsonProperty(PropertyName = "formattedTotalScoreValues")]
    public string FormattedTotalScoreValues { get; private set; }

    [JsonProperty(PropertyName = "averageScore")]
    public long? AverageScore { get; private set; }

    [JsonProperty(PropertyName = "formattedAverageScore")]
    public string FormattedAverageScore { get; private set; }

    [JsonProperty(PropertyName = "bestScore")]
    public long? BestScore { get; private set; }

    [JsonProperty(PropertyName = "formattedBestScore")]
    public string FormattedBestScore { get; private set; }

    public Team()
    {

    }
}