using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Actions;

[UsedImplicitly]
public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse ChangePassword(
        this AuthenticationService service,
        Guid playerID,
        string newPassword)
    {
        const string path = "/changepassword.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "playerID", playerID.ToString() },
                { "newPassword", newPassword }
            }
        )).Result;
    }
    [UsedImplicitly]
    public static BaseResponse ChangePassword(
        this AuthenticationService service,
        string sessionKey,
        string currentPassword,
        string newPassword)
    {
        const string path = "/changepassword.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "password", currentPassword },
                { "newPassword", newPassword }
            }
        )).Result;
    }
}