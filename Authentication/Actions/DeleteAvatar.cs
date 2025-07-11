using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse DeleteAvatar(
        this AuthenticationService service,
        Guid playerID)
    {
        const string path = "/deleteavatar.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
            }
        )).Result;
    }
    public static BaseResponse DeleteAvatar(
        this AuthenticationService service,
        string sessionKey)
    {
        const string path = "/deleteavatar.json";

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