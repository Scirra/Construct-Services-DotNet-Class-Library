using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        return Task.Run(() => Common.Request.ExecuteRequest<GetConnectedLoginProvidersResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}