using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Set a cloud saves picture
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPicture(
        CloudSaveService service,
        string sessionKey,
        Guid cloudSaveID,
        PictureData picture)
    {
        const string path = "/setpicture.json";

        var formData = new Dictionary<string, string>
        {
            { "blobID", cloudSaveID.ToString() }
        };
        if (!string.IsNullOrWhiteSpace(sessionKey))
        {
            formData.Add("sessionKey", sessionKey);
        }

        // Picture by data
        if (picture.Bytes != null)
        {
            return Task.Run(() => Request.ExecuteMultiPartFormRequest<BaseResponse>(
                path,
                service,
                formData,
                new Dictionary<string, ByteArrayContent>{ {"picture", new ByteArrayContent(picture.Bytes) } }
            )).Result;
        }

        // By URL
        if (picture.URL != null)
        {
            formData.Add("pictureURL", picture.URL.ToString());
            return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
                path,
                service,
                formData
            )).Result;
        }

        // By base 64
        if (!string.IsNullOrWhiteSpace(picture.Base64))
        {
            formData.Add("picture", picture.Base64);
            return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
                path,
                service,
                formData
            )).Result;
        }

        return new BaseResponse("No picture data provided.", false);
    }
}