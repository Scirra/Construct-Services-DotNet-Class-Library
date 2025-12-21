using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static GetSessionResponse GetSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/getsession.json";

        return Common.Request.ExecuteSyncRequest<GetSessionResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        );
    }
}