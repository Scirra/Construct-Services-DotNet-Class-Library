using ConstructServices.CloudSave.Responses;
using ConstructServices.Common;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConstructServices.CloudSave.Objects;

namespace ConstructServices.CloudSave.Actions;

public static partial class CloudSaves
{
    /// <summary>
    /// Upload a new cloud save to a bucket from a player
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Create(
        this CloudSaveService service,
        string sessionKey,
        Guid bucketID,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
        => DoCreate(service, sessionKey, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

    /// <summary>
    /// Upload a new cloud save to a bucket from a player
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Create(
        this CloudSaveService service,
        string sessionKey,
        GameBucket bucket,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
        => DoCreate(service, sessionKey, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

    /// <summary>
    /// Upload a new cloud save to a bucket with no player association
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Create(
        this CloudSaveService service,
        Guid bucketID,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
        => DoCreate(service, null, bucketID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

    /// <summary>
    /// Upload a new cloud save to a bucket with no player association
    /// </summary>
    [UsedImplicitly]
    public static CloudSaveResponse Create(
        this CloudSaveService service,
        GameBucket bucket,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
        => DoCreate(service, null, bucket.ID, cloudSaveData, cloudSaveName, cloudSaveKey, picture);

    private static CloudSaveResponse DoCreate(
        CloudSaveService service,
        string sessionKey,
        Guid? bucketID,
        byte[] cloudSaveData,
        string cloudSaveName,
        string cloudSaveKey,
        PictureData picture = null)
    {
        var formData = new Dictionary<string, string>
        {
            { "name", cloudSaveName },
            { "key", cloudSaveKey }
        };
        if (!string.IsNullOrWhiteSpace(sessionKey))
        {
            formData.Add("sessionKey", sessionKey);
        }
        if (bucketID.HasValue)
        {
            formData.Add("bucketID", bucketID.ToString());
        }
        
        // Add binary data to request
        var postedBinaryData = new Dictionary<string, ByteArrayContent>
        {
            { "data", new ByteArrayContent(cloudSaveData) }
        };
        if (picture != null)
        {
            if (!string.IsNullOrWhiteSpace(picture.Base64))
            {
                formData.Add("picture", picture.Base64);
            }
            else if (picture.URL != null)
            {
                formData.Add("pictureURL", picture.URL.ToString());
            }
            if (picture.Bytes != null)
            {
                postedBinaryData.Add("picture", new ByteArrayContent(picture.Bytes));
            }
        }

        const string path = "/create.json";
        return Task.Run(() => Request.ExecuteMultiPartFormRequest<CloudSaveResponse>(
            path,
            service,
            formData,
            postedBinaryData
        )).Result;
    }
}