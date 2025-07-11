using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;
using System;

namespace ConstructServices.Authentication.Responses
{
    public class SignInResponse : BaseResponse
    {
        [JsonProperty(PropertyName = "redirectToURL")]
        public string RedirectToURL { get; set; }

        [JsonProperty(PropertyName = "pollToken")]
        public Guid PollToken { get; set; }
        
        public SignInResponse()
        {
        }
        public SignInResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
        {
        }
    }
}
