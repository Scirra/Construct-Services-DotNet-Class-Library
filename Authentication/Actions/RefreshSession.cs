using System.Collections.Generic;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse RefreshSession(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/refreshsession.json";

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