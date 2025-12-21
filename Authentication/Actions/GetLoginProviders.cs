using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static GetConnectedLoginProvidersResponse GetLoginProviders(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/getconnectedloginproviders.json";

        return Common.Request.ExecuteSyncRequest<GetConnectedLoginProvidersResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        );
    }
}