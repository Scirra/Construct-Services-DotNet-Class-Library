using Newtonsoft.Json;

namespace ConstructServices.Leaderboards.Objects
{
    public class Player
    {
        [JsonProperty(PropertyName = "playerID")]
        public string PlayerID { get; private set; }

        [JsonProperty(PropertyName = "currentScore")]
        public long? CurrentScore { get; private set; }

        [JsonProperty(PropertyName = "formattedScore")]
        public string FormattedScore { get; private set; }

        public Player()
        {

        }
    }
}
