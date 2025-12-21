using ConstructServices.Authentication.Objects;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse DisconnectLoginProvider(
        this AuthenticationService service,
        string sessionKey,
        LoginProvider provider)
    {
        const string path = "/disconnect.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
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