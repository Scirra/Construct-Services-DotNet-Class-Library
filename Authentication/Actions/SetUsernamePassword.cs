using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse SetUsernameAndPassword(
        this AuthenticationService service,
        Guid playerID,
        string username,
        string password)
    {
        const string path = "/setusernamepassword.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "username", username },
                { "password", password }
            }
        )).Result;
    }
}
