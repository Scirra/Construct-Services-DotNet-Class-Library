using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        string base64AvatarData)
    {
        const string path = "/setavatar.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "avatar", base64AvatarData }
            }
        )).Result;
    }

    [UsedImplicitly]
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        Uri avatarURL)
    {
        const string path = "/setavatar.json";

        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey },
                { "avatarURL", avatarURL.ToString() }
            }
        )).Result;
    }

    [UsedImplicitly]
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        byte[] avatarBytes)
    {
        const string path = "/setavatar.json";
        return Task.Run(() => Request.ExecuteMultiPartFormRequest<BaseResponse>(
            path,
            service,
            new Dictionary<string, string>
            {
                { "sessionKey", sessionKey }
            },
            [new ByteArrayContent(avatarBytes)]
        )).Result;
    }
}