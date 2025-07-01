using Newtonsoft.Json;
using System;

namespace ConstructServices.Leaderboards.Objects
{
    public class Player
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; private set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; private set; }

        public Player()
        {
        }
    }
}
