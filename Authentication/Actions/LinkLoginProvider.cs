using ConstructServices.Authentication.Objects;
using ConstructServices.Authentication.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;
public static partial class Players
{
    [UsedImplicitly]
    public static SignInResponse LinkLoginProvider(
        this AuthenticationService service,
        LoginProvider provider,
        string sessionKey)
    {
        const string path = "/link.json";

        return Task.Run(() => Common.Request.ExecuteRequest<SignInResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "provider", provider.ToString() },
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}