using ConstructServices.Authentication.Objects;
using ConstructServices.Common;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public sealed class LoginPollResponse : BaseResponse
{
    [JsonProperty(PropertyName = "session")]
    public Session Session { get; set; }
        
    [JsonProperty(PropertyName = "signInFailed")]
    public bool SignInFailed { get; set; }

    [JsonProperty(PropertyName = "signInErrorMessage")]
    public string SignInErrorMessage { get; set; }

    public LoginPollResponse()
    {
    }

    public LoginPollResponse(string errorMessage, bool shouldRetry = false) : base(errorMessage, shouldRetry)
    {
    }
}