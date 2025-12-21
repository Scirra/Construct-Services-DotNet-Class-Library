using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse SetUsernameAndPassword(
        this AuthenticationService service,
        Guid playerID,
        string username,
        string password)
    {
        const string path = "/setusernamepassword.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
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
