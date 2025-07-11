using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Objects
{
    public class ShadowBan
    {
        [JsonProperty(PropertyName = "dateBanned")]
        public DateTime Date { get; private set; }

        [JsonProperty(PropertyName = "ipHash")]
        public int IPHash { get; private set; }

        [JsonProperty(PropertyName = "country")]
        public string ISOAlpha2 { get; private set; }

        [JsonProperty(PropertyName = "player")]
        public Player Player { get; private set; }

        public ShadowBan()
        {

        }
    }
}
