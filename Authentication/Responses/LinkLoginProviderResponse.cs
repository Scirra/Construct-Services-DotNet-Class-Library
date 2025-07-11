using System;
using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses
{
    public class LinkLoginProviderResponse : BaseResponse
    {                
        [JsonProperty(PropertyName = "linked")]
        public bool Linked { get; set; }
        
        [JsonProperty(PropertyName = "forceCode")]
        public Guid ForceCode { get; set; }

        [JsonProperty(PropertyName = "forceURL")]
        public string ForceURL { get; set; }

        [JsonProperty(PropertyName = "forceCodeExpiryMins")]
        public int ForceCodeExpiryMins { get; set; }

        public LinkLoginProviderResponse()
        {
        }
        public LinkLoginProviderResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {

        }
    }
}
