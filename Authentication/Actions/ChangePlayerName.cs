using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse ChangePlayerName(
        this AuthenticationService service,
        Guid playerID,
        string newPlayerName)
    {
        const string path = "/changeplayername.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "playerName", newPlayerName }
            }
        )).Result;
    }
    [UsedImplicitly]
    public static BaseResponse ChangePlayerName(
        this AuthenticationService service,
        string sessionKey,
        string newPlayerName)
    {
        const string path = "/changeplayername.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "playerName", newPlayerName }
            }
        )).Result;
    }
}