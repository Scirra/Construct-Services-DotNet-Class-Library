using Newtonsoft.Json;
using System;

namespace ConstructServices.Authentication.Objects
{
    public class Player
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; private set; }
        
        [JsonProperty(PropertyName = "username")]
        public string Username { get; private set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; private set; }

        public Player()
        {

        }
        public Player(Guid id, string username, DateTime created)
        {
            ID = id;
            Username = username;
            Created = created;
        }
    }
}
