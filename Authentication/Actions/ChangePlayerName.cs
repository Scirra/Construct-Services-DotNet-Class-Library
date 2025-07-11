using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse ChangePlayerName(
        this AuthenticationService service,
        Guid playerID,
        string newPlayerName)
    {
        const string path = "/changeplayername.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "playerName", newPlayerName },
            }
        )).Result;
    }
    public static BaseResponse ChangePlayerName(
        this AuthenticationService service,
        string sessionKey,
        string newPlayerName)
    {
        const string path = "/changeplayername.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "playerName", newPlayerName },
            }
        )).Result;
    }
}