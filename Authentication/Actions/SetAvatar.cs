using ConstructServices.Common;
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
        PictureData picture)
    {
        const string path = "/setavatar.json";
        var formData = new Dictionary<string, string>
        {
            { "sessionKey", sessionKey }
        };

        if (picture.Bytes != null)
        {
            return Task.Run(() => Request.ExecuteMultiPartFormRequest<BaseResponse>(
                path,
                service,
                formData,
                new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
            )).Result;
        }

        if (picture.URL != null)
        {
            formData.Add("avatarURL", picture.URL.ToString());
        }
        else if (!string.IsNullOrWhiteSpace(picture.Base64))
        {
            formData.Add("avatar", picture.Base64);
        }
        return Task.Run(() => Request.ExecuteRequest<BaseResponse>(
            path,
            service,
            formData
        )).Result;
    }
}