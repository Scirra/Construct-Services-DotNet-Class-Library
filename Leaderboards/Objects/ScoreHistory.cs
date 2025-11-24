using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Objects;

public sealed class ScoreHistory
{
    [JsonProperty(PropertyName = "date")]
    public DateTime Date { get; private set; }

    [JsonProperty(PropertyName = "score")]
    public long Score { get; private set; }

    [JsonProperty(PropertyName = "formattedScore")]
    public string FormattedScore { get; private set; }

    [JsonProperty(PropertyName = "rank")]
    public int Rank { get; private set; }

    [JsonProperty(PropertyName = "ordinal")]
    public string Ordinal { get; private set; }

    [JsonProperty(PropertyName = "formattedRank")]
    public string FormattedRank { get; private set; }

    [JsonProperty(PropertyName = "countryRank")]
    public int CountryRank { get; private set; }

    [JsonProperty(PropertyName = "countryOrdinal")]
    public string CountryOrdinal { get; private set; }

    [JsonProperty(PropertyName = "formattedCountryRank")]
    public string FormattedCountryRank { get; private set; }

    public ScoreHistory()
    {

    }
}