using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse DeletePlayer(
        this AuthenticationService service,
        Guid playerID)
    {
        const string path = "/deleteplayer.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() }
            }
        )).Result;
    }
    [UsedImplicitly]
    public static BaseResponse DeletePlayer(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/deleteplayer.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}