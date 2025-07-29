using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Set a cloud saves picture by URL
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPictureByURL(CloudSaveService service, string sessionKey, Guid cloudSaveID, string pictureURL)
        => SetPicture(service, sessionKey, cloudSaveID, null, pictureURL, null);

    /// <summary>
    /// Set a cloud saves picture by URL
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPictureByURL(CloudSaveService service, string sessionKey, Objects.CloudSave cloudSave, string pictureURL)
        => SetPicture(service, sessionKey, cloudSave.ID, null, pictureURL, null);

    /// <summary>
    /// Set a cloud saves picture by base 64 encoded picture data
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPictureByBase64(CloudSaveService service, string sessionKey, Guid cloudSaveID, string base64PictureData)
        => SetPicture(service, sessionKey, cloudSaveID, base64PictureData, null, null);

    /// <summary>
    /// Set a cloud saves picture by URL
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPictureByBase64(CloudSaveService service, string sessionKey, Objects.CloudSave cloudSave, string base64PictureData)
        => SetPicture(service, sessionKey, cloudSave.ID, base64PictureData, null, null);

    /// <summary>
    /// Set a cloud saves picture by binary picture data
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPicture(CloudSaveService service, string sessionKey, Guid cloudSaveID, byte[] picture)
        => SetPicture(service, sessionKey, cloudSaveID, null, null, picture);

    /// <summary>
    /// Set a cloud saves picture by binary picture data
    /// </summary>
    [UsedImplicitly]
    public static BaseResponse SetPicture(CloudSaveService service, string sessionKey, Objects.CloudSave cloudSave, byte[] picture)
        => SetPicture(service, sessionKey, cloudSave.ID, null, null, picture);

    private static BaseResponse SetPicture(
        CloudSaveService service,
        string sessionKey,
        Guid cloudSaveID,
        string base64PictureData,
        string pictureURL,
        byte[] postedFile)
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
        if (postedFile != null)
        {
            return Task.Run(() => Request.ExecuteMultiPartFormRequest<BaseResponse>(
                path,
                service,
                formData,
                [new ByteArrayContent(postedFile)]
            )).Result;
        }

        // By URL
        if (!string.IsNullOrWhiteSpace(pictureURL))
        {
            formData.Add("pictureURL", pictureURL);
            return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
                path,
                service,
                formData
            )).Result;
        }

        // By base 64
        if (!string.IsNullOrWhiteSpace(base64PictureData))
        {
            formData.Add("picture", base64PictureData);
            return Task.Run(() => Request.ExecuteRequest<CloudSaveResponse>(
                path,
                service,
                formData
            )).Result;
        }

        return new BaseResponse("No picture data provided.", false);
    }
}