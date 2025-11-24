using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects;

public sealed class Leaderboard
{
    [JsonProperty(PropertyName = "globalScores")]
    public int GlobalScores { get; private set; }

    [JsonProperty(PropertyName = "formattedGlobalScores")]
    public string FormattedGlobalScores { get; private set; }

    [JsonProperty(PropertyName = "countryScores")]
    public int? CountryScores { get; private set; }
    public bool ShouldSerializeCountryScores() => CountryScores.HasValue;

    [JsonProperty(PropertyName = "formattedCountryScores")]
    public string FormattedCountryScores { get; private set; }
    public bool ShouldSerializeFormattedCountryScores() => CountryScores.HasValue;

    public Leaderboard()
    {

    }
}