using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static GetConnectedLoginProvidersResponse GetLoginProviders(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/getconnectedloginproviders.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<GetConnectedLoginProvidersResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}