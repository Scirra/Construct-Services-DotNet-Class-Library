using Newtonsoft.Json;
using System;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Responses;

public sealed class LoginResponse : BaseResponse
{
    [JsonProperty(PropertyName = "redirectToURL")]
    public string RedirectToURL { get; set; }

    [JsonProperty(PropertyName = "pollToken")]
    public Guid PollToken { get; set; }
        
    public LoginResponse()
    {
    }
    public LoginResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}