using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static LinkLoginProviderResponse ForceLinkLoginProvider(
        this AuthenticationService service,
        string forceLinkCode)
    {
        const string path = "/forcelink.json";

        return Task.Run(() => Common.Request.ExecuteRequest<LinkLoginProviderResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "code", forceLinkCode }
            }
        )).Result;
    }
}