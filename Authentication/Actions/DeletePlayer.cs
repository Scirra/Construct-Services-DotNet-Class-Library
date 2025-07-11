using ConstructServices.Leaderboards.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse DeletePlayer(
        this AuthenticationService service,
        Guid playerID)
    {
        const string path = "/deleteplayer.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
            }
        )).Result;
    }
    public static BaseResponse DeletePlayer(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/deleteplayer.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            }
        )).Result;
    }
}