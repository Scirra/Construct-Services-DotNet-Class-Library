using ConstructServices.Authentication.Objects;
using ConstructServices.Leaderboards.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse DisconnectLoginProvider(
        this AuthenticationService service,
        string sessionKey,
        LoginProvider provider)
    {
        const string path = "/disconnect.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "provider", provider.ToString() }
            }
        )).Result;
    }
}