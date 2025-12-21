using ConstructServices.Common;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;

namespace ConstructServices.Authentication.Actions;

public static partial class Players
{
    [UsedImplicitly]
    public static BaseResponse SetAvatar(
        this AuthenticationService service,
        string sessionKey,
        PictureData picture)
    {
        const string path = "/setavatar.json";
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey }
        };

        if (picture.Bytes != null)
        {
            return Request.ExecuteMultiPartFormSyncRequest<BaseResponse>(
                path,
                service,
                formData,
                new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
            );
        }

        if (picture.URL != null)
        {
            formData.Add("avatarURL", picture.URL.ToString());
        }
        else if (!string.IsNullOrWhiteSpace(picture.Base64))
        {
            formData.Add("avatar", picture.Base64);
        }
        return Request.ExecuteSyncRequest<BaseResponse>(
            path,
            service,
            formData
        );
    }
}