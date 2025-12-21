using Newtonsoft.Json;
using System;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Responses;

public sealed class SignInResponse : BaseResponse
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