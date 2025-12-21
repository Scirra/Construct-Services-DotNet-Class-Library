using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse EndSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/endsession.json";

        return Request.ExecuteSyncRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        );
    }
}