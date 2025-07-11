using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static LinkLoginProviderResponse ForceLinkLoginProvider(
        this AuthenticationService service,
        string forceLinkCode)
    {
        const string path = "/forcelink.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<LinkLoginProviderResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "code", forceLinkCode }
            }
        )).Result;
    }
}