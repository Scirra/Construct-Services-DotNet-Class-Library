using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConstructServices.Common;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        string base64AvatarData)
    {
        const string path = "/setavatar.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "avatar", base64AvatarData }
            }
        )).Result;
    }
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        Uri avatarURL)
    {
        const string path = "/setavatar.json";

        return Task.Run(() => Request.ExecuteAuthenticationRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "avatarURL", avatarURL.ToString() }
            }
        )).Result;
    }
}