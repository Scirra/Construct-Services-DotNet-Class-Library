using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static SignInPollResponse SignIn(
        this AuthenticationService service,
        string pollToken)
    {
        const string path = "/signinpoll.json";

        return Common.Request.ExecuteSyncRequest<SignInPollResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "pollToken", pollToken }
            }
        );
    }
}