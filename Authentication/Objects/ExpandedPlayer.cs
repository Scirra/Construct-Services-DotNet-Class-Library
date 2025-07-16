using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ConstructServices.Authentication.Objects
{
    public class ExpandedPlayer
    {
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; set; }
        
        [JsonProperty(PropertyName = "playerName")]
        public string PlayerName { get; set; }
        
        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "successfulSignIns")]
        public int SuccessfulSignIns { get; set; }

        [JsonProperty(PropertyName = "lastSuccessfulSignIn")]
        public DateTime? LastSuccessfulSignIn { get; set; }
        
        [JsonProperty(PropertyName = "avatars")]
        public List<AvailableAvatar> Avatars { get; set; }
        
        [JsonProperty(PropertyName = "loginProviders")]
        public List<PlayerLoginProvider> LoginProviders { get; set; }

        public ExpandedPlayer()
        {

        }
    }
}
