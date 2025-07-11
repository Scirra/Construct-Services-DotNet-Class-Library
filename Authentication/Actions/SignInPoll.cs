using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static SignInPollResponse SignIn(
        this AuthenticationService service,
        string pollToken)
    {
        const string path = "/signinpoll.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<SignInPollResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "pollToken", pollToken }
            }
        )).Result;
    }
}