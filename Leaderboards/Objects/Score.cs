using Newtonsoft.Json;
using System;
using ConstructServices.Leaderboards.Objects;

namespace ConstructServices.Leaderboards.Objects
{
    public class Score
    {
        [JsonProperty(PropertyName = "scoreID")]
        public Guid ScoreID { get; private set; }

        [JsonProperty(PropertyName = "score")]
        public long ScoreValue { get; private set; }

        [JsonProperty(PropertyName = "formattedScore")]
        public string FormattedScore { get; private set; }

        [JsonProperty(PropertyName = "rank")]
        public int? Rank { get; private set; }

        [JsonProperty(PropertyName = "ordinal")]
        public string Ordinal { get; private set; }

        [JsonProperty(PropertyName = "formattedRank")]
        public string FormattedRank { get; private set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; private set; }

        [JsonProperty(PropertyName = "countryRank")]
        public int? CountryRank { get; private set; }

        [JsonProperty(PropertyName = "countryOrdinal")]
        public string CountryOrdinal { get; private set; }

        [JsonProperty(PropertyName = "formattedCountryRank")]
        public string FormattedCountryRank { get; private set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; private set; }

        [JsonProperty(PropertyName = "player")]
        public Player Player { get; private set; }

        [JsonProperty(PropertyName = "updates")]
        public int Updates { get; private set; }

        [JsonProperty(PropertyName = "compareScore")]
        public ScoreHistory CompareScore { get; private set; }

        [JsonProperty(PropertyName = "teamID")]
        public Guid? TeamID { get; private set; }

        [JsonProperty(PropertyName = "teamName")]
        public string TeamName { get; private set; }

        [JsonProperty(PropertyName = "tier")]
        public Tier Tier { get; private set; }

        [JsonProperty(PropertyName = "optionalValue1")]
        public short? OptionalValue1 { get; private set; }

        [JsonProperty(PropertyName = "optionalValue2")]
        public short? OptionalValue2 { get; private set; }

        [JsonProperty(PropertyName = "optionalValue3")]
        public short? OptionalValue3 { get; private set; }

        public Score()
        {
        }
    }
}
