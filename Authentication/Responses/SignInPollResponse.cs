using ConstructServices.Authentication.Objects;
using ConstructServices.Leaderboards.Responses;
using Newtonsoft.Json;

namespace ConstructServices.Authentication.Responses;

public class SignInPollResponse : BaseResponse
{
    [JsonProperty(PropertyName = "session")]
    public Session Session { get; set; }
        
    [JsonProperty(PropertyName = "signInFailed")]
    public bool SignInFailed { get; set; }

    [JsonProperty(PropertyName = "signInErrorMessage")]
    public string SignInErrorMessage { get; set; }

    public SignInPollResponse()
    {
    }

    public SignInPollResponse(string errorMessage, bool shouldRetry) : base(errorMessage, shouldRetry)
    {
    }
}